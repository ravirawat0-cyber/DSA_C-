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


public class StackCus<T>
{
    private Node<T> top;

    public StackCus()
    {
        top = null;
    }

    public void Push(T value)
    {
        Node<T> newNode = new Node<T>(value);
        newNode.Next = top;
        top = newNode;
    }

    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("stack is empty.");
        T value = top.Value;
        top = top.Next;
        return value;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("stack is empty");
        }
        return top.Value;
    }

    public int Count()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("stack is empty");
        }
        Node<T> temp = top;
        int count = 0;
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }

    public bool IsEmpty()
    {
       return top == null;
    }
}


class Program
{
    public static void Main(string[] args)
    {
        // Stack<int> stack = new Stack<int>();

        // stack.Push(1);
        // stack.Push(2);
        // stack.Push(3);

        // Console.WriteLine("Popped: " + stack.Pop());
        // Console.WriteLine("Peek:" + stack.Peek());
        // Console.WriteLine("length :" + stack.Count);

        StackCus<int> stack = new StackCus<int>();
        Console.WriteLine(stack.IsEmpty());
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        Console.WriteLine(stack.Count());
        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.IsEmpty());
    }
}