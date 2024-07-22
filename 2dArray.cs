using System;

class Program
{
    public static void Main(string[] args)
    {

        int[,] intArray = {
          {1,2,3},
          {3,4,5},
          {6,7,8}
        };

        string[,] strArray = {
          {"Hello", "World"},
          {"foo", "boo"}
          };

        Console.WriteLine(intArray[0, 0]);
        Console.WriteLine(strArray[1, 1]);

        for (int i = 0; i < intArray.GetLength(0); i++)
        {
            for (int j = 0; j < intArray.GetLength(0); j++)
            {
                Console.WriteLine(intArray[i, j] + " ");
            }
        }

        Console.WriteLine("Enter the number of rows: ");
        int row = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of columns: ");
        int col = int.Parse(Console.ReadLine());

        int[,] array = new int[row, col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Console.WriteLine($"Enter element at[{i}, {j}]");
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }


        int[,] zeroArray = new int[3, 3];  // default value is zero
        for (int i = 0; i < zeroArray.GetLength(0); i++)
        {
            for (int j = 0; j < zeroArray.GetLength(0); j++)
            {
                Console.WriteLine(zeroArray[i, j] + " ");
            }
        }


    }
}