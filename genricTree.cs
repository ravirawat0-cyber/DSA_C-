using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T data)
    {
        Value = data;
        Children = new List<TreeNode<T>>();
    }

    public void AddChild(TreeNode<T> child)
    {
        Children.Add(child);
    }
    public void RemoveChild(TreeNode<T> child)
    {
        Children.Remove(child);
    }
}




class Program
{
    public static void Main(string[] args)
    {
        // var root = new TreeNode<string>("Root");

        // var child1 = new TreeNode<string>("Child 1");
        // var child2 = new TreeNode<string>("Child 2");

        // root.AddChild(child1);
        // root.AddChild(child2);

        // var grandChild1 = new TreeNode<string>("Grandchild 1");
        // var grandChild2 = new TreeNode<string>("Grandchild 2");

        // child1.AddChild(grandChild1);
        // child1.AddChild(grandChild2);
        TreeNode<int> root = TakeInput();
        PrintTree(root);
        PrintLevelWise(root);
    }


    public void PreOrder(TreeNode<int> root)
    {
        if(root == null) return;
        Console.Write(root.Value + " ");
        for(int i = 0; i < root.Children.Count; i++)
        {
            PreOrder(root.Children[i]);
        }
    }

    public void PostOrder(TreeNode<int> root)
    {
        if(root == null) return;
        for(int i = 0; i < root.Children.Count; i++)
        {
            PostOrder(root.Children[i]);
        }
        Console.Write(root.Value + " ");
    }

    

    public int CountLeafNode(TreeNode<int> root)
    {
        if (root == null) return 0;
        if (root.Children.Count == 0) return 1;
        int ans = 0;
        for (int i = 0; i < root.Children.Count; i++)
        {
            ans += CountLeafNode(root.Children[i]);
        }
        return ans;
    }

    public int Height(TreeNode<int> root)
    {
        int mx = 0;
        for (int i = 0; i < root.Children.Count; i++)
        {
            int childHeight = Height(root.Children[i]);
            if (childHeight > mx)
            {
                mx = childHeight;
            }
        }
        return mx + 1;
    }

    public static int CountNodes(TreeNode<int> root)
    {
        int ans = 1;
        for (int i = 0; i < root.Children.Count; i++)
        {
            ans += CountNodes(root.Children[i]);
        }
        return ans;
    }

    public static void PrintLevelWise(TreeNode<int> root)
    {
        Queue<TreeNode<int>> q = new Queue<TreeNode<int>>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            TreeNode<int> f = q.Peek();
            q.Dequeue();
            Console.Write(f.Value + ": ");

            for (int i = 0; i < f.Children.Count; i++)
            {
                Console.Write(f.Children[i].Value + ", ");
                q.Enqueue(f.Children[i]);
            }
            Console.WriteLine();
        }
    }

    public static void PrintKthNode(TreeNode<int> root, int k)
    {
        if (root == null) return;
        if (k == 0)
        {
            Console.WriteLine(root.Value);
            return;
        }

        for (int i = 0; i < root.Children.Count; i++)
        {
            PrintKthNode(root.Children[i], k - 1);
        }
    }


    public static TreeNode<int> TakeInput()
    {
        Console.WriteLine("Enter the data ");
        var rootValue = Console.ReadLine();
        var root = new TreeNode<int>(int.Parse(rootValue));
        Console.WriteLine("Enter the number of children for the root node: ");
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            TreeNode<int> childValue = TakeInput();
            root.AddChild(childValue);
        }

        return root;
    }

    public static TreeNode<int> TakeInputLevelWise()
    {
        Console.WriteLine("Enter the data: ");
        var rootValue = Console.ReadLine();
        var root = new TreeNode<int>(int.Parse(rootValue));
        Queue<TreeNode<int>> q = new Queue<TreeNode<int>>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            TreeNode<int> current = q.Peek();
            q.Dequeue();

            Console.WriteLine("Enter the number of children for the node: ");
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the data for child: " + current.Value);
                var childValue = int.Parse(Console.ReadLine());
                var child = new TreeNode<int>(childValue);

                current.AddChild(child);
                q.Enqueue(child);
            }
        }

        return root;
    }

    public static void PrintTree<T>(TreeNode<T> root)
    {
        if (root == null) return;
        Console.Write(root.Value + ": ");
        foreach (var child in root.Children)
        {
            Console.Write(child.Value + ", ");
        }
        Console.WriteLine();

        foreach (var child in root.Children)
        {
            PrintTree(child);
        }
    }
}