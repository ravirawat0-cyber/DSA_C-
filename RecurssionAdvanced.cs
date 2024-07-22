using System;
using System.Collections.Generic;

class Program
{

    static void print(string str)
    {
        if (str == "") return;
        Console.WriteLine(str[0]);
        print(str.Substring(1));
    }

    static void revPrint(string str)
    {
        if (str == "") return;
        revPrint(str.Substring(1));
        Console.WriteLine(str[0]);
    }

    static string replaceChar(string str, char oldChar, char newChar)
    {
        if (str == "") return "";
        string smallout = replaceChar(str.Substring(1), oldChar, newChar);
        if (str[0] == oldChar) return newChar + smallout;
        else return str[0] + smallout;
    }

    static string removeChar(string str, char oldChar)
    {
        if (str == "") return "";
        string smallout = removeChar(str.Substring(1), oldChar);
        if (str[0] == oldChar) return smallout;
        else return str[0] + smallout;
    }

    static void printSubsequences(string str, string output)
    {
        if (str == "")
        {
            Console.WriteLine(output);
            return;
        }

        printSubsequences(str.Substring(1), output);
        printSubsequences(str.Substring(1), output + str[0]);
    }

    static void printSubsequencesIndex(string str, string output, int index = 0)
    {
        if (index == str.Length)
        {
            Console.WriteLine(output);
            return;
        }
        printSubsequencesIndex(str, output, index + 1);
        printSubsequencesIndex(str, output + str[index], index + 1);
    }

    static void storeSubsequences(string str, List<string> list, string output = "")
    {
        if (str == "")
        {
            list.Add(output);
            return;
        }
        storeSubsequences(str.Substring(1), list, output);
        storeSubsequences(str.Substring(1), list, output + str[0]);
    }

    static int convertStringToInteger(string str, int n)
    {
        if (n == 0) return 0;

        int smallans = convertStringToInteger(str, n - 1);
        int lasDigit = str[n - 1] - '0';
        int ans = smallans * 10 + lasDigit;
        return ans;
    }

    static void stringPermutation(string str, int i = 0)
    {
        if (i >= str.Length)
        {
            Console.WriteLine(str);
            return;
        }
        for (int j = i; j < str.Length; j++)
        {
            str = Swap(str, i, j);
            stringPermutation(str, i + 1);
            str = Swap(str, i, j);
        }
    }

    static string Swap(string str, int i, int j)
    {
        char[] charArray = str.ToCharArray();
        char temp = charArray[i];
        charArray[i] = charArray[j];
        charArray[j] = temp;
        return new string(charArray);
    }

    static int staircase(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 2;
        return staircase(n - 1) + staircase(n - 2) + staircase(n - 3);
    }

    static int toh(int n)
    {
        if (n == 0) return 0;
        return toh(n - 1) + 1 + toh(n - 1);
    }

    static void toh1(int n, char from, char to, char aux)
    {
        if (n == 0) return;
        toh1(n - 1, from, aux, to);
        Console.WriteLine("Move disk " + n + " from " + from + " to " + to);
        toh1(n - 1, aux, to, from);
        
    }

    public static void Main(string[] args)
    {
        //   string str = "abcd";
        //  print(str);
        //  revPrint(str);
        // Console.WriteLine(replaceChar(str, 'a', 'b'));
        //Console.WriteLine(removeChar(str, 'a'));
        //printSubsequences(str, "");
        //printSubsequencesIndex(str, "");

        // List<string> strings = new List<string>();
        // storeSubsequences(str, strings);
        // foreach(string s in strings) Console.WriteLine(s);

        //Console.WriteLine(convertStringToInteger("123", 3));
        //stringPermutation(str);
        //Console.WriteLine(staircase(3));
        //Console.WriteLine(toh(3));
         toh1(3, 'A', 'C', 'B');
    }
}