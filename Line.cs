using TflScheduling.CustomCollections;
using TflScheduling.Enums;

namespace TflScheduling;

public class Line
{
    public LineName Name { get; }
    public LineDirection Direction { get; }
    
    public CLinkedList<LineSchedule> Schedules { get; set; }

    public Line(LineName name, LineDirection direction)
    {
        Name = name;
        Direction = direction;
        // Schedules = new List<TrainSchedule>();
    }

    public override string ToString()
    {
        
        return $"Line: {Name}, " +
               $"Direction: {Direction}, ";
    }
}