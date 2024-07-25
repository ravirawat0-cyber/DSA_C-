using System;

class Program
{

    public static int fibRec(int n, int[] memo)
    {
        if (n == 0 || n == 1) return n;
        if (memo[n] != 0) return memo[n];

        memo[n] = fibRec(n - 1, memo) + fibRec(n - 2, memo);

        return memo[n];
    }

    public static int fibBottomUp(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];

    }

    public static int ClimbingStairs(int n, int[] memo)
    {
        if (n == 0 || n == 1) return 1;
        if (memo[n] != 0) return memo[n];
        memo[n] = ClimbingStairs(n - 1, memo) + ClimbingStairs(n - 2, memo);
        return memo[n];
    }

    public static int ClimbingStairsBottomUp(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[n];
    }

    public static int frogJumpTD(int[] arr, int n, int[] frogJmemo)
    {
        if (n == 0) return 0;
        if (frogJmemo[n] != 0) return frogJmemo[n];

        int left = frogJumpTD(arr, n - 1, frogJmemo) + Math.Abs(arr[n] - arr[n - 1]);
        int right = int.MaxValue;
        if (n > 1)
        {
            right = frogJumpTD(arr, n - 2, frogJmemo) + Math.Abs(arr[n] - arr[n - 2]);
        }
        frogJmemo[n] = Math.Min(left, right);
        return frogJmemo[n];
    }

    public static void frogJumpBU(int[] arr, int n)
    {
        //  int[] dp = new int[n  + 1];
        int prev = 0;
        int prev2 = 0;
        for (int i = 1; i <= n; i++)
        {
            int left = prev + Math.Abs(arr[i] - arr[i - 1]);
            int right = int.MaxValue;
            if (i > 1)
                right = prev2 + Math.Abs(arr[i] - arr[i - 2]);

            int curr = Math.Max(left, right);
            prev2 = prev;
            prev = curr;
        }

        Console.WriteLine(prev);
    }

    public static void frogKjumpBU(int[] arr, int n, int steps)
    {
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            int jump = int.MaxValue;
            for (int j = 1; j <= steps; j++)
            {
                if (i - j >= 0)
                {
                    int left = dp[i - j] + Math.Abs(arr[i] - arr[i - j]);
                    jump = Math.Min(left, jump);
                }
            }
            dp[i] = jump;

        }
        Console.WriteLine(dp[n]);
    }


    public static void Main(string[] args)
    {
        int[] temp = new int[] { 30, 10, 60, 10, 60, 50 };
        // int n = 2;
        // int[] memo = new int[n + 1];
        // Console.WriteLine(fibRec(n, memo));
        // Console.WriteLine("fib bup " + fibBottomUp(n));
        //   Console.WriteLine("clim TD " + ClimbingStairs(n, memo));

        // Console.WriteLine("clim bup " + ClimbingStairsBottomUp(n));
        // int[] frogJmemo = new int[6];
        // Console.WriteLine(frogJumpTD(temp, 5, frogJmemo));
        // foreach(var ele in frogJmemo) Console.WriteLine(ele);
        // frogJumpBU(temp, 5);
        frogKjumpBU(temp, 5, 2);
    }
}