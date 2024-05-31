using TflScheduling.Enums;

namespace TflScheduling;
public class Station : IEquatable<Station>
{
    public StationName Name { get; set; }

    public Station(StationName name)
    {
        Name = name;
    }

    public bool Equals(Station other)
    {
        if (other == null)
            return false;

        return this.Name == other.Name;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        Station other = obj as Station;
        return this.Equals(other);
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

}
