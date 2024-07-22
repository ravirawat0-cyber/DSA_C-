using System;

class Program
{
    public static void Main(string[] args)
    {
        // String Concatenation
        string str1 = "Hello";
        string str2 = "World";
        string result = str1 + " " + str2;
        Console.WriteLine("Concatenation: " + result); // Output: Hello World

        // String Length
        int length = str1.Length;
        Console.WriteLine("Length: " + length); // Output: 5

        // Substring
        string substring = result.Substring(0, 5);
        Console.WriteLine("Substring: " + substring); // Output: Hello

        // String Comparison
        bool areEqual = str1.Equals("hello", StringComparison.OrdinalIgnoreCase);
        Console.WriteLine("Comparison: " + areEqual); // Output: True

        // String Contains
        bool contains = result.Contains("World");
        Console.WriteLine("Contains: " + contains); // Output: True

        // String Replacement
        string replaced = result.Replace("World", "C#");
        Console.WriteLine("Replacement: " + replaced); // Output: Hello C#

        // String Splitting
        string[] words = result.Split(' ');
        Console.WriteLine("Splitting:");
        foreach (string word in words)
        {
            Console.WriteLine(word);
        }
        // Output:
        // Hello
        // World

        // String Joining
        string joined = string.Join(" ", words);
        Console.WriteLine("Joining: " + joined); // Output: Hello World

        // String Trimming
        string strWithSpaces = "  Hello World  ";
        string trimmed = strWithSpaces.Trim();
        Console.WriteLine("Trimming: " + trimmed); // Output: Hello World

        // String Case Conversion
        string upper = result.ToUpper();
        string lower = result.ToLower();
        Console.WriteLine("ToUpper: " + upper); // Output: HELLO WORLD
        Console.WriteLine("ToLower: " + lower); // Output: hello world
    }
}