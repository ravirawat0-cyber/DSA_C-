using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Enter the number of elements");
        int len = int.Parse(Console.ReadLine());
        int[] numbers = new int[len];

        for(int i = 0;i < len; i++)
        {
          numbers[i] = int.Parse(Console.ReadLine());
        }

        // int sum = numbers.Sum(x => x);
        // Console.WriteLine(sum);
        // int max = int.MinValue; 
        // for(int i = 0; i < len;i++)
        // {
        //   if(numbers[i] > max)
        //      max = numbers[i];
        // }
        // Console.WriteLine(max);

        // Console.WriteLine(numbers.Max());

        //swap number 
        // int a = 10;
        // int b = 20;
      
        // int temp = a;
        // a = b;
        // b = temp;

        // a = a^b;
        // b = a^b;
        // a = a^b;
        // Console.WriteLine($" {a} {b}");


        // for(int i = len - 1; i >= 0; i--)
        // {
        //     Console.WriteLine(numbers[i] + " ");
        // }

        // Array.Reverse(numbers);
        // var reverseArr = numbers.Reverse();

        
    }
}