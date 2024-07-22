using System;
using System.Collections.Generic;

public class BTNode
{
    public int data { get; set; }
    public BTNode left;
    public BTNode right;

    public BTNode(int value)
    {
        data = value;
        left = null;
        right = null;
    }
}


public class BinaryTree
{
    public BTNode root { get; set; }

    public BinaryTree()
    {
        this.root = null;
    }

    public void Insert(int value)
    {
        root = InsertRecursively(root, value);
    }

    public void Print()
    {
        PrintRecursively(root);
    }

    public void TakeInput()
    {
        root = TakeInputHelper();
    }

    public BTNode TakeInputHelper()
    {
        Console.WriteLine("Enter the node value (or -1 for no nodes): ");
        int data = int.Parse(Console.ReadLine());

        if (data == -1) return null;

        var newRoot = new BTNode(data);

        Console.WriteLine("Enter the left child of " + data + ": ");
        newRoot.left = TakeInputHelper();

        Console.WriteLine("Enter the right child of " + data + ": ");
        newRoot.right = TakeInputHelper();

        return newRoot;
    }

    public void PrintLevelWise()
    {
        if (root == null)
        {
            Console.WriteLine("No data");
            return;
        }

        Queue<BTNode> queue = new Queue<BTNode>();
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            BTNode current = queue.Dequeue();
            Console.Write(current.data + ": ");
            if (current.left != null)
            {
                Console.Write(current.left.data + ", ");
                queue.Enqueue(current.left);
            }

            if (current.right != null)
            {
                Console.Write(current.right.data + ", ");
                queue.Enqueue(current.right);
            }

            Console.WriteLine();

        }
    }

    

    public void TakeInputLevelWise()
    {
        Console.WriteLine("Enter the root value: ");
        int rootData = int.Parse(Console.ReadLine());

        root = new BTNode(rootData);

        Queue<BTNode> queue = new Queue<BTNode>();
        queue.Enqueue(root);

        while (queue.Count != 0)
        {
            var current = queue.Dequeue();

            Console.WriteLine("Enter the left child of " + current.data + "(or -1 for no left child): ");
            int leftdata = int.Parse(Console.ReadLine());

            if (leftdata != -1)
            {
                current.left = new BTNode(leftdata);
                queue.Enqueue(current.left);
            }

            Console.WriteLine("Enter the right child of " + current.data + "(or -1 for no right child): ");
            int rightData = int.Parse(Console.ReadLine());

            if (rightData != -1)
            {
                current.right = new BTNode(rightData);
                queue.Enqueue(current.right);
            }
        }
    }

    public void PrintRecursively(BTNode root)
    {
        if (root == null) return;
        Console.Write(root.data + ": ");
        if (root.left != null) Console.Write("L " + root.left.data + ", ");

        if (root.right != null) Console.Write("R " + root.right.data + ", ");
        Console.WriteLine();
        PrintRecursively(root.left);
        PrintRecursively(root.right);

    }

    public BTNode InsertRecursively(BTNode root, int data)
    {
        if (root == null)
        {
            root = new BTNode(data);
            return root;
        }

        if (data < root.data)
        {
            root.left = InsertRecursively(root.left, data);
        }
        else
        {
            root.right = InsertRecursively(root.right, data);
        }

        return root;
    }

    public bool FindKeyRec(BTNode treeRoot, int key)
    {
        if (treeRoot == null) return false;
        if (treeRoot.data == key) return true;

        return FindKeyRec(treeRoot.left, key) || FindKeyRec(treeRoot.right, key);
    }
    public bool findKey(int key)
    {
        return FindKeyRec(root, key);
    }


    public int MinValue(BTNode root)
    {
        if (root == null) return int.MaxValue;
        int ans = root.data;
        int leftAns = MinValue(root.left);
        int rigthAns = MinValue(root.right);
        return Math.Min(ans, Math.Min(leftAns, rigthAns));
    }

    public int CountLeafNode(BTNode root)
    {
        if (root == null) return 0;
        if (root.left == null && root.right == null) return 1;

        return countLeafNode(root.left) + countLeafNode(root.right);
    }

    public bool rootToNodePathRec(BTNode root, int target, List<int> path)
    {
        if(root == null) return false;
        path.Add(root.data);
        if (root.data == target) return true;

        var left = rootToNodePathRec(root.left, target, path);
        var right = rootToNodePathRec(root.right, target, path);

        if (left || right) return true;
        path.RemoveAt(path.Count - 1);
        return false;
    }
    public void RootToNodePath(int target, List<int> ans);
    {
        BTNode tempRoot = root;
        var bool = rootToNodePathRec(tempRoot, target, ans);       
        return;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var tree = new BinaryTree();
        //tree.TakeInput();
        // tree.Insert(5);
        // tree.Insert(3);
        // tree.Insert(7);
        // tree.Insert(1);

        tree.TakeInputLevelWise();

        //tree.Print();

        tree.PrintLevelWise();
    }
}