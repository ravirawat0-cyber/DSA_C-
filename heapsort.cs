using System;
using System.Collections.Generic;


class Program
{
    public static void Main(string[] args)
    {
        
        int[] arr = { 5, 6, 9, 12, 3, 13,2};
        Kshorted(arr, arr.Length, 3);
        KshortedK(arr, arr.Length, 3);
    }
    public static void Kshorted(int[] arr, int n, int k)
    {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

        for (int i = 0; i < n; i++)
        {
            pq.Enqueue(arr[i], arr[i]);
        }

        List<int> result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            result.Add(pq.Dequeue());
        }

        foreach (var item in result) Console.WriteLine(item + ", ");


    }

    public static void KshortedK(int[] arr, int n, int k)
    {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        for (int i = 0; i < n; i++)
        {
            pq.Enqueue(arr[i], arr[i]);
            if (pq.Count > k) Console.WriteLine(pq.Dequeue());
        }
        List<int> result = new List<int>();
        for (int i = 0; i < k; i++)
        {
            result.Add(pq.Dequeue());
        }
        Console.WriteLine("----------------");
        foreach (var item in result) Console.WriteLine(item + ", ");
    }

    public void inplaceHeapSort(int[] pq, int n, int k)
    {
        for (int i = 1; i < n; i++)
        {
            int ci = i;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (pq[ci] < pq[pi])
                {
                    (pq[ci], pq[pi]) = (pq[pi], pq[ci]);
                    ci = pi;
                }
                else
                {
                    break;
                }
            }
        }

        int size = n;
        while (size > 1)
        {
            (pq[0], pq[size - 1]) = (pq[size - 1], pq[0]);
            size--;
            int pi = 0;
            while (true)
            {
                int lci = 2 * pi + 1;
                int rci = 2 * pi + 2;
                int mini = pi;

                if (lci < size && pq[lci] < pq[mini]) mini = lci;
                if (rci < size && pq[rci] < pq[mini]) mini = rci;
                if (mini == pi) break;

                (pq[pi], pq[mini]) = (pq[mini], pq[pi]);
                pi = mini;
            }
        }

    }
}