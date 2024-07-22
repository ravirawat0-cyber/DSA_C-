using System;
using System.Collections.Generic;

class Program
{

    public static int BinarySearch(List<int> arr, int key)
    {
        int s = 0, e = arr.Count;
        Console.WriteLine(e);
        while (s <= e)
        {
            int mid = s + (e - s)/2;
            if (arr[mid] == key) return mid;
            else if (arr[mid] > key) e = mid - 1;
            else s = mid + 1;
        }
        return -1;
    }


    public static void Main(string[] args)
    {

        var List = new List<int> { 1, 2, 3, 4, 5 };
        int key = 4;
        for(int i = 0; i < List.Count; i++){
          if(List[i] == key)
          {
            Console.WriteLine("Found at: " + (i + 1));
            break;
          }
        }

        int foundAt = BinarySearch(List, key);
        Console.WriteLine("Found at: " + (foundAt + 1));



    
    }
}