<%@ Page Title="القسم الإداري" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="AL_Masry.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
            background: #f5f7fa;
            margin: 0;
            padding: 0;
        }

        .login-container {
            max-width: 450px;
            width: 90%;
            margin: 60px auto;
            background: #fff;
            padding: 25px;
            border-radius: 15px;
            box-shadow: 0px 4px 15px rgba(0,0,0,0.1);
            text-align: center;
        }

        .login-container h1 {
            font-size: 26px;
            margin-bottom: 25px;
            color: #333;
        }

        .form-group {
            margin-bottom: 20px;
            text-align: right;
        }

        label {
            display: block;
            font-size: 16px;
            margin-bottom: 6px;
            color: #444;
        }

        .asp-textbox {
            width: 100%;
            padding: 12px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 8px;
            outline: none;
            box-sizing: border-box;
        }

        .asp-textbox:focus {
            border-color: #007bff;
            box-shadow: 0 0 6px rgba(0,123,255,0.3);
        }

        .asp-button {
            width: 100%;
            padding: 14px;
            font-size: 18px;
            border: none;
            border-radius: 10px;
            background: #03fc6b;
            color: #fff;
            cursor: pointer;
            transition: 0.3s;
        }

        .asp-button:hover {
            background: #0056b3;
        }

        /* ✅ تحسين العرض على الشاشات الصغيرة */
        @media (max-width: 768px) {
            .login-container {
                margin: 20px;
                padding: 20px;
            }

            .login-container h1 {
                font-size: 22px;
            }

            label {
                font-size: 14px;
            }

            .asp-button {
                font-size: 16px;
                padding: 12px;
            }
        }
    .auto-style1 {
        font-size: large;
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <h1>تسجيل الدخول</h1>
        <div class="form-group">
            <label for="txtUser" class="auto-style1"> : اسم المستخدم</label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="asp-textbox"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPass" dir="rtl" class="auto-style1">كلمة المرور : </label>
            <asp:TextBox ID="txtPass" runat="server" CssClass="asp-textbox" TextMode="Password"></asp:TextBox>
        </div>

        <asp:Button ID="Button1" runat="server" Text="تسجيل" CssClass="asp-button" OnClick="Button1_Click" />
    </div>
</asp:Content>
