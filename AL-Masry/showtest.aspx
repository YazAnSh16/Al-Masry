<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="showtest.aspx.cs" Inherits="AL_Masry.showtest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*body {
            font-family: 'Segoe UI', Tahoma, Arial;
            background: #f9fafb;
            margin: 0;
            padding: 0;
        }
*/
        h1 {
            text-align: center;
            color: #1f2937;
            margin-bottom: 1rem;
        }

        .form-container33 {
            max-width: 1000px;
            margin: 2rem auto;
            background: #fff;
            padding: 2rem;
            border-radius: 1rem;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
        }

        .form-grid33 {
            display: grid;
            grid-template-columns: 200px 1fr;
            gap: 0.8rem 1.5rem;
            align-items: center;
        }

        label {
            text-align: right;
            font-weight: 600;
            color: #374151;
        }

        input, select, .aspNet-TextBox, .aspNet-DropDownList {
            width: 100%;
            padding: 0.5rem;
            border-radius: 0.5rem;
            border: 1px solid #d1d5db;
            box-sizing: border-box;
        }

        .radio-group {
            display: flex;
            gap: 1rem;
            align-items: center;
        }

        .btn-group {
            display: flex;
            justify-content: center;
            gap: 1rem;
            margin: 1.5rem 0;
        }

        .btn {
            background: #2563eb;
            color: #fff;
            padding: 0.6rem 1.2rem;
            border-radius: 0.5rem;
            border: none;
            cursor: pointer;
            transition: 0.3s;
        }

        .btn:hover {
            background: #1e40af;
        }

        .grid-title {
            margin-top: 2rem;
            font-size: 1.2rem;
            font-weight: bold;
            color: #111827;
        }

        .gridview {
            margin-top: 0.5rem;
            overflow-x: auto;
        }

        .gridview table {
            width: 100%;
            border-collapse: collapse;
            min-width: 400px;
        }

        .gridview th, .gridview td {
            border: 1px solid #d1d5db;
            padding: 0.5rem;
            text-align: center;
        }

        .gridview th {
            background: #f3f4f6;
        }

        @media(max-width: 700px) {
            .form-grid {
                grid-template-columns: 1fr;
            }

            .btn-group {
                flex-direction: column;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container33" dir="rtl">
        <h1>بيانات الطلاب</h1>

        <!-- نموذج البيانات الأساسية -->
        <div class="form-grid33">
            <label>رقم الطالب :</label>
            <asp:TextBox ID="TextBox13" runat="server" TextMode="Number" />

            <label>الاسم والشهرة :</label>
            <asp:TextBox ID="TextBox1" runat="server" />

            <label>مكان الولادة :</label>
            <asp:TextBox ID="TextBox2" runat="server" />

            <label>تاريخ الولادة :</label>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Date" />

            <label>مكان السكن :</label>
            <asp:TextBox ID="TextBox4" runat="server" />

            <label>عمل الأب :</label>
            <asp:TextBox ID="TextBox5" runat="server" />

            <label>عمل الأم :</label>
            <asp:TextBox ID="TextBox6" runat="server" />

            <label>مجموع الصف الحادي عشر :</label>
            <asp:TextBox ID="TextBox7" runat="server" TextMode="Number" />

            <label>مجموع الصف التاسع :</label>
            <asp:TextBox ID="TextBox8" runat="server" TextMode="Number" />

            <label>الهاتف الأرضي :</label>
            <asp:TextBox ID="TextBox9" runat="server" TextMode="Number" />

            <label>جوال الطالب :</label>
            <asp:TextBox ID="TextBox10" runat="server" TextMode="Number" />

            <label>جوال الأب :</label>
            <asp:TextBox ID="TextBox11" runat="server" TextMode="Number" />

            <label>جوال الأم :</label>
            <asp:TextBox ID="TextBox12" runat="server" TextMode="Number" />

            <label>حضور اليوم :</label>
            <div class="radio-group">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">حضور</asp:ListItem>
                    <asp:ListItem Value="1">غياب</asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <label>مادة الاختبار :</label>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>الرياضيات</asp:ListItem>
                <asp:ListItem>الفيزياء</asp:ListItem>
                <asp:ListItem>الكيمياء</asp:ListItem>
                <asp:ListItem>العلوم</asp:ListItem>
                <asp:ListItem>اللغة العربية</asp:ListItem>
                <asp:ListItem>اللغة الفرنسية</asp:ListItem>
                <asp:ListItem>اللغة الإنكليزية</asp:ListItem>
                <asp:ListItem>التربية الدينية</asp:ListItem>
            </asp:DropDownList>

            <label>نتيجة الاختبار :</label>
            <asp:TextBox ID="TextBox15" runat="server" TextMode="Number" />

            <label>تاريخ اليوم :</label>
            <asp:TextBox ID="TextBox16" runat="server" TextMode="Date" />
        </div>

        <!-- أزرار التحكم -->
        <div class="btn-group">
            <asp:Button ID="btnDelete" runat="server" CssClass="btn" Text="حذف" OnClick="btnDelete_Click" />
            <asp:Button ID="btnEdite" runat="server" CssClass="btn" Text="تعديل" OnClick="btnEdite_Click" />
            <asp:Button ID="btnShow" runat="server" CssClass="btn" Text="عرض" OnClick="btnShow_Click" />
        </div>

        <!-- GridViews للأقسام الأربعة -->
        <div class="grid-title">الطلاب</div>
        <div class="gridview">
            <asp:GridView ID="GridView1" runat="server" CssClass="table"></asp:GridView>
        </div>

        <div class="grid-title">الغياب</div>
        <div class="gridview">
            <asp:GridView ID="GridView2" runat="server" CssClass="table"></asp:GridView>
        </div>

        <div class="grid-title">التسميع</div>
        <div class="gridview">
            <asp:GridView ID="GridView3" runat="server" CssClass="table"></asp:GridView>
        </div>

        <div class="grid-title">المدفوعات</div>
        <div class="form-grid33" style="margin-top:1rem;">
            <label>القيمة الكلية :</label>
            <asp:TextBox ID="TextBoxTotalPayment" runat="server" />

            <label>المبلغ المدفوع الآن :</label>
            <asp:TextBox ID="TextBoxPaidNow" runat="server" />

            <asp:Button ID="ButtonAddPayment" runat="server" CssClass="btn" Text="إضافة الدفع" OnClick="ButtonAddPayment_Click"  />
        </div>

        <div class="gridview" style="margin-top:1rem;">
            <asp:GridView ID="GridViewPayments" runat="server" CssClass="table"></asp:GridView>
        </div>
    </div>
</asp:Content>
