using System;
using System.Collections.Generic;

public class TreeNode
{
    public int val { get; set; }
    public TreeNode left { get; set; }
    public TreeNode right { get; set; }

    public TreeNode(int val)
    {
        this.val = val;
        this.left = null;
        this.right = null;
    }
}


public class BinarySearchTree
{
    public TreeNode root { get; set; }

    public BinarySearchTree()
    {
        root = null;
    }

    public void InsertInTree(int val)
    {
        root = InsertInTreeRec(root, val);
    }
    public void DeleteInTree(int val)
    {
        root = DeleteInTreeRec(root, val);
    }
    public bool SearchInTree(int val)
    {
        return SearchInTreeRec(root, val);
    }
    public void PrintTree()
    {
        PrintTreeLevelWise(root);
    }

    private TreeNode DeleteInTreeRec(TreeNode root, int val)
    {
        if (root == null) return null;
        if (root.val > val) root.left = DeleteInTreeRec(root.left, val);
        if (root.val < val) root.right = DeleteInTreeRec(root.right, val);
        else
        {
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;

            root.val = FindMin(root.right);
            root.right = DeleteInTreeRec(root.right, root.val);
        }

        return root;
    }


    private (TreeNode head , TreeNode tail) BSTToLL(TreeNode root)
    {
        if (root == null)
        {
            return (null, null);
        }
        else if(root.left == null && root.right == null)
        {
            return (root, root);
        }
        else if (root.left != null && root.right == null)
        {
            (TreeNode Lhead,TreeNode Ltail) = BSTToLL(root.left); 
            Ltail.right = root;
            root.left = null;
            return (Lhead, Ltail);
        }
        else if (root.left == null && root.right != null)
        {
            (TreeNode Rhead, TreeNode Rtail) = BSTToLL(root.right);
            root.right = Rhead;
            return (root, Rtail);
        }
        else {
          (TreeNode Lhead, TreeNode Ltail) = BSTToLL(root.left);
              (TreeNode Rhead, TreeNode Rtail) = BSTToLL(root.right);
            Ltail.right = root;
            root.left = null;
            root.right = Rhead;
          
            return (Lhead, Rtail);
        }
        
        
    }

    private int FindMin(TreeNode root)
    {
        var minval = root.val;
        while (root.left != null)
        {
            minval = root.val;
            root = root.left;
        }
        return minval;

    }

    private bool SearchInTreeRec(TreeNode root, int val)
    {
        if (root == null) return false;
        if (root.val == val) return true;
        if (root.val > val) return SearchInTreeRec(root.left, val);
        else return SearchInTreeRec(root.right, val);

    }

    private TreeNode InsertInTreeRec(TreeNode root, int val)
    {
        if (root == null)
        {
            root = new TreeNode(val);
            return root;
        }
        if (val < root.val) root.left = InsertInTreeRec(root.left, val);
        else root.right = InsertInTreeRec(root.right, val);

        return root;
    }

    private TreeNode TakeInputLevelWise(TreeNode root, int val)
    {
        Console.WriteLine("Insert root data: ");
        root = new TreeNode(int.Parse(Console.ReadLine()));
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            TreeNode temp = q.Dequeue();
            Console.WriteLine("Insert left child of " + temp.val + "or -1 to skip");
            int left = int.Parse(Console.ReadLine());
            if (left != -1)
            {
                temp.left = new TreeNode(left);
                q.Enqueue(temp.left);
            }

            Console.WriteLine("Insert right child of " + temp.val + "or -1 to skip");
            int right = int.Parse(Console.ReadLine());
            if (right != -1)
            {
                temp.right = new TreeNode(right);
                q.Enqueue(temp.right);
            }
        }
        return root;
    }

    private void PrintTreeLevelWise(TreeNode root)
    {
        if (root == null) return;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        while (q.Count != 0)
        {
            var node = q.Dequeue();
            Console.Write(node.val + "->");
            if (node.left != null)
            {
                Console.Write("L:" + node.left.val + ", ");
                q.Enqueue(node.left);
            }

            if (node.right != null)
            {
                Console.Write("R:" + node.right.val + " ");
                q.Enqueue(node.right);
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {

        BinarySearchTree b = new BinarySearchTree();
        b.InsertInTree(10);
        b.InsertInTree(5);
        b.InsertInTree(15);

        b.PrintTree();
    }
}