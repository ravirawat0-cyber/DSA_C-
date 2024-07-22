using System;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter characters in a single line");
        string input = Console.ReadLine();
        char[] charct = input.ToCharArray();
        // Array.Reverse(charct);
        // string ct = "";
        // foreach (char c in charct)
        //        ct += c;

        //     for(int i = 0 ; i < (charct.Length)/2; i++)
        //   {
        //     var temp = charct[i];
        //     charct[i] = charct[charct.Length - i - 1];
        //     charct[charct.Length - i - 1] = temp;
        //   }

        //   foreach(char c in charct) Console.Write(c);
        // }

        // for(int i = 0; i < charct.Length; i++)
        // {
        //   for(int j = 0; j <= i; j++)
        //   {
        //     Console.Write(charct[j]);
        //   }
        //   Console.WriteLine();
        // }

        StringBuilder prefix = new StringBuilder();
        for(int i = 0 ; i < charct.Length; i++)
        {
           prefix.Append(charct[i]);
           Console.WriteLine(prefix);
        }

}
    }