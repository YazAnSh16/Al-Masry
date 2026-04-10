<%@ Page Title="عرض بيانات الطالب" Language="C#" MasterPageFile="~/Site1.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AL_Masry.ShowStudentData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            max-width: 1000px;
            margin: auto;
            padding: 15px;
        }
        .form-group {
            margin-bottom: 15px;
            display: flex;
            align-items: center;
            flex-wrap: wrap;
        }
        .form-group label {
            margin-left: 10px;
            font-weight: bold;
        }
        .btn-display {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 8px 15px;
            cursor: pointer;
            font-size: 15px;
            border-radius: 5px;
            margin-right: 10px;
        }
        .btn-display:hover {
            background-color: #0056b3;
        }

        /* ✅ بطاقة الطالب */
        .student-card {
            display: flex;
            justify-content :center;
            align-items: center;
            background: #ffffff;
            border: 1px solid #ddd;
            border-radius: 12px;
            padding: 20px;
            margin-top: 20px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
        .student-card img {
            
            width: 200px;
            height: 200px;
            object-fit: cover;
            border-radius: 50%;
            margin-left: 20px;
            margin-right : 200px;
            border: 3px solid #007bff;
        }
        .student-info {
            flex: 1;
        }
        .student-info h3 {
            margin: 0 0 10px 0;
            color: #007bff;
        }
        .student-info p {
            margin: 5px 0;
            font-size: 15px;
        }

        /* ✅ الجداول */
        .grid-container {
            margin-top: 25px;
        }
        .grid-container h3 {
            text-align: center;
            margin-bottom: 10px;
            color: #333;
        }
        .table-wrapper {
            width: 100%;
            overflow-x: auto;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            min-width: 500px;
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

        /* ✅ موبايل */
        @media (max-width: 768px) {
            .form-group {
                flex-direction: column;
                align-items: flex-start;
            }
            .btn-display {
                margin-top: 10px;
                width: 100%;
            }
            .student-card {
                flex-direction: column;
                text-align: center;
            }
            .student-card img {
                margin: 0 0 15px 0;
            }
        }

        /* جدول المدفوعات */
        .table-payment th {
            background-color: #fde68a;
            font-weight: bold;
        }
        .table-payment tr:nth-child(even) {
            background-color: #f9fafb;
        }
        .table-payment tr:hover {
            background-color: #fef3c7;
        }
        .auto-style5 {
            display: flex;
            direction: rtl;
            align-items: flex-start;
            justify-items : stretch;
            justify-content : center;
            flex-wrap: wrap;
            flex-direction: row;
            text-align: center;
            margin-bottom: 15px;
        }
        .auto-style6 {
            font-size: x-large;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <!-- إدخال رقم الطالب -->
        <div class="auto-style5">
            <label for="txtStudentID"><span class="auto-style6">ادخل رقم الطالب: </span></label>
            &nbsp;<asp:TextBox ID="txtStudentID" runat="server" CssClass="form-control" Width="200px" Font-Size="16pt"></asp:TextBox>
            <asp:Button ID="btnDisplay" runat="server" Text="عرض" CssClass="btn-display" OnClick="btnDisplay_Click" Font-Size="14pt" />
        </div>

        <!-- ✅ بطاقة الطالب -->
        <asp:Panel ID="PanelStudentCard" runat="server" Visible="false" CssClass="student-card">
            <asp:Image ID="imgStudent" runat="server" ImageUrl="~/images/default.png" AlternateText="صورة الطالب" />
            <div class="student-info">
                <h3><asp:Label ID="lblName" runat="server" Text="اسم الطالب"></asp:Label></h3>
                <p><strong>رقم الطالب:</strong> <asp:Label ID="lblID" runat="server"></asp:Label></p>
                <p><strong>الهاتف:</strong> <asp:Label ID="lblClass" runat="server"></asp:Label></p>
                <p><strong>العمر:</strong> <asp:Label ID="lblAge" runat="server"></asp:Label></p>
            </div>
        </asp:Panel>

        <!-- باقي الجداول -->
        <div class="grid-container">
            <h3>الحضور والغياب</h3>
            <div class="table-wrapper">
                <asp:GridView ID="GridViewAttendance" runat="server" AutoGenerateColumns="false">

                    <Columns>
                         <asp:BoundField DataField="AbsenceResults" HeaderText="التفقد" />
                          
                         <asp:BoundField DataField="CreatedAt" HeaderText="التاريخ" />
                         
                            </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="grid-container">
            <h3>المواد ونتائجها</h3>
            <div class="table-wrapper">
                <asp:GridView ID="GridViewTests" runat="server" AutoGenerateColumns="false">

                               <Columns>
                         <asp:BoundField DataField="TestObject" HeaderText="المادة" />
                          <asp:BoundField DataField="TestResults" HeaderText="النتيجة" />
                         <asp:BoundField DataField="TestDate" HeaderText="التاريخ" />
                         
                            </Columns>

                </asp:GridView>
            </div>
        </div>

        <div class="grid-container">
            <h3>المدفوعات</h3>
            <div class="table-wrapper">
                <asp:GridView ID="GridViewPayments" runat="server" AutoGenerateColumns="false" CssClass="table-payment">
                    <Columns>
                        <asp:BoundField DataField="CreatedAt" HeaderText="تاريخ الدفع" />
                        <asp:BoundField DataField="PaidAmount" HeaderText="المبلغ المدفوع" />
                        <asp:BoundField DataField="TotalAmount" HeaderText="المبلغ الكلي" />
                        <asp:BoundField DataField="Remaining" HeaderText="المتبقي" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
