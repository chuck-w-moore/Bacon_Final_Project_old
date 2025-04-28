/*
 * File Name : Solution #522.cs
 * Student Name: Kush Patel
 * email: patel5k9@mail.uc.edu
 * Assignment Number: Final Project
 * Due Date: 4/29/2025
 * Course #/Section: IS3050-001
 * Semester/Year:  Spring 2025
 * Brief Description of the assignment: Solve four leetcode problems and have the .net website 
 * print the solution of each leetcode problem.
 * Citations: 
 * chatpgt.com
 * https://leetcode.com/
 * Anything else thats relevant: 
 */



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

            const int MOD = 1_000_000_007;

            public int CheckRecord(int n)
            {
                // dp[a][l]: a = 0 or 1 A used, l = 0 to 2 consecutive L's
                long[,] dp = new long[2, 3];
                dp[0, 0] = 1;

                for (int day = 0; day < n; day++)
                {
                    long[,] prev = (long[,])dp.Clone();

                    // Append 'P' (resets L streak)
                    dp[0, 0] = (prev[0, 0] + prev[0, 1] + prev[0, 2]) % MOD;

                    // Append 'L' (from previous L count 0 to 1, and 1 to 2)
                    dp[0, 1] = prev[0, 0];
                    dp[0, 2] = prev[0, 1];

                    // Append 'A' or 'P' to 1-A record
                    dp[1, 0] = (prev[0, 0] + prev[0, 1] + prev[0, 2] +
                                prev[1, 0] + prev[1, 1] + prev[1, 2]) % MOD;

                    // Append 'L' to 1-A records
                    dp[1, 1] = prev[1, 0];
                    dp[1, 2] = prev[1, 1];
                }

                // Sum all valid combinations
                long total = 0;
                for (int a = 0; a <= 1; a++)
                    for (int l = 0; l <= 2; l++)
                        total = (total + dp[a, l]) % MOD;

                return (int)total;
            }

            // For testing
            public static void Main()
            {
                var sol = new Solution();
                int n = 4;
                Console.WriteLine("Number of valid attendance records of length is " + sol.CheckRecord(n));
            }
        }

    }
}