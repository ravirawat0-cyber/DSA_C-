using System;

class Program
{
    public static void Main(string[] args)
    {
        int[] arr = { 7, 5, 3, 6, 8 };
        int len = arr.Length;

        for (int i = 0; i < len - 1; i++)
        {
            int tempIndex = i;
            for (int j = i + 1; j < len; j++)
            {
                if (arr[j] < arr[tempIndex]) tempIndex = j;
            }
            if (arr[i] > arr[tempIndex])
            {
                int temp = arr[i];
                arr[i] = arr[tempIndex];
                arr[tempIndex] = temp;
            }
        }

        for (int i = 0; i < len; i++)
        {
            Console.WriteLine(arr[i] + " ");
        }

    }
}