namespace TflScheduling.CustomCollections;

public class AdjacencyDictionary
{
    public Station Station { get; set; }
    public LineSchedule[] LineSchedules { get; set; }

    public AdjacencyDictionary(Station station, LineSchedule[] lineSchedules)
    {
        Station = station;
        LineSchedules = lineSchedules;
    }
}