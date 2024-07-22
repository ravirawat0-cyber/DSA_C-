using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    static bool isSorted(int[] a, int index = 0)
    {
        if (index == a.Length - 1 || a.Length == 0) return true;
        if (a[index] > a[index + 1]) return false;
        // bool sorted = isSorted(a.Skip(1).ToArray() , n -1);
        bool sorted = isSorted(a, index + 1);
        return sorted;
    }

    static int sumOfArray(int[] a)
    {
        if (a.Length == 0) return 0;
        int smallout = sumOfArray(a.Skip(1).ToArray());
        return a[0] + smallout;
    }
    static int sumOfArray2(int[] a, int index)
    {
        if (index == 0) return a[index];
        int smallout = sumOfArray2(a, index - 1);
        return smallout + a[index];
    }

    static bool CheckIfPresent(int[] a, int key, int index = 0)
    {
        if (index == a.Length - 1) return false;
        if (a[index] == key) return true;
        bool present = CheckIfPresent(a, key, index + 1);
        return present;
    }

    static bool CheckIfPresent2(int[] a, int n, int key)
    {
        if (n == 0) return false;
        if (a[0] == key) return true;

        return CheckIfPresent2(a.Skip(1).ToArray(), n - 1, key);
    }

    static int firstIndexOfElement(int[] a, int key, int index = 0)
    {
        if (index == a.Length - 1) return -1;
        if (a[index] == key) return index;
        int first = firstIndexOfElement(a, key, index + 1);
        return first;
    }

    static int LastIndexOfElemnt(int[] a, int key, int index = 0)
    {
        // if (index == a.Length - 1) return -1;
        // int smallout = LastIndexOfElemnt(a, key, index + 1);
        // if (smallout == -1)
        // {
        //     if (a[index] == key) return index;
        // }
        // return smallout;

        if (index == -1) return -1;
        if (a[index] == key) return index;
        return LastIndexOfElemnt(a, key, index - 1);
    }

    static void printAllPosition(int[] a, int key, int index = 0)
    {
        if (index == a.Length) return;
        if (a[index] == key)
            Console.WriteLine(index);
        printAllPosition(a, key, index + 1);
    }

    static int countAccourence(int[] a, int key, int index = 0)
    {
        if (index == a.Length) return 0;
        if (a[index] == key)
            return 1 + countAccourence(a, key, index + 1);
        else
            return countAccourence(a, key, index + 1);
    }

    static void storeAccurence(int[] a, int key, List<int> tempArr, int index = 0)
    {
        if (index == a.Length) return;
        if (a[index] == key) tempArr.Add(index);
        storeAccurence(a, key, tempArr, index + 1);
    }

    static bool checkPal(int[] a, int s, int e)
    {
        if (s > e) return true;
        if (a[s] == a[e]) return checkPal(a, s + 1, e - 1);
        else return false;
    }

    public static void Main(string[] args)
    {
        // bool answer = isSorted(new int[] { 1, 2, 7, 4, 5 });
        // int answer = sumOfArray(new int[] { 1, 2, 7, 4, 5 });
        //int answer = sumOfArray2(new int[] { 1, 2, 7, 4, 5 }, 4);      
        // bool answer = CheckIfPresent(new int[] { 1, 2, 7, 4, 5 }, 9);
        // bool answer = CheckIfPresent2(new int[] { 1, 2, 7, 4, 5 }, 5, 7);
        //int answer = firstIndexOfElement(new int[] { 1, 2, 7, 7, 5 }, 7);
        // int answer = LastIndexOfElemnt(new int[] { 1, 2, 7, 7,7, 5 }, 7, 5);
        // printAllPosition(new int[] { 7, 2, 7, 8, 7, 7 }, 7);
        // int answer = countAccourence(new int[] { 1, 2, 3, 8, 5 }, 7);

        // List<int> arr = new List<int>();
        // storeAccurence(new int[] { 7, 2, 7, 8, 7, 7 }, 7, arr);
        // foreach (int i in arr) Console.WriteLine(i);
        bool answer = checkPal(new int[] { 1, 2, 3, 4, 3, 2, 1 }, 0, 6);
        Console.WriteLine(answer);
    }

}