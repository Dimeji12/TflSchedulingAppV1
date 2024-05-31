namespace TflScheduling.CustomCollections;

public class LineScheduleDictionary
{
    public Station? Station { get; set; }
    public LineSchedule? LineSchedule { get; set; }

    public LineScheduleDictionary()
    {
        Station = null;
        LineSchedule = null;
    }

    public LineScheduleDictionary(Station station, LineSchedule lineSchedule)
    {
        Station = station;
        LineSchedule = lineSchedule;
    }

}