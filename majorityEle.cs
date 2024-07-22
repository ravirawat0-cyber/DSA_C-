using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        int[] arr = { 2, 2, 1, 1, 1, 2, 2 };
        Dictionary<int, int> dict = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (dict.ContainsKey(arr[i]))
            {
                dict[arr[i]]++;
            }
            else
            {
                dict.Add(arr[i], 1);
            }
        }

        foreach (var kvp in dict)
        {
            if (kvp.Value > arr.Length / 2)
            {
                Console.WriteLine(kvp.Key);
            }
        }



    }
}