using System;

class Program
{
    public static void Main(string[] args)
    {

        int[] arr = { 6, 4, 3, 2, 1 };
        int len = arr.Length;

        for (int count = 1; count < len; count++)
        {
            int flag = 0;
            for (int j = 0; j < len - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;

                    flag = 1;
                }
            }
            if (flag == 0) break;
        }

        for (int i = 0; i < len; i++)
        {
            Console.Write(arr[i] + " ");
        }

    }

}