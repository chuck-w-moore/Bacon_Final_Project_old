/*
 * File Name : Solution #2179.cs
 * Student Name: Caleb Heideman
 * email: heideman@mail.uc.edu
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
    public class Solution__2338
    {

        private const int Mod = 1_000_000_007;

        public int IdealArrays(int n, int maxValue)
        {
            int maxLength = Math.Min(14, n);
            List<List<int>> factors = GetFactors(maxValue);
            var dp = new long[maxLength + 1, maxValue + 1];
            var mem = new long[n, maxLength];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < maxLength; j++)
                    mem[i, j] = -1;

            long ans = 0;

            // Initialize dp for length 1
            for (int j = 1; j <= maxValue; j++)
                dp[1, j] = 1;

            // Fill dp table
            for (int i = 2; i <= maxLength; i++)
            {
                for (int j = 1; j <= maxValue; j++)
                {
                    foreach (int k in factors[j])
                    {
                        dp[i, j] = (dp[i, j] + dp[i - 1, k]) % Mod;
                    }
                }
            }

            // Compute dp[i, 0]
            for (int i = 1; i <= maxLength; i++)
            {
                for (int j = 1; j <= maxValue; j++)
                {
                    dp[i, 0] = (dp[i, 0] + dp[i, j]) % Mod;
                }
            }

            // Calculate the result
            for (int i = 1; i <= maxLength; i++)
            {
                ans = (ans + dp[i, 0] * NChooseK(n - 1, i - 1, mem)) % Mod;
            }

            return (int)ans;
        }

        private List<List<int>> GetFactors(int maxValue)
        {
            var factors = new List<List<int>>(maxValue + 1);
            for (int i = 0; i <= maxValue; i++)
                factors.Add(new List<int>());

            for (int i = 1; i <= maxValue; i++)
            {
                for (int j = i * 2; j <= maxValue; j += i)
                {
                    factors[j].Add(i);
                }
            }

            return factors;
        }

        private long NChooseK(int n, int k, long[,] mem)
        {
            if (k == 0 || n == k)
                return 1;

            if (mem[n, k] != -1)
                return mem[n, k];

            mem[n, k] = (NChooseK(n - 1, k, mem) + NChooseK(n - 1, k - 1, mem)) % Mod;
            return mem[n, k];
        }
    }
}