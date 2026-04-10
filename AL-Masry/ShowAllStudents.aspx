<%@ Page Title="عرض جميع الطلاب" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeBehind="ShowAllStudents.aspx.cs" Inherits="AL_Masry.ShowAllStudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container99 {
            max-width: 1200px;
            margin: auto;
            padding: 15px;
        }
        h2 {
            text-align: center;
            margin: 20px 0;
            color: #007bff;
        }
        .table-wrapper {
            width: 100%;
            overflow-x: auto;
            margin-bottom: 40px;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            min-width: 600px;
        }
        table th, table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
            white-space: nowrap;
        }
        table th {
            background-color: #f2f2f2;
        }
        .table-payment th {
            background-color: #fde68a;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container99">
        <h2>جميع الطلاب<asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        </h2>

        <div class="table-wrapper">
            <h3>البيانات الأساسية</h3>
            <asp:GridView ID="GridViewStudents" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>

        <div class="table-wrapper">
            <h3>الحضور والغياب</h3>
            <asp:GridView ID="GridViewAttendance" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>

        <div class="table-wrapper">
            <h3>المواد ونتائجها</h3>
            <asp:GridView ID="GridViewTests" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>

        <div class="table-wrapper">
            <h3>المدفوعات</h3>
            <asp:GridView ID="GridViewPayments" runat="server" AutoGenerateColumns="true" CssClass="table-payment"></asp:GridView>
        </div>
    </div>
</asp:Content>
