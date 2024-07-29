using System;

class Program
{

    // -------------------------------63. Minimum Path Sum------------------------------------------

    public static int MinPathSumRec(int[][] grid, int m, int n)
    {
        if (m == 0 && n == 0) return grid[m][n];
        if (m < 0 || n < 0) return Int32.MaxValue;
        int up = MinPathSumRec(grid, m - 1, n);
        int left = MinPathSumRec(grid, m, n - 1);
        return grid[m][n] + Math.Min(left, up);
    }

    public static int MinPathSumMemo(int[][] grid, int m, int n, int[,] memo)
    {
        if (m == 0 && n == 0) return grid[m][n];

        if (m < 0 || n < 0) return Int32.MaxValue;

        if (memo[m, n] != 0) return memo[m, n];

        int up = MinPathSumMem(grid, m - 1, n, memo);
        int left = MinPathSumMem(grid, m, n - 1, memo);
        memo[m, n] = grid[m][n] + Math.Min(left, up);
        return memo[m, n];
    }

    public static int MinPathSumDP(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;

        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0) dp[i, j] = grid[i][j];
                else 
                {
                    int up = Int32.MaxValue;
                    int left = Int32.MaxValue;

                    if (i > 0) up = dp[i - 1, j];
                    if (j > 0) left = dp[i, j - 1];

                    dp[i, j] = grid[i][j] + Math.Min(up, left);
                }

            }
        }

        return dp[m - 1, n - 1];
    }



    // -------------------------------63. Unique Paths II------------------------------------------

    public static int UniquePathWithObstaclesRec(int[][] obstacleGrid, int m, int n)
    {
        if (m == 0 && n == 0 && obstacleGrid[m][n] != 1) return 1;
        if (m < 0 || n < 0) return 0;
        if (obstacleGrid[m][n] == 1) return 0;

        int up = UniquePathWithObstaclesRec(obstacleGrid, m - 1, n);
        int down = UniquePathWithObstaclesRec(obstacleGrid, m, n - 1);

        return up + down;
    }

    public static int UniquePathWithObstaclesMemo(int[][] obstacleGrid, int m, int n, int[,] memo)
    {
        if (m == 0 && n == 0 && obstacleGrid[m][n] != 1) return 1;
        if (m < 0 || n < 0) return 0;
        if (obstacleGrid[m][n] == 1) return 0;

        if (memo[m, n] != 0) return memo[m, n];

        int up = UniquePathWithObstaclesMemo(obstacleGrid, m - 1, n, memo);
        int down = UniquePathWithObstaclesMemo(obstacleGrid, m, n - 1, memo);

        memo[m, n] = up + down;
        return memo[m, n];
    }

    public static int UniquePathsWithObstaclesDP(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;

        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0 && obstacleGrid[i][j] != 1) dp[i, j] = 1;
                else if (obstacleGrid[i][j] == 1) dp[i, j] = 0;
                else
                {
                    int left = 0;
                    int up = 0;

                    if (i > 0) up = dp[i - 1, j];
                    if (j > 0) left = dp[i, j - 1];

                    dp[i, j] = left + up;

                }
            }
        }
        return dp[m - 1, n - 1];
    }


    // ----------------------------------- 62. Unique Paths I --------------------------------------------
    public static int UniquePathsRec(int m, int n)
    {
        if (m == 0 && n == 0) return 1;
        if (m < 0 || n < 0) return 0;

        int upward = UniquePathsRec(m - 1, n);
        int leftward = UniquePathsRec(m, n - 1);

        return upward + leftward;
    }

    public static int UniquePathsMemo(int m, int n, int[,] memo)
    {
        if (m == 0 && n == 0) return 1;
        if (m < 0 || n < 0) return 0;

        if (memo[m, n] != 0) return memo[m, n];

        int upward = UniquePathsMemo(m - 1, n, memo);
        int leftward = UniquePathsMemo(m, n - 1, memo);

        memo[m, n] = upward + leftward;
        return memo[m, n];
    }

    public static int UniquePathsDP(int m, int n)
    {
        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                {
                    dp[i, j] = 1;
                    continue;
                }

                int left = 0;
                int up = 0;

                if (i > 0) up = dp[i - 1, j];
                if (j > 0) left = dp[i, j - 1];

                dp[i, j] = left + up;
            }
        }

        return dp[m - 1, n - 1];
    }

    public static void Main(string[] args)
    {
        
    }
}