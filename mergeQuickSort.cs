using System;
using System.Collections.Generic;

class Program
{
    static List<int> merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        int start_left = 0, start_right = 0;
        int len_left = left.Count, len_right = right.Count;

        while (start_left < len_left && start_right < len_right)
        {
            if (left[start_left] < right[start_right])
            {
                result.Add(left[start_left]);
                start_left++;
            }
            else
            {
                result.Add(right[start_right]);
                start_right++;
            }
        }
        while (start_left < len_left)
        {
            result.Add(left[start_left]);
            start_left++;
        }
        while (start_right < len_right)
        {
            result.Add(right[start_right]);
            start_right++;
        }
        return result;
    }

    static List<int> mergeSort(List<int> arr)
    {
        if (arr.Count <= 1) return arr;
        int mid = arr.Count / 2;
        List<int> left = mergeSort(arr.GetRange(0, mid));
        List<int> right = mergeSort(arr.GetRange(mid, arr.Count - mid));
        return merge(left, right);
    }


    static int partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int lowIndex = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                lowIndex++;
                swap(arr, lowIndex, j);
            }
        }
        swap(arr, lowIndex + 1, high);
        return lowIndex + 1;
    }

    static void quickSort(int[] arr, int start, int end)
    {
        if (start >= end) return;
        int pivot = partition(arr, start, end);
        quickSort(arr, start, pivot - 1);
        quickSort(arr, pivot + 1, end);
    }

   static void swap(int[] arr, int i , int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static void Main(string[] args)
    {
        // List<int> arr = new List<int> { 8, 5, 2, 7, 3, 4 };
        //  List<int> newa = mergeSort(arr);

        int[] array = { 22, 11, 88, 12, 55, 77, 9, 5, 4 };
        quickSort(array, 0, array.Length - 1);
        Console.WriteLine(String.Join(", ", array));
        

    }
}