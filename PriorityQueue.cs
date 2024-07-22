using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<int> pq;

    public PriorityQueue()
    {
          pq = new List<int> ();
    }
    public bool IsEmpty()
    {
        return pq.Count == 0;
    }

    public int Size()
    {
        return pq.Count;
    }

    public int GetMin()
    {
        if (IsEmpty()) return 0;
        return pq[0];
    }

    public void Insert(int value)
    {
        pq.Add(value);
        int cI = pq.Count - 1;
        while (cI > 0)
        {
            int pI = (cI - 1) / 2;
            if (pq[cI] < pq[pI])
            {
                (pq[cI], pq[pI]) = (pq[pI], pq[cI]);
                cI = pI;
            }
            else
            {
                break;
            }
        }
    }

    public void Delete()
    {
        if (pq.Count == 0) return;

        int lastIndex = pq.Count - 1;
      
        (pq[0], pq[lastIndex]) = (pq[lastIndex], pq[0]);
        pq.RemoveAt(lastIndex);

        int pi = 0;
        while (true)
        {
            int lci = 2 * pi + 1;
            int rci = 2 * pi + 2;
            int mini = pi;

            if (lci < pq.Count && pq[lci] < pq[mini]) mini = lci;
            if (rci < pq.Count && pq[rci] < pq[mini]) mini = rci;

            if (pi == mini) break;
            (pq[pi], pq[mini]) = (pq[mini], pq[pi]);
            pi = mini;
        }
    }
}

class Program
{
    public static void Main(string[] args)
    {
        PriorityQueue p = new PriorityQueue();
        p.Insert(5);
        p.Insert(3);
        p.Insert(8);
        p.Insert(1);
        p.Insert(2);

      Console.WriteLine(p.GetMin());
       p.Delete();
      Console.WriteLine(p.GetMin());
    }
}