using TflScheduling;
using TflScheduling.Enums;
using TflScheduling.CustomCollections;

public class Graph
{
    //Custom Graph that makes use of:
    //Vertex: The stations
    //Edge: Line Schedules

    private AdjacencyDictionary[] AdjacencyList { get; set; }

    //Size of the array
    private int maxSize;

    public Graph(int size)
    {
        AdjacencyList = new AdjacencyDictionary[size];
        maxSize = size;

        //Initializes the vertices of the graph
        //By adding them to the adjacency list
        InitializeStations();
    }

    private void InitializeStations()
    {
        int index = 0;

        //Iterate through the Enums to find each station
        foreach (StationName name in Enum.GetValues(typeof(StationName)))
        {
            var station = new Station(name);
            //Only add stations if they don't exist
            if (FindStation(station) == null && index < maxSize) // Ensuring index bounds
            {
                AdjacencyList[index++] = new AdjacencyDictionary(station, new LineSchedule[maxSize]);
            }
        }
    }

    //To find stations if they don't exist
    private AdjacencyDictionary FindStation(Station station)
    {
        foreach (var entry in AdjacencyList)
        {
            if (entry != null && entry.Station.Equals(station))
                return entry;
        }

        return null;
    }

    public void AddLine(Line line)
    {
        //In this method, we want to add lines
        //These lines include lines like Bakerloo and all their LineSchedules

        var currentNode = line.Schedules.GetFirst();
        while (currentNode != null)
        {
            var schedule = currentNode.Item;
            var stationEntry = FindStation(schedule.FromStation);

            //Check if the station in the Line exists
            if (stationEntry == null)
            {
                Console.WriteLine("Station not found: " + schedule.FromStation.Name);
                break; // Optionally handle the error more gracefully
            }
            else
            {
                 
                AddScheduleToStation(stationEntry, schedule);
            }

            currentNode = currentNode.Next;
        }
    }


    private void AddScheduleToStation(AdjacencyDictionary stationEntry, LineSchedule schedule)
    {
        for (int i = 0; i < stationEntry.LineSchedules.Length; i++)
        {
            if (stationEntry.LineSchedules[i] == null)
            {
                stationEntry.LineSchedules[i] = schedule;
                break;
            }
        }
    }
    public void AddLinesFromList(CLinkedList<Line> lineList)
    {
        var currentNode = lineList.GetFirst();
        while (currentNode != null)
        {
            AddLine(currentNode.Item);
            currentNode = currentNode.Next;
        }
    }
    public PathSegment[] GetShortestPath(StationName start, StationName destination)
    {
        
        var startStation = new Station(start);
        var destinationStation = new Station(destination);

        
        var closedSet = new CustomHashSet<Station>(maxSize);

        
        var distances = new StationToTimeDictionary[maxSize];

        
        var previous = new StationToStationDictionary[maxSize];
        var previousLineSchedule = new LineScheduleDictionary[maxSize];
        
        foreach (var entry in AdjacencyList)
        {
            if (entry != null)
            {
                int index = GetStationIndex(entry.Station);
                distances[index] =
                    new StationToTimeDictionary(entry.Station, double.MaxValue);
                previous[index] = new StationToStationDictionary();
                previousLineSchedule[index] =
                    new LineScheduleDictionary();
            }
        }

        // Set the distance to the start station as 0.
        int startIndex = GetStationIndex(startStation);
        distances[startIndex].Time = 0;

        while (closedSet.Count < maxSize)
        {
            Station current = null;
            double minDistance = double.MaxValue;
            
            for (int i = 0; i < maxSize; i++)
            {
                if (distances[i] != null && !closedSet.Contains(distances[i].Station) &&
                    distances[i].Time < minDistance)
                {
                    current = distances[i].Station;
                    minDistance = distances[i].Time;
                }
            }

            if (current == null || current.Equals(destinationStation)) break;

            // Mark the current station as processed.
            closedSet.Add(current);
            int currentIndex = GetStationIndex(current);
            var currentEntry = FindStation(current);
            
            if (currentEntry != null)
            {
                foreach (var neighbor in currentEntry.LineSchedules)
                {
                    if (neighbor != null && !closedSet.Contains(neighbor.ToStation))
                    {
                        int neighborIndex = GetStationIndex(neighbor.ToStation);
                        double alt = distances[currentIndex].Time + neighbor.UnimpededRunningTime;
                        if (alt < distances[neighborIndex].Time)
                        {
                            distances[neighborIndex].Time = alt;
                            previous[neighborIndex] = new StationToStationDictionary(current, neighbor.ToStation);
                            previousLineSchedule[neighborIndex] = new LineScheduleDictionary(current, neighbor);
                        }
                    }
                }
            }
        }

        // Prepare the array for path construction.
        var path = new PathSegment[maxSize];
        int pathIndex = 0;

        // Start backtracking from the destination.
        Station step = destinationStation;
        while (step != null && previous[GetStationIndex(step)] != null &&
               previous[GetStationIndex(step)].Station != null)
        {
            int stepIndex = GetStationIndex(step);
            var lineSchedule = previousLineSchedule[stepIndex].LineSchedule;
            
            path[pathIndex++] = new PathSegment(step, lineSchedule);
            
            step = previous[stepIndex].Station;
        }

        PathSegment[] finalPath = new PathSegment[pathIndex];
        int finalIndex = 0;
        for (int i = pathIndex - 1; i >= 0; i--)
        {
            finalPath[finalIndex++] = path[i];
        }

        return finalPath;
    }

    private int GetStationIndex(Station station)
    {
        
        return (int)station.Name;
    }
}