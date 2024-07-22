using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    public Node<T> head;

    public LinkedList()
    {
        head = null;
    }

    // Add a new Node with data
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }

        else
        {
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // Remove from the linklist
    public void Remove()
    {
        if (head == null) return;

        if (head.Next == null)
        {
            head = null;
            return;
        }

        Node<T> current = head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        current.Next = null;
    }

    public void Print()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Data + "->");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void PrintIth(int index)
    {
        if (index < 0 || index > Length() - 1) return;

        Node<T> current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        Console.WriteLine(current.Data);
    }

    public bool Search(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }
        }
        return false;
    }

    public bool SearchRec(T data, Node<T> current)
    {
        if (current == null) return false;
        if (current.Data.Equals(data)) return true;
        return SearchRec(data, current.Next);
    }

    public int Length()
    {
        int count = 0;
        Node<T> current = head;
        while (current != null)
        {
            count++;
            current = current.Next;

        }
        return count;
    }

    public int LengthRec(Node<T> head)
    {
        if (head == null) return 0;
        int smallAns = LengthRec(head.Next);
        return 1 + smallAns;
    }

    public void InsertAtIthNode(int index, T data)
    {
        if (index < 0 || index > Length()) return;

        Node<T> newNode = new Node<T>(data);

        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node<T> previous = head;
            for (int i = 0; i < index - 1; i++)
            {
                previous = previous.Next;
            }

            newNode.Next = previous.Next;
            previous.Next = newNode;
        }
    }

    public void DeleteIthNode(int index)
    {
        if (index < 0 || index > Length()) return;

        if (index == 0)
        {
            head = head.Next;
        }
        else
        {
            Node<T> previous = head;
            for (int i = 0; i < index - 1; i++)
            {
                previous = previous.Next;
            }
            previous.Next = previous.Next.Next;
        }
    }
}




class Program
{
    public static void Main(string[] args)
    {

        LinkedList<int> list = new LinkedList<int>();
        list.Add(2);
        list.Add(3);
        list.Add(5);
        list.Add(7);
        // Console.WriteLine(list.Search(15));
        list.Print();
        list.PrintIth(1);

        Console.WriteLine(list.LengthRec(list.head));

        list.InsertAtIthNode(2, 10);

        //  list.DeleteIthNode(4);
        list.Print();

     Console.WriteLine(list.SearchRec(13 , list.head));

        // list.Remove();

        // //list.RemoveLast();

        // list.Print();


    }
}