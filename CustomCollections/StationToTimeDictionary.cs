namespace TflScheduling.CustomCollections;

public class StationToTimeDictionary
{
    public Station? Station { get; set; }
    
    public double Time { get; set; }

    public StationToTimeDictionary()
    {
        Station = null;
        
        Time = 0;
    }

    public StationToTimeDictionary(Station station, double time)
    {
        Station = station;
        Time = time;
    }
}