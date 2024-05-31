using TflScheduling.Enums;

namespace TflScheduling.CustomCollections;

public class CLinkedList<T>
{
    private CListNode<T>? _head;
    private int _length;

    public CLinkedList()
    {
        _head = null;
        _length = 0;
    }

    public bool IsEmpty()
    {
        return _head == null;
    }

    public void InsertAtHead(T item)
    {
        if (item != null)
        {
            CListNode<T> newItem = new CListNode<T>(item, _head);
            _head = newItem;
        }

        _length++;
    }

    public bool InsertAfter(T newItem, T afterItem)
    {
        // find the afterItem’s node
        CListNode<T>? afterNode = FindItem(afterItem);
        if (afterNode != null)
        {
            if (newItem != null)
            {
                CListNode<T> newItemNode = new CListNode<T>(newItem, afterNode.Next);
                afterNode.Next = newItemNode;
            }

            _length++;
            return true;
        }
        return false;
    }
    
    public CListNode<T>? GetFirst()
    {
        return _head;
    }

    public void InsertAtEnd(T item)
    {
        if (item == null) return; 

        CListNode<T> newItem = new CListNode<T>(item, null);
        if (_head == null)
        {
            
            _head = newItem;
        }
        else
        {
            // Traverse the list to find the last node
            CListNode<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            // Set the new item as the next of the last node
            current.Next = newItem;
        }
        _length++;
    }


    private CListNode<T>? FindItem(T item)
    {
        // check if list is empty
        if (!IsEmpty())
        {
            // traverse the list by starting at the head
            var current = _head;
            // while not at end of the list & not found item continue
            while (item != null && (current != null) && (!(item.Equals(current.Item))))
            {
                current = current.Next!;
            }

            return current;
        }
        else {
            // list is empty
            return null;
        }
    }
    
    public bool DeleteItem(T item)
    {
        CListNode<T>? current = _head;
        CListNode<T>? previous = null;

        while (current != null)
        {
            if (item != null && item.Equals(current.Item))
            {
                if (previous == null) // Item is at the head
                {
                    _head = current.Next;
                }
                else // Item is not at the head
                {
                    previous.Next = current.Next;
                }
                _length--;
                return true; // Item was found and removed
            }
            previous = current;
            current = current.Next;
        }
        return false; // Item not found
    }

    public int GetLength()
    {
        return _length;
    }

    public void Clear()
    {
        _head = null;
        _length = 0;
    }

    public void PrintList()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty");
        }else
        {
            var current = _head;
            Console.WriteLine("Items in the list are:");
            while (current != null) // not at end of the list
            {
                if (current.Item != null) Console.WriteLine(current.Item.ToString());
                current = current.Next;
            }
        }
    }
}