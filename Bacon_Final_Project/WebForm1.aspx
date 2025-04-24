<%-- 
# File Name : Webform1.aspx
# Student Name: Chuck Moore, Kush Patel, Max Miller, Caleb Heideman
# email:  moore3cw@mail.uc.edu, patel5k9@mail.uc.edu, heideman@mail.uc.edu, mille6mx@mail.uc.edu
# Assignment Number: Final Project
# Due Date: 4/29/2025
# Course #/Section: IS3050-001
# Semester/Year: Spring 2025
# Brief Description of the assignment: Solve four leetcode problems and have the .net website 
# print the solution of each leetcode problem.
# Citations: 
# chatpgt.com
# https://leetcode.com/
# Anything Else Important: 
--%>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Bacon_Final_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>IS3050 Final Project - LeetCode Solutions</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>

    .baconH {
    display: inline-block; 
    background-color: orange;
    padding: 0.2em 0.5em;   
    border-radius: 5px;     
    color: white;}

    .names {
    display: inline-block;
    background-color: #007BFF;
    padding: 0.2em 0.5em;
    border-radius: 4px;
    color: white;
    font-weight: bold;}

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="baconH">Team Bacon</h1>
            <br />
            <div class="names">Chuck Moore, Max Miller, Caleb Heideman, Kush Patel</div>
            <br />
            <div class="dropdown mb-3">
                <asp:DropDownList ID="ddlProblems" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Select a LeetCode Problem" Value="" />
                    <asp:ListItem Text="#2127 - Maximum Invitations" Value="2127" />
                    <asp:ListItem Text="#2179 - Count Good Triplets" Value="2179" />
                    <asp:ListItem Text="#2338 - Count Distinct Elements" Value="2338" />
                    <asp:ListItem Text="#552 - Student Attendance Record II" Value="552" />
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnRun" runat="server" Text="Run Solution" CssClass="btn btn-primary" OnClick="btnRun_Click" />
            <hr />
            <div class="mb-3">
                <asp:Label ID="lblProblemDescription" runat="server" Text="" CssClass="form-text" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblTestCase" runat="server" Text="" CssClass="form-text" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblSolution" runat="server" Text="" CssClass="form-text fw-bold" />
            </div>
            
            <div>
                <asp:Image ID="imgBacon" runat="server" ImageUrl="~/bacon.jpg" AlternateText="Bacon" Width="300px" />
            </div>



        </div>
    </form>
</body>
</html>
