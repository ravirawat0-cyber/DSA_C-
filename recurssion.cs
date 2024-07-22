using System;

class Program
{

    static int fact(int n)
    {
        if (n < 0) return -1;
        if (n == 1) return 1;
        return n * fact(n - 1);
    }

    static int fibo(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        return fibo(n - 1) + fibo(n - 2);
    }

    static int pow(int b, int exp)
    {
        if (exp == 0) return 1;

        int smallOut = pow(b, exp - 1);
        return b * smallOut;
    }


    static void print(int n)
    {
        if (n == 0) return;
        print(n - 1);
        Console.Write(n + " ");
    }

    static void printRev(int n)
    {
        if (n == 0) return;
        Console.Write(n + " ");
        printRev(n - 1);
    }

    static int countDigit(int n)
    {
        if (n == 0) return 1;
        int smallout = countDigit(n / 10);
        return smallout + 1;
    }

    static int sumOfDigit(int n)
    {
        if (n == 0) return 0;
        int lastDigit = n % 10;
        int smallout = sumOfDigit(n / 10);
        return lastDigit + smallout;
    }

    static int multiplication(int m, int n)
    {
        if (n == 1) return 0;
        int smallout = multiplication(m, n - 1);
        return m + smallout;
    }

    static int CountZero(int n)
    {
        if (n == 0) return 0;
        int smallout = CountZero(n / 10);
        if (n % 10 == 0) return smallout + 1;
        else return smallout;
    }

    static double GeoSum(int k)
    {
        if (k == 0) return 1;
        double smallout = GeoSum(k - 1);
        return smallout + 1.0 / Math.Pow(2, k);
    }

    public static void Main(string[] args)
    {
        // int answer = fact(5);
        //   int answer = fibo(3);
        // int answer = pow(2, 3);
        // printRev(5);
        // int answer = countDigit(1234);
        // int answer = sumOfDigit(1234);
        //   int answer = multiplication(2, 3);
        //   int answer = CountZero(1023040);
        double answer = GeoSum(3);
        Console.WriteLine(answer);
    }
}