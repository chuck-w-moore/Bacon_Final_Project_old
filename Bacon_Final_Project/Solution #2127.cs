/*
 * File Name : Solution #2127.cs
 * Student Name: Chuck Moore
 * email: moore3cw@mail.uc.edu
 * Assignment Number: Final Project
 * Due Date: 4/29/2025
 * Course #/Section: IS3050-001
 * Semester/Year:  Spring 2025
 * Brief Description of the assignment: Solve a leetcode problem and use a button to print the solution.
 * Citations: 
 * chatgpt.com
 * https://leetcode.com/
 * Anything else thats relevant: 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

enum State { Init, Visiting, Visited }

namespace Bacon_Final_Project
{
    public class Solution__2127
    {
        public int MaximumInvitations(int[] favorite)
        {
            int n = favorite.Length;
            int sumComponentsLength = 0; // the component: a -> b -> c <-> x <- y
            List<int>[] graph = new List<int>[n];
            int[] inDegrees = new int[n];
            int[] maxChainLength = new int[n];
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; ++i)
            {
                graph[i] = new List<int>();
                maxChainLength[i] = 1;
            }

            // Build the graph.
            for (int i = 0; i < n; ++i)
            {
                graph[i].Add(favorite[i]);
                inDegrees[favorite[i]]++;
            }

            // Perform topological sorting.
            for (int i = 0; i < n; ++i)
            {
                if (inDegrees[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                foreach (int v in graph[u])
                {
                    if (--inDegrees[v] == 0)
                    {
                        queue.Enqueue(v);
                    }
                    maxChainLength[v] = Math.Max(maxChainLength[v], 1 + maxChainLength[u]);
                }
            }

            for (int i = 0; i < n; ++i)
            {
                if (favorite[favorite[i]] == i)
                {
                    // i <-> favorite[i] (the cycle's length = 2)
                    sumComponentsLength += maxChainLength[i] + maxChainLength[favorite[i]];
                }
            }

            int maxCycleLength = 0; // the cycle : a -> b -> c -> a
            int[] parent = new int[n];
            bool[] seen = new bool[n];
            State[] states = new State[n];

            for (int i = 0; i < n; ++i)
            {
                if (!seen[i])
                {
                    FindCycle(graph, i, parent, seen, states, ref maxCycleLength);
                }
            }

            return Math.Max(sumComponentsLength / 2, maxCycleLength);
        }

        private void FindCycle(List<int>[] graph, int u, int[] parent, bool[] seen, State[] states, ref int maxCycleLength)
        {
            seen[u] = true;
            states[u] = State.Visiting;

            foreach (int v in graph[u])
            {
                if (!seen[v])
                {
                    parent[v] = u;
                    FindCycle(graph, v, parent, seen, states, ref maxCycleLength);
                }
                else if (states[v] == State.Visiting)
                {
                    // Find the cycle's length.
                    int curr = u;
                    int cycleLength = 1;
                    while (curr != v)
                    {
                        curr = parent[curr];
                        cycleLength++;
                    }
                    maxCycleLength = Math.Max(maxCycleLength, cycleLength);
                }
            }

            states[u] = State.Visited;
        }
    }

}