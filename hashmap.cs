using System;
using System.Collections.Generic;

public class MapNode<V>
{
    public string Key { get; set; }
    public V Value { get; set; }
    public MapNode<V> Next { get; set; }

    public MapNode(string key, V value)
    {
        Key = key;
        Value = value;
        Next = null;
    }
}

public class Map<V>
{
    private MapNode<V>[] buckets;
    private int count;
    private int noOfBuckets;

    public Map()
    {
        count = 0;
        noOfBuckets = 5;
        buckets = new MapNode<V>[noOfBuckets];
    }

    private int GetBucketIndex(string key)
    {
        int hashcode = 0;
        int baseVal = 1;
        int prime = 37;

        for (int i = key.Length - 1; i >= 0; i--)
        {
            hashcode = (hashcode + key[i] * baseVal) % noOfBuckets;
            baseVal = (baseVal * prime) % noOfBuckets;
        }

        return hashcode % noOfBuckets;
    }

    public void Add(string key, V value)
    {
        int bucketIndex = GetBucketIndex(key);
        MapNode<V> head = buckets[bucketIndex];
        while (head != null)
        {
            if (head.Key == key)
            {
                head.Value = value;
                return;
            }
            head = head.Next;
        }
        MapNode<V> newNode = new MapNode<V>(key, value);
        newNode.Next = buckets[bucketIndex];
        buckets[bucketIndex] = newNode;
        count++;

        if (((1.0 * count) / noOfBuckets) > 0.7)
        {
            Rehash();
        }
    }

    public V GetValue(string key)
    {
        int bucketIndex = GetBucketIndex(key);
        MapNode<V> head = buckets[bucketIndex];

        while (head != null)
        {
            if (head.Key == key) return head.Value;
            head = head.Next;
        }
        return default(V);
    }

    public V Remove(string key)
    {
        int bucketIndex = GetBucketIndex(key);
        MapNode<V> head = buckets[bucketIndex];
        MapNode<V> prev = null;

        while (head != null)
        {
            if (head.Key == key)
            {
                if (prev == null) buckets[bucketIndex] = head.Next;
                else prev.Next = head.Next;
                count--;
                return head.Value;
            }
            prev = head;
            head = head.Next;
        }

        return default(V);
    }

    public int Size()
    {
        return count;
    }

    private void Rehash()
    {
        MapNode<V>[] temp = buckets;
        buckets = new MapNode<V>[noOfBuckets * 2];
        noOfBuckets = noOfBuckets * 2;
        count = 0;

        for (int i = 0; i < temp.Length; i++)
        {
            MapNode<V> head = temp[i];
            while (head != null)
            {
                Add(head.Key, head.Value);
                head = head.Next;
            }
        }
    }

    public double GetLoadFactor()
    {
        Console.WriteLine("loadfactor");
        return (1.0 * count) / noOfBuckets;
    }
}


class Program
{
    public static void Main(string[] args)
    {
        // int[] arr = { 1, 2, 2, 10, 3, 3, 4, 5, 6, 7, 8, 9, 10, 3, 10 };
        // Dictionary<int, bool> dict = new Dictionary<int, bool>();
        // List<int> newList = new List<int>();

        // foreach (int i in arr)
        // {
        //     if (!dict.ContainsKey(i))
        //     {
        //         newList.Add(i);
        //         dict.Add(i, true);
        //     }
        // }

        // foreach (var kvp in newList)
        // {
        //     Console.WriteLine(kvp);
        // }


        Map<int> map = new Map<int>();
        for (int i = 0; i < 10; i++)
        {
            string key = "abc" + (char)('0' + i);
            int value = i;
            map.Add(key, value);
            Console.WriteLine( map.GetLoadFactor());
        }
        Console.WriteLine("size: " + map.Size());

        Console.WriteLine(map.Remove("abc2"));
        Console.WriteLine(map.Remove("abc12"));

        for (int i = 0; i < 10; i++)
        {
            string key = "abc" + (char)('0' + i);
            Console.WriteLine($" {key} : {map.GetValue(key)}");
        }

    }
}