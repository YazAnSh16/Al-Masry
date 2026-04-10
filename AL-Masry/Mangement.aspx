<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Mangement.aspx.cs" Inherits="AL_Masry.Mangement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        /* 🎨 الألوان والخطوط الأساسية */
:root {
    --primary: #0077b6;
    --secondary: #0096c7;
    --success: #03fc6b;
    --danger: #ff3300;
    --text-dark: #333;
    --text-light: #444;
    --bg-light: #f5f7fa;
    --shadow: 0 4px 12px rgba(0,0,0,0.1);
}

body {
    font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
    background: var(--bg-light);
    margin: 0;
    padding: 0;
}

/* 📌 عناوين وأسلوب عام */
h1, h2 {
    text-align: center;
    margin-bottom: 1rem;
    color: var(--primary);
}
h1 { font-size: 26px; }
h2 { font-size: 22px; }

/* ========== الأزرار ========== */
.btn {
    background: linear-gradient(90deg, var(--primary), var(--secondary));
    color: #fff;
    border: none;
    padding: 12px 30px;
    font-size: 16px;
    border-radius: 8px;
    cursor: pointer;
    transition: 0.3s;
}
.btn:hover {
    background: linear-gradient(90deg, var(--secondary), var(--primary));
    transform: translateY(-2px);
}
.btn-wide { width: 100%; }

/* زر خاص للحفظ */
.btn-save { background: linear-gradient(90deg, var(--primary), var(--secondary)); }

/* زر خاص للإضافة */
.btn-add { background: linear-gradient(90deg, var(--primary), var(--secondary)); }

/* زر خاص للتصفح */
.btn-browse { background: linear-gradient(90deg, var(--primary), var(--secondary)); }

/* زر خاص للتقارير اليومية */
.btn-daily { background: linear-gradient(90deg, var(--primary), var(--secondary)); }

/* ========== فورم تسجيل الدخول ========== */
.login-container {
    max-width: 450px;
    width: 90%;
    margin: 60px auto;
    background: #fff;
    padding: 25px;
    border-radius: 15px;
    box-shadow: var(--shadow);
    text-align: center;
}
.login-container h1 {
    font-size: 26px;
    margin-bottom: 25px;
    color: var(--text-dark);
}
.form-group {
    margin-bottom: 20px;
    text-align: right;
    display: flex;
    flex-direction: column;
}
label {
    display: block;
    font-size: 16px;
    margin-bottom: 6px;
    color: var(--text-light);
    font-weight: 500;
}
input, select, .asp-textbox, .aspNet-TextBox, .aspNet-DropDownList {
    width: 100%;
    padding: 12px;
    font-size: 16px;
    border: 1px solid #ccc;
    border-radius: 8px;
    outline: none;
    box-sizing: border-box;
}
input:focus, .asp-textbox:focus {
    border-color: var(--primary);
    box-shadow: 0 0 6px rgba(0,119,182,0.3);
}

/* زر ASP */
.asp-button {
    width: 100%;
    padding: 14px;
    font-size: 18px;
    border: none;
    border-radius: 10px;
    background: var(--success);
    color: #fff;
    cursor: pointer;
    transition: 0.3s;
}
.asp-button:hover { background: #0056b3; }

/* ========== فورم عام ========== */
.form-container, .form-container33 {
    max-width: 1000px;
    margin: 2rem auto;
    background: #fff;
    padding: 2rem;
    border-radius: 1rem;
    box-shadow: var(--shadow);
}
.form-container h1, .form-container33 h1 {
    color: var(--primary);
    margin-bottom: 25px;
}

/* شبكة الفورم */
.form-grid33 {
    display: grid;
    grid-template-columns: 200px 1fr;
    gap: 0.8rem 1.5rem;
    align-items: center;
}

/* ✅ رفع صورة شخصية */
.profile-upload { text-align: center; margin-bottom: 25px; }
.profile-pic {
    width: 200px; height: 200px;
    border-radius: 50%;
    object-fit: cover;
    border: 3px solid var(--primary);
    margin-bottom: 10px;
}

/* زرار الإجراءات */
.btn-group {
    display: flex;
    justify-content: center;
    gap: 1rem;
    margin: 1.5rem 0;
}
.btn-group .btn { min-width: 120px; }

/* ========== الجداول ========== */
.table-wrapper { width: 100%; overflow-x: auto; margin-bottom: 40px; }
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
table th { background: #f2f2f2; }
.table-payment th { background: #fde68a; }

/* GridView ASP.NET */
.gridview {
    margin-top: 0.5rem;
    overflow-x: auto;
}
.gridview table { min-width: 400px; }
.gridview th { background: #f3f4f6; }

.auto-style99
{
    color: #fff;
    display :flex;
    margin : 15px;
    justify-content : space-around;
    flex-direction :row;
    color : white;
            text-align: left;
        }

/* ========== Responsive ========== */
@media (max-width: 768px) {
    .login-container, .form-container, .form-container33 {
        margin: 20px;
        padding: 20px;
    }
    h1 { font-size: 22px; }
    label { font-size: 14px; }
    .btn, .asp-button { font-size: 16px; padding: 12px; }
    .form-grid33 { grid-template-columns: 1fr; }
    .btn-group { flex-direction: column; }
}

       .btn-previwe
       {
           background-color : dodgerblue;
           color : #FFFFFF;
       }
        .auto-style100 {
            
            display :flex;
            justify-content : space-around;
            flex-direction :row
            ;
            margin : 15px;
            background-color :deepskyblue;
            color : #FFFFFF;
        }

       
        .auto-style101 {
            padding : 3px;
            text-align: center;
            background-color : dodgerblue;
            font-size : large;
            color : white;
        }
        .btn-danger{
            color : white;
            background-color : red;
        }

       
    </style>

    <script type="text/javascript">
        function previewImage(input, imageId) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    document.getElementById(imageId).src = e.target.result;
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div class="form-container" dir="rtl">
            <h1>بيانات الطلاب</h1>
            <!-- صورة شخصية -->
            <div class="profile-upload">
                <asp:Image ID="imgProfile" runat="server" CssClass="profile-pic" ImageUrl="~/images/default-profile.png" />
                <br />
                <asp:FileUpload ID="fuProfilePic" runat="server" />
                <asp:Button ID="btnPreview" runat="server" Text="عرض الصورة" OnClick="btnPreview_Click" CssClass="btn-previwe" />
            </div>
            <div class="auto-style101">
                <asp:Label ID="lblStudentID" runat="server" Text=""></asp:Label>
            </div>
            <!-- الحقول -->
            <div class="form-group">
                &nbsp;</div>
            <div class="form-group">
                <label>
                الاسم والشهرة :</label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                مكان الولادة :</label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                تاريخ الولادة :</label>
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                مكان السكن :</label>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                عمل الاب :</label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                عمل الام :</label>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                مجموع الطالب في الصف الحادي عشر :</label>
                <asp:TextBox ID="TextBox7" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                مجموع الطالب في الصف التاسع :</label>
                <asp:TextBox ID="TextBox8" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                الهاتف الارضي :</label>
                <asp:TextBox ID="TextBox9" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                جوال الطالب :</label>
                <asp:TextBox ID="TextBox10" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                جوال الاب :</label>
                <asp:TextBox ID="TextBox11" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                جوال الام :</label>
                <asp:TextBox ID="TextBox12" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
            <!-- زر الحفظ -->
            <div class="form-submit">
                <asp:Button ID="btnSave" runat="server" Text="حفظ البيانات" CssClass="btn-save" OnClick="btnSave_Click" />
            </div>
            <!-- عرض رقم الطالب الجديد بعد الحفظ -->
        </div>
    </asp:Panel>



    <%--<asp:Panel ID="Panel2" runat="server">
    <div class="auto-style9">
        <strong>
        <asp:Label ID="Label52" runat="server" CssClass="auto-style66" Text=" ! قسم خاص بالادارة"></asp:Label>
        <br />
        </strong>
        <asp:Label ID="Label53" runat="server" CssClass="auto-style7" Text="الرجاء تسجيل الدخول اولا"></asp:Label>
    </div>
</asp:Panel>--%>



    <asp:Panel ID="PanelChoose" runat="server">
       <div class="auto-style99">
           
    <asp:Button ID="BtnDaily" runat="server" Text="تعديل البيانات" CssClass="auto-style100" OnClick="BtnDaily_Click" />
    <asp:Button ID="btnBrowse" runat="server" Text="سجل الطلاب" CssClass="auto-style100" OnClick="btnBrowse_Click"/>
    <asp:Button ID="btnAdd" runat="server" Text="تسجيل طالب جديد" CssClass="auto-style100" OnClick="btnAdd_Click"/>
            </div>
      </asp:Panel>




    <asp:Panel ID="PanelLogin" runat="server">

         <div class="login-container">
     <h1>تسجيل الدخول</h1>
     <div class="form-group">
         <label for="txtUser" class="auto-style1"> : اسم المستخدم</label>
         <asp:TextBox ID="txtUser" runat="server" CssClass="asp-textbox"></asp:TextBox>
     </div>

     <div class="form-group">
         <label for="txtPass" dir="rtl" class="auto-style661">كلمة المرور : </label>
         <asp:TextBox ID="txtPass" runat="server" CssClass="asp-textbox" TextMode="Password"></asp:TextBox>
     </div>

     <asp:Button ID="Button1" runat="server" Text="تسجيل" CssClass="asp-button" OnClick="Button1_Click"  />
 </div>

        </asp:Panel>





    <asp:Panel ID="PanelShowAll" runat="server">
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
        </asp:Panel>


    <asp:Panel ID="PanelEdite" runat="server">
        <div class="form-container33" dir="rtl">
    <h1>بيانات الطلاب</h1>

    <!-- نموذج البيانات الأساسية -->
    <div class="form-grid33">
        <label>رقم الطالب :</label>
        <asp:TextBox ID="TextBox14" runat="server" TextMode="Number" />

        <label>الاسم والشهرة :</label>
        <asp:TextBox ID="TextBox15" runat="server" />

        <label>مكان الولادة :</label>
        <asp:TextBox ID="TextBox16" runat="server" />

        <label>تاريخ الولادة :</label>
        <asp:TextBox ID="TextBox17" runat="server" TextMode="Date" />

        <label>مكان السكن :</label>
        <asp:TextBox ID="TextBox18" runat="server" />

        <label>عمل الأب :</label>
        <asp:TextBox ID="TextBox19" runat="server" />

        <label>عمل الأم :</label>
        <asp:TextBox ID="TextBox20" runat="server" />

        <label>مجموع الصف الحادي عشر :</label>
        <asp:TextBox ID="TextBox21" runat="server" TextMode="Number" />

        <label>مجموع الصف التاسع :</label>
        <asp:TextBox ID="TextBox22" runat="server" TextMode="Number" />

        <label>الهاتف الأرضي :</label>
        <asp:TextBox ID="TextBox23" runat="server" TextMode="Number" />

        <label>جوال الطالب :</label>
        <asp:TextBox ID="TextBox24" runat="server" TextMode="Number" />

        <label>جوال الأب :</label>
        <asp:TextBox ID="TextBox25" runat="server" TextMode="Number" />

        <label>جوال الأم :</label>
        <asp:TextBox ID="TextBox26" runat="server" TextMode="Number" />

        <label>حضور اليوم :</label>
        <div class="radio-group">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">حضور</asp:ListItem>
                <asp:ListItem Value="1">غياب</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <label>مادة الاختبار :</label>
        <asp:DropDownList ID="DropDownList1" runat="server" >
            <asp:ListItem>لايوجد اختبار</asp:ListItem>
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
        <asp:TextBox ID="TextBox27" runat="server" />

        <label>تاريخ اليوم :</label>
        <asp:TextBox ID="TextBox28" runat="server" TextMode="Date" />
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
        <br />
        <h3>حذف الدفع</h3>
         <br />
        
        <label>ادخل رقم الدفع المراد حذفه :</label>
        <asp:TextBox ID="TextBoxDeletePaymentID" runat="server" CssClass="form-control" />
         <asp:Button ID="ButtonDeletePayment" runat="server" Text="حذف الدفع" CssClass="btn-danger" OnClick="ButtonDeletePayment_Click"  />
    <br />

   
        <%--<asp:Button ID="ButtonDeletePayment" runat="server" CssClass="btn" Text="حذف دفع"  />
        <asp:TextBox ID="TextBoxdelete" runat="server" />--%>
    </div>

    <div class="gridview" style="margin-top:1rem;">
        <asp:GridView ID="GridViewPayments1" runat="server" CssClass="table"></asp:GridView>
    </div>
</div>
        </asp:Panel>

</asp:Content>
