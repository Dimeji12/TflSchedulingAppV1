namespace TflScheduling;

public class PathSegment
{
    public Station Station { get; set; }
    public LineSchedule LineSchedule { get; set; }

    public int TotalTime { get; set; }

    public PathSegment(Station station, LineSchedule lineSchedule)
    {
        Station = station;
        LineSchedule = lineSchedule;
    }

    public override string ToString()
    {
        if (LineSchedule == null)
        {
            return $"Start Station: {Station.Name}";
        }
        else
        {
            ComputeData.TotalTravelTime += LineSchedule.UnimpededRunningTime;
            return $"Line: {LineSchedule.Line.Name}, " +
                   $"Direction: {LineSchedule.Line.Direction}, " +
                   $"From: {LineSchedule.FromStation.Name}, To: {LineSchedule.ToStation.Name}  " +
                   $"Time: {LineSchedule.UnimpededRunningTime}";
        }
    }
}