using System;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}

public class Queue<T>
{
    private Node<T> top;

    public Queue()
    {
        top = null;
    }

    public void Enqueue(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (top == null)
        {
            top = newNode;
        }
        else
        {
            Node<T> temp = top;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }
    }

    public T Dequeue()
    {
        if (isEmpty()) throw new InvalidOperationException("Queue is empty.");
        T val = top.Value;
        top = top.Next;
        return val;
    }

    public T Peek()
    {
        if (isEmpty()) throw new InvalidOperationException("Queue is empty.");
        T val = top.Value;
        return val;
    }

    public int Length()
    {
        if (isEmpty()) return 0;
        Node<T> temp = top;
        int count = 0;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }

    public bool isEmpty()
    {
        if (top == null) return true;
        return false;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        Console.WriteLine(queue.Length());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Length());
        Console.WriteLine(queue.Peek());
    }
}