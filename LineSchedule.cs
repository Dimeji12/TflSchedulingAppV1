namespace TflScheduling;
public class LineSchedule
{
    public Station FromStation { get; set; }
    public Station ToStation { get; set; }
    public Line Line { get; set; }
    public double Delay { get; set; }
    public bool Closure { get; set; }
    public double Distance { get; set; }
    public double UnimpededRunningTime { get; set; }
    public double AmPeakRunningTime { get; set; }
    public double InterPeakRunningTime { get; set; }
    
    public LineSchedule(Station fromStation, Station toStation, Line line, 
        double distance, double unimpededRunningTime, 
        double amPeakRunningTime, double interPeakRunningTime)
    {
        Delay = 0; //Initial delay is 0
        Closure = false; // When line is created, it is not closed
        FromStation = fromStation;
        ToStation = toStation;
        Line = line;  // Assign the line
        Distance = distance;
        UnimpededRunningTime = unimpededRunningTime;
        AmPeakRunningTime = amPeakRunningTime;
        InterPeakRunningTime = interPeakRunningTime;
    }
    
    public override string ToString()
    {
        return $"Line: {Line.Name}, " +
               $"Direction: {Line.Direction}, " +
               $"Unimpeded Time: {UnimpededRunningTime}, ";
    }
}
