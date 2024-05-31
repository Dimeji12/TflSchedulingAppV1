namespace TflScheduling.CustomCollections;

public class CListNode<T>
{
    public T? Item { get; set; }
    public CListNode<T>? Next { get; set; }

    public CListNode()
    {
        Item = default(T);
        Next = null;
        
    }

    public CListNode(T item)
    {
        this.Item = item;
        this.Next = null;
    }

    public CListNode(T item, CListNode<T>? next)
    {
        this.Item = item;
        this.Next = next;
    }

}