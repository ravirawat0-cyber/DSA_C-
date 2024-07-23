using System;

class Program
{
    public static void Main(string[] args)
    {
        int n = 7;
        int[] memo = new int[n + 1];
        Console.WriteLine(MinimumStepsToOne(n, memo));
        Console.WriteLine(MinimumStepsToOneIt(n));
        Console.WriteLine(MinimumStepsToOneIt2(n));
        Console.WriteLine(ClimbingStairs(2, 2));
    }

    public static int ClimbingStairs(int n, int steps)
    {
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            int ans = 0;
            for (int j = 1; j <= steps; j++)
            {
                if (i - j >= 0)
                    ans += dp[i - j];
            }
            dp[i] = ans;
        }

        return dp[n];
    }

    public static int MinimumStepsToOneIt2(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 0;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + 1;

            if (i % 2 == 0)
                dp[i] = Math.Min(dp[i], dp[n / 2] + 1);

            if (i % 3 == 0)
                dp[i] = Math.Min(dp[i], dp[n / 3] + 1);
        }

        return dp[n];
    }

    public static int MinimumStepsToOneIt(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 0;
        for (int i = 2; i <= n; i++)
        {
            int x = dp[i - 1];
            int y = int.MaxValue;
            int z = int.MaxValue;

            if (i % 2 == 0) x = dp[i / 2];
            if (i % 3 == 0) y = dp[i / 3];

            dp[i] = Math.Min(x, Math.Min(y, z)) + 1;
        }
        return dp[n];

    }

    public static int MinimumStepsToOne(int n, int[] memo)
    {
        if (n <= 1) return 0;
        if (memo[n] != 0) return memo[n];

        int x = MinimumStepsToOne(n - 1, memo);
        int y = int.MaxValue;
        int z = int.MaxValue;

        if (n % 2 == 0) y = MinimumStepsToOne(n / 2, memo);
        if (n % 3 == 0) z = MinimumStepsToOne(n / 3, memo);

        memo[n] = Math.Min(x, Math.Min(y, z)) + 1;

        return memo[n];
    }

    public static int FibonacciDPIt(int n)
    {
        int[] arr = new int[n + 1];
        arr[0] = 0;
        arr[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            arr[i] = arr[i - 1] + arr[i - 2];
        }
        return arr[n];
    }

    public static int FibonacciDP(int n, int[] arr)
    {
        if (n == 0 || n == 1) return n;
        if (arr[n] != 0) return arr[n];
        arr[n] = FibonacciDP(n - 1, arr) + FibonacciDP(n - 2, arr);
        return arr[n];
    }
}