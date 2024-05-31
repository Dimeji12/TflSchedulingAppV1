namespace TflScheduling.CustomCollections;

public class StationToStationDictionary
{
    public Station? Station { get; set; }
    
    public Station? StationB { get; set; }

    public StationToStationDictionary()
    {
        Station = null;
        
        StationB = null;
    }

    public StationToStationDictionary(Station station, Station stationB)
    {
        Station = station;
        StationB = stationB;
    }

}