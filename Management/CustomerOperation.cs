using TflScheduling.CustomCollections;
using TflScheduling.Enums;

namespace TflScheduling.Management;

public class CustomerOperation : ICustomer
{
    public static CLinkedList<Line> LineList { get; set; }

    private static bool continueFindRouteSelection = true;

    private static bool continueDisplayLineInfoSelecting = true;

    public CustomerOperation(CLinkedList<Line> lineList)
    {
        LineList = lineList;
    }

    public void FindRoute()
    {
        continueFindRouteSelection = true;

        while (continueFindRouteSelection)
        {
            Console.WriteLine("\nSelect the station you want to start from:");
            PrintStations(); // Print all stations for the user to choose the start station

            int fromStation = GetStationChoice();
            if (fromStation == 0)
            {
                continueFindRouteSelection = false;
                continue;
            }

            StationName startStation = (StationName)(fromStation - 1);

            Console.WriteLine("\nSelect your destination station:");
            PrintStations(); // Print all stations again for the user to choose the destination station

            int toStation = GetStationChoice();
            if (toStation == 0)
            {
                continueFindRouteSelection = false;
                continue;
            }

            StationName destinationStation = (StationName)(toStation - 1); // Adjusting for zero-based indexing

            // Assume a method that calculates and displays the route
            DisplayRoute(startStation, destinationStation);
        }
    }

    private void PrintStations()
    {
        int index = 1;
        foreach (StationName station in Enum.GetValues(typeof(StationName)))
        {
            
            const int spacing = -30;
            Console.Write($"{index}) {station, spacing}");
            if (index % 4 == 0)
            {
                Console.WriteLine();
            }
            
            index++;
        }

        Console.WriteLine($"{index}) Go back");
    }

    private int GetStationChoice()
    {
        Console.Write("Enter your choice (or " + (Enum.GetNames(typeof(StationName)).Length + 1) + " to go back): ");
        if (int.TryParse(Console.ReadLine(), out int stationChoice) &&
            stationChoice > 0 && stationChoice <= Enum.GetNames(typeof(StationName)).Length + 1)
        {
            return stationChoice;
        }
        else
        {
            Console.WriteLine("Invalid input, please select a valid option.");
            return -1; // Indicates invalid input or need to exit
        }
    }

    private void DisplayRoute(StationName startStation, StationName destinationStation)
{
    Console.WriteLine($"\n\nCalculating route from {startStation} to {destinationStation}...");
    Console.WriteLine($"{new string('-', 140)}");
    var graph = new Graph(Enum.GetValues(typeof(StationName)).Length + 50);
    graph.AddLinesFromList(LineList);

    var path = graph.GetShortestPath(startStation, destinationStation);
    ComputeData.TotalTravelTime = 0;
    double lineChangePenalty = 2.0;  // Time added for changing lines, in minutes

    if (path == null || path.Length == 0)
    {
        Console.WriteLine("No route available.");
        return;
    }

    Console.WriteLine($"Route: {startStation} to {destinationStation}:");
    Console.WriteLine($"(1) Start: {path[0].LineSchedule.FromStation.Name}, {path[0].LineSchedule.Line.Name} ({path[0].LineSchedule.Line.Direction})");

    int stepNumber = 2;
    Line previousLine = path[0].LineSchedule.Line;

    for (int i = 0; i < path.Length; i++)
    {
        var segment = path[i];
        // Check if the current segment involves a new line compared to the previous segment
        if (i > 0 && !previousLine.Equals(segment.LineSchedule.Line))
        {
            // Add penalty for line change
            ComputeData.TotalTravelTime += lineChangePenalty;  
            Console.WriteLine($"({stepNumber++}) Change: {segment.LineSchedule.FromStation.Name} {previousLine.Name} ({previousLine.Direction}) to {segment.LineSchedule.Line.Name} ({segment.LineSchedule.Line.Direction}) {lineChangePenalty}min");
        }
        previousLine = segment.LineSchedule.Line;
        Console.WriteLine($"({stepNumber++}) {segment.LineSchedule.Line.Name} ({segment.LineSchedule.Line.Direction}): {segment.LineSchedule.FromStation.Name} to {segment.LineSchedule.ToStation.Name} {segment.LineSchedule.UnimpededRunningTime}min");
        ComputeData.TotalTravelTime += segment.LineSchedule.UnimpededRunningTime;
    }

    Console.WriteLine($"({stepNumber}) End: {destinationStation}, {previousLine.Name} ({previousLine.Direction})");
    Console.WriteLine($"Total Journey Time: {ComputeData.TotalTravelTime:F2} minutes");
}


    public void DisplayLineInfo()
    {
        
        continueDisplayLineInfoSelecting = true;

        while (continueDisplayLineInfoSelecting)
        {
            Console.WriteLine("\nSelect a line from the list below to add a delay:");
            var currentNode = LineList.GetFirst();
            int index = 1;
            while (currentNode != null)
            {
                Console.WriteLine($"{index}) {currentNode.Item.Name}");
                currentNode = currentNode.Next;
                index++;
            }

            Console.WriteLine($"{index}) Go back");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int lineChoice) && lineChoice > 0 && lineChoice <= index)
            {
                if (lineChoice == index)
                {
                    continueDisplayLineInfoSelecting = false;
                }
                else
                {
                    HandleLineSelection(lineChoice);
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please select a valid option.");
            }
        }
    }
    
     private static void HandleLineSelection(int lineChoice)
    {
        continueDisplayLineInfoSelecting = true;
        var currentNode = LineList.GetFirst();
        int currentIndex = 1;
        while (currentNode != null && currentIndex < lineChoice)
        {
            currentNode = currentNode.Next;
            currentIndex++;
        }

        if (currentNode != null)
        {
            Line selectedLine = currentNode.Item;
            Console.WriteLine($"\nYou selected {selectedLine.Name}. Here are the schedules for this line:");

            Console.WriteLine($"\n{new string('=', 46)}");
            Console.Write($"{new string('=', 17)}");
            Console.Write($" Info for {selectedLine.Name} ");
            Console.WriteLine($"{new string('=', 17)}");
            Console.WriteLine($"{new string('=', 46)}");

            // Print header for columns
            Console.WriteLine("{0,-20} {1,-20} {2,-15} {3,-20} {4,-20} {5,-20} {6,-20} {7,-20}",
                "From Station", "To Station", "Distance (km)",
                "Running Time(min)", "Am Peak(min)", "Inter Peak(min)", "Delay(min)", "Status");
            Console.WriteLine($"{new string('-', 140)}");

            // Display each schedule associated with the line
            var scheduleNode = selectedLine.Schedules.GetFirst();
            int scheduleIndex = 1;
            if (scheduleNode == null)
            {
                Console.WriteLine("No schedules available for this line.");
            }
            else
            {
                while (scheduleNode != null)
                {
                    LineSchedule schedule = scheduleNode.Item;
                    var status = schedule.Closure ? "Closed" : "Open";
                    Console.WriteLine("{0}) {1,-18} {2,-20} {3,-15} {4,-21} {5,-19} {6,-19} {7,-19} {8,-19}",
                        scheduleIndex,
                        schedule.FromStation.Name,
                        schedule.ToStation.Name,
                        schedule.Distance.ToString("N2"),
                        schedule.UnimpededRunningTime.ToString("N2"),
                        schedule.AmPeakRunningTime.ToString("N2"),
                        schedule.InterPeakRunningTime.ToString("N2"),
                        schedule.Delay.ToString("N2"),
                        status);
                    scheduleNode = scheduleNode.Next;
                    scheduleIndex++;
                }
            }

            continueDisplayLineInfoSelecting = false;
        }
    }
}