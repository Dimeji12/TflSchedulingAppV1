namespace TflScheduling.CustomCollections;

public class CustomHashSet<T>
{
    private T[] items;
    private int capacity;
    public int Count { get; set; }
    
    public CustomHashSet(int capacity)
    {
        this.capacity = capacity;
        items = new T[capacity];
        Count = 0; // Initialize count to 0
    }

    private int GetHash(T item)
    {
        return Math.Abs(item.GetHashCode()) % capacity;
    }

    public bool Add(T item)
    {
        int index = GetHash(item);
        int start = index;

        while (items[index] != null)
        {
            if (items[index].Equals(item))
            {
                return false;
            }
            index = (index + 1) % capacity;
            if (index == start)
                throw new InvalidOperationException("HashSet is full");
        }

        items[index] = item;
        Count++;
        return true;
    }

    public bool Contains(T item)
    {
        int index = GetHash(item);
        int start = index;

        while (items[index] != null)
        {
            if (items[index].Equals(item))
            {
                return true;
            }
            index = (index + 1) % capacity;
            if (index == start)
                break;
        }
        return false;
    }

    public bool Remove(T item)
    {
        int index = GetHash(item);
        int start = index;

        while (items[index] != null)
        {
            if (items[index].Equals(item))
            {
                items[index] = default(T);
                Count--;
                return true;
            }
            index = (index + 1) % capacity;
            if (index == start)
                break;
        }
        return false;
    }
}
