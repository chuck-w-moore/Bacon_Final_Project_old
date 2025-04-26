/*
# File Name : Webform1.aspx.cs
# Student Name: Chuck Moore, Kush Patel, Max Miller, Caleb Heideman
# email:  moore3cw@mail.uc.edu, patel5k9@mail.uc.edu, heideman@mail.uc.edu, mille6mx@mail.uc.edu
# Assignment Number: Final Project
# Due Date: 4/29/2025
# Course #/Section: IS3050-001
# Semester/Year:  Spring 2025
# Brief Description of the assignment: Solve four leetcode problems and have the .net website 
# print the solution of each leetcode problem.
# Citations: 
# chatpgt.com
# https://leetcode.com/
# Anything Else Important: 

 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bacon_Final_Project
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRun_Click(object sender, EventArgs e)
        {
            string selectedValue = Request.Form["ddlProblems"];


            // Clear previous output
            lblProblemDescription.Text = "";
            lblTestCase.Text = "";
            lblSolution.Text = "";

            switch (selectedValue)
            {
                case "2127":
                    lblProblemDescription.Text = "Problem #2127 - Maximum Invitations to a Meeting: "
                        + "A company is organizing a meeting and has a list of n employees, waiting to be invited. " +
                        "They have arranged for a large circular table, capable of seating any number of employees. " +
                        "The employees are numbered from 0 to n - 1. " +
                        "Each employee has a favorite person and they will attend the meeting only if they can sit next to their favorite person at the table. " +
                        "The favorite person of an employee is not themself. " +
                        "Given a 0-indexed integer array favorite, where favorite[i] denotes the favorite person of the ith employee, " +
                        "return the maximum number of employees that can be invited to the meeting."
                        ;
                    int[] favorite2127 = { 2, 2, 1, 2 };
                    lblTestCase.Text = "Input: favorite = [2, 2, 1, 2]";
                    var sol2127 = new Solution__2127();
                    lblSolution.Text = "Output: " + sol2127.MaximumInvitations(favorite2127);
                    break;

                case "2179":
                    lblProblemDescription.Text = "Problem #2179 - Count Good Triplets in an Array: "
                        + " You are given two 0-indexed arrays nums1 and nums2 of length n," +
                        " both of which are permutations of [0, 1, ..., n - 1]. " +
                        "A good triplet is a set of 3 distinct values which are present in increasing order by position both in nums1 and nums2. " +
                        "In other words, if we consider pos1v as the index of the value v in nums1 and pos2v as the index of the value v in nums2, " +
                        "then a good triplet will be a set (x, y, z) where 0 <= x, y, z <= n - 1, such that pos1x < pos1y < pos1z and pos2x < pos2y < pos2z." +
                        "Return the total number of good triplets.";
                    int[] nums1 = { 2, 0, 1 };
                    int[] nums2 = { 2, 0, 1 };  // example input for comparison
                    lblTestCase.Text = "Input: nums1 = [2,0,1], nums2 = [2,0,1]";
                    var sol2179 = new Solution();  // ⚠️ this is the correct class!
                    lblSolution.Text = "Output: " + sol2179.GoodTriplets(nums1, nums2);
                    break;



                case "2338":
                    lblProblemDescription.Text = "Problem #2338 - Count the Number of Ideal Arrays: " +
                        "You are given two integers n and maxValue, which are used to describe an ideal array. " +
                        "A 0-indexed integer array arr of length n is considered ideal if the following conditions hold: " +
                        "Every arr[i] is a value from 1 to maxValue, for 0 <= i < n. " +
                        "Every arr[i] is divisible by arr[i - 1], for 0 < i < n. " +
                        "Return the number of distinct ideal arrays of length n. Since the answer may be very large, " +
                        "return it modulo 109 + 7.";
                    int n2338 = 5, maxValue2338 = 3;
                    lblTestCase.Text = "Input: n = 5, maxValue = 3";
                    var sol2338 = new Solution__2338();
                    lblSolution.Text = "Output: " + sol2338.IdealArrays(n2338, maxValue2338);
                    break;

                case "552":
                    lblProblemDescription.Text = "Problem #552 - Student Attendance Record II: " +
                        "An attendance record for a student can be represented as a string where each character signifies whether the student was absent, " +
                        "late, or present on that day. The record only contains the following three characters: " +
                        "'A': Absent. 'L': Late. 'P': Present. " +
                        "Any student is eligible for an attendance award if they meet both of the following criteria: " +
                        "The student was absent ('A') for strictly fewer than 2 days total. " +
                        "The student was never late ('L') for 3 or more consecutive days. " +
                        "Given an integer n, return the number of possible attendance records of length n that make a student eligible for an attendance award. " +
                        "The answer may be very large, so return it modulo 109 + 7.";
                    int n552 = 2;
                    lblTestCase.Text = "Input: n = 2";
                    var sol552 = new Solution__552.Solution();  // ✅ inner class!
                    lblSolution.Text = "Output: " + sol552.CheckRecord(n552);
                    break;




                default:
                    lblProblemDescription.Text = "Please select a problem from the dropdown.";
                    break;
            }
        }
    }
}