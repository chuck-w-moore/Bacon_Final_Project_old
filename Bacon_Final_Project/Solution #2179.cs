/*
 * File Name : Solution #2179.cs
 * Student Name: Max Miller
 * email: mille6mx@mail.uc.edu
 * Assignment Number: Final Project
 * Due Date: 4/29/2025
 * Course #/Section: IS3050-001
 * Semester/Year:  Spring 2025
 * Brief Description of the assignment: Solve four leetcode problems and have the .net website 
 * print the solution of each leetcode problem.
 * Citations: 
 * chatgpt.com
 * https://leetcode.com/
 * Anything else thats relevant: 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bacon_Final_Project
{
    public class Solution__2179{
        private readonly int[] sums;

        public Solution__2179(int n)
        {
            sums = new int[n + 1];
        }

        public void Add(int i, int delta)
        {
            while (i < sums.Length)
            {
                sums[i] += delta;
                i += Lowbit(i);
            }
        }

        public int Get(int i)
        {
            int sum = 0;
            while (i > 0)
            {
                sum += sums[i];
                i -= Lowbit(i);
            }
            return sum;
        }

        private static int Lowbit(int i)
        {
            return i & -i;
        }
    }

    public class Solution
    {
        public long GoodTriplets(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            long ans = 0;
            var numToIndex = new Dictionary<int, int>();
            var arr = new List<int>();
            int[] leftSmaller = new int[n];
            int[] rightLarger = new int[n];
            var tree1 = new Solution__2179(n); // Calculates `leftSmaller`.
            var tree2 = new Solution__2179(n); // Calculates `rightLarger`.

            for (int i = 0; i < n; ++i)
                numToIndex[nums1[i]] = i;

            // Remap each number in `nums2` to the according index in `nums1` as `arr`.
            foreach (int num in nums2)
                arr.Add(numToIndex[num]);

            for (int i = 0; i < n; ++i)
            {
                leftSmaller[i] = tree1.Get(arr[i]);
                tree1.Add(arr[i] + 1, 1);
            }

            for (int i = n - 1; i >= 0; --i)
            {
                rightLarger[i] = tree2.Get(n) - tree2.Get(arr[i]);
                tree2.Add(arr[i] + 1, 1);
            }

            for (int i = 0; i < n; ++i)
                ans += (long)leftSmaller[i] * rightLarger[i];

            return ans;
        }
    }

}