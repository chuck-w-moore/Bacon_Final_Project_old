using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bacon_Final_Project
{
    public class Solution__552
    {
        public class Solution
        {
            const int MOD = 1000000007;

            public int CheckRecord(int n)
            {
                // dp[a][l]: Number of valid sequences of length i with `a` A's and ending in `l` consecutive L's
                long[,,] dp = new long[n + 1, 2, 3];  // i, A (0 or 1), L (0 to 2)
                dp[0, 0, 0] = 1;  // base case: empty string is valid

                for (int i = 1; i <= n; i++)
                {
                    for (int a = 0; a <= 1; a++)
                    {
                        for (int l = 0; l <= 2; l++)
                        {
                            // Add 'P' - resets L streak
                            dp[i, a, 0] = (dp[i, a, 0] + dp[i - 1, a, l]) % MOD;

                            // Add 'A' - only if no 'A' used yet
                            if (a > 0)
                                dp[i, 1, 0] = (dp[i, 1, 0] + dp[i - 1, 0, l]) % MOD;

                            // Add 'L' - only if L streak < 2
                            if (l < 2)
                                dp[i, a, l + 1] = (dp[i, a, l + 1] + dp[i - 1, a, l]) % MOD;
                        }
                    }
                }

                long result = 0;
                for (int a = 0; a <= 1; a++)
                    for (int l = 0; l <= 2; l++)
                        result = (result + dp[n, a, l]) % MOD;

                return (int)result;
            }

            // Test the function
            public static void Main()
            {
                var sol = new Solution();
                int n = 4;  // Example
                Console.WriteLine($"Number of valid records of length {n}: {sol.CheckRecord(n)}");
            }
        }
    }
}