using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
namespace AL_Masry
{
    public partial class Mangement : Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["MasryConnectionString"].ConnectionString;
        public int lastId = 0;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            byte[] imgBytes = null;
            if (fuProfilePic.HasFile)
            {
                imgBytes = fuProfilePic.FileBytes; // تحويل الصورة لبايتات
            }

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                int newId = GenerateUniqueStudentId(con);

                string query = @"INSERT INTO Students2
                                (StudentID, FullName, BirthPlace, BirthDate, Address, FatherJob, MotherJob,
                                 Grade11, Grade9, PhoneHome, PhoneStudent, PhoneFather, PhoneMother, ProfileImage)
                                 VALUES
                                (@StudentID, @FullName, @BirthPlace, @BirthDate, @Address, @FatherJob, @MotherJob,
                                 @Grade11, @Grade9, @PhoneHome, @PhoneStudent, @PhoneFather, @PhoneMother, @ProfileImage)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StudentID", newId);
                    cmd.Parameters.AddWithValue("@FullName", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@BirthPlace", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@BirthDate", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@FatherJob", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@MotherJob", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@Grade11", TextBox7.Text);
                    cmd.Parameters.AddWithValue("@Grade9", TextBox8.Text);
                    cmd.Parameters.AddWithValue("@PhoneHome", TextBox9.Text);
                    cmd.Parameters.AddWithValue("@PhoneStudent", TextBox10.Text);
                    cmd.Parameters.AddWithValue("@PhoneFather", TextBox11.Text);
                    cmd.Parameters.AddWithValue("@PhoneMother", TextBox12.Text);

                    if (imgBytes != null)
                        cmd.Parameters.Add("@ProfileImage", System.Data.SqlDbType.VarBinary, imgBytes.Length).Value = imgBytes;
                    else
                        cmd.Parameters.Add("@ProfileImage", System.Data.SqlDbType.VarBinary, -1).Value = DBNull.Value;

                    cmd.ExecuteNonQuery();
                }

                lastId = newId;
            }

            lblStudentID.Text = "رقم الطالب: " + lastId.ToString();
            Response.Write("<script>alert('تم حفظ البيانات بنجاح ✅');</script>");
        }

        private int GenerateUniqueStudentId(SqlConnection con)
        {
            Random rnd = new Random();
            int studentId;
            bool exists;

            do
            {
                studentId = rnd.Next(1000, 10000); // رقم عشوائي من 4 خانات

                string checkQuery = "SELECT COUNT(*) FROM Students2 WHERE StudentID = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@id", studentId);
                    exists = (int)checkCmd.ExecuteScalar() > 0;
                }

            } while (exists);

            return studentId;
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (fuProfilePic.HasFile)
            {
                // قراءة الصورة كبايتات
                byte[] imgBytes = fuProfilePic.FileBytes;

                // تحويلها Base64
                string base64String = Convert.ToBase64String(imgBytes);

                // ربط الصورة بمربع العرض
                imgProfile.ImageUrl = "data:image/png;base64," + base64String;
            }
            else
            {
                imgProfile.ImageUrl = ""; // لو ما اختار صورة
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    Regeister();
            //    Button1_Click(sender, e);
            //    // Code here will only execute on the initial page load.
            //    // This is where you might initialize button states,
            //    // populate data for controls related to the button, etc.
            //}

            //if (!IsPostBack)
            //{
            //    // Event is ONLY bound on first load
            //    Regeister() += Regeister();

            //}
            //TextBox16.Text = DateTime.Now.ToString();
            if (!Page.IsPostBack)
            {
                PanelEdite.Visible = false;
                PanelShowAll.Visible = false; // عرض الكل
                PanelLogin.Visible = true; // لم يتم التسجيل
                Panel1.Visible = false; // تعديل
                PanelChoose.Visible = false; // الاختيار
            }
        }
        protected void Regeister()
        {

            if (txtUser.Text == "admin" && txtPass.Text == "1234")
            {
                PanelEdite.Visible = false;
                PanelShowAll.Visible = false; // عرض الكل
                PanelLogin.Visible = false; // لم يتم التسجيل
                Panel1.Visible = false; //  طالب جديد
                PanelChoose.Visible = true; // الاختيار
            }
            else
            {
                Response.Write("<script>alert('حطأ في كلمة المرور او اسم المستخدم');</script>");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Regeister();


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            PanelEdite.Visible = false;
            PanelShowAll.Visible = false; // عرض الكل
            PanelLogin.Visible = false; // لم يتم التسجيل
            Panel1.Visible = true; //  طالب جديد
            PanelChoose.Visible = false; // الاختيار
        }

        protected void BtnDaily_Click(object sender, EventArgs e)
        {
            PanelEdite.Visible = true;
            PanelShowAll.Visible = false; // عرض الكل
            PanelLogin.Visible = false; // لم يتم التسجيل
            Panel1.Visible = false; //  طالب جديد
            PanelChoose.Visible = false; // الاختيار
        }

        protected void btnBrowse_Click(object sender, EventArgs e)
        {
            ShowAll();
            PanelEdite.Visible = false;
            PanelShowAll.Visible = true; // عرض الكل
            PanelLogin.Visible = false; // لم يتم التسجيل
            Panel1.Visible = false; //  طالب جديد
            PanelChoose.Visible = false; // الاختيار
        }

        protected void ShowAll()
        {
            LoadAllData();
        }


        private void LoadAllData()
        {


            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();

                // ✅ الطلاب
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Students2", con);
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandTimeout = 180; // 3 دقائق

                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                GridViewStudents.DataSource = dt1;
                GridViewStudents.DataBind();

                // ✅ الحضور
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT * FROM Absence", con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                GridViewAttendance.DataSource = dt2;
                GridViewAttendance.DataBind();

                // ✅ النتائج
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT * FROM Tests", con);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                GridViewTests.DataSource = dt3;
                GridViewTests.DataBind();

                // ✅ المدفوعات
                SqlDataAdapter da4 = new SqlDataAdapter("SELECT * FROM Payments", con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                GridViewPayments.DataSource = dt4;
                GridViewPayments.DataBind();

                lblMessage.Text = "✅ تم جلب البيانات بنجاح. الطلاب: " + dt1.Rows.Count + " | الحضور: " + dt2.Rows.Count + " | النتائج: " + dt3.Rows.Count + " | المدفوعات: " + dt4.Rows.Count;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "❌ خطأ: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }


        //  الاضافة 


        private void ClearForm()
        {
            // TextBox
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";


            // DropDownList (لو عندك)
            DropDownList1.ClearSelection();

            // RadioButton (لو عندك نعم/لا)
            RadioButtonList1.ClearSelection();


        }
        protected void btnShow_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBox14.Text))
            {
                return;
            }

            int StudentID;
            if (!int.TryParse(TextBox14.Text, out StudentID))
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(connString)
        )
            {
                con.Open();

                // 1) جلب بيانات الطالب من جدول Students
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Students2 WHERE StudentID = @StudentID", con);
                cmd1.Parameters.AddWithValue("@StudentID", StudentID);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    TextBox15.Text = dr["FullName"].ToString();
                    TextBox16.Text = dr["BirthPlace"].ToString();
                    TextBox17.Text = Convert.ToDateTime(dr["BirthDate"]).ToString("yyyy-MM-dd");
                    TextBox18.Text = dr["Address"].ToString();
                    TextBox19.Text = dr["FatherJob"].ToString();
                    TextBox20.Text = dr["MotherJob"].ToString();
                    TextBox21.Text = dr["Grade11"].ToString();
                    TextBox22.Text = dr["Grade9"].ToString();
                    TextBox23.Text = dr["PhoneHome"].ToString();
                    TextBox24.Text = dr["PhoneStudent"].ToString();
                    TextBox25.Text = dr["PhoneFather"].ToString();
                    TextBox26.Text = dr["PhoneMother"].ToString();
                }
                dr.Close();

                // 2) جلب الغياب
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Absence WHERE StudentID = @StudentID", con);
                cmd2.Parameters.AddWithValue("@StudentID", StudentID);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                GridView2.DataSource = dt1;
                GridView2.DataBind();

                // 3) جلب المواد والنتائج
                SqlCommand cmd3 = new SqlCommand("SELECT * FROM Tests WHERE StudentID = @StudentID", con);
                cmd3.Parameters.AddWithValue("@StudentID", StudentID);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                GridView3.DataSource = dt2;
                GridView3.DataBind();
                // ... كود جلب البيانات الأساسية والغياب والمواد كما كان
                int studentIdss;
                if (int.TryParse(TextBox14.Text, out studentIdss))
                {
                    LoadPayments(studentIdss);
                }
            }
        }

        protected void btnEdite_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBox14.Text))
            {
                Response.Write("<script>alert('الرجاء إدخال رقم الطالب');</script>");
                return;
            }

            int studentId;
            if (!int.TryParse(TextBox14.Text, out studentId))
            {
                Response.Write("<script>alert('رقم الطالب غير صالح');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(connString)
            )
            {
                con.Open();

                // 1. تحديث بيانات الطالب
                string updateQuery = @"UPDATE Students2 
                               SET FullName=@FullName, BirthPlace=@BirthPlace, BirthDate=@BirthDate,
                                   Address=@Address, FatherJob=@FatherJob, MotherJob=@MotherJob,
                                   Grade11=@Grade11, Grade9=@Grade9, PhoneHome=@PhoneHome,
                                   PhoneStudent=@PhoneStudent, PhoneFather=@PhoneFather, PhoneMother=@PhoneMother
                               WHERE StudentID=@StudentID";

                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@FullName", TextBox15.Text);
                cmd.Parameters.AddWithValue("@BirthPlace", TextBox16.Text);
                cmd.Parameters.AddWithValue("@BirthDate", TextBox17.Text);
                cmd.Parameters.AddWithValue("@Address", TextBox18.Text);
                cmd.Parameters.AddWithValue("@FatherJob", TextBox19.Text);
                cmd.Parameters.AddWithValue("@MotherJob", TextBox20.Text);
                cmd.Parameters.AddWithValue("@Grade11", TextBox21.Text);
                cmd.Parameters.AddWithValue("@Grade9", TextBox22.Text);
                cmd.Parameters.AddWithValue("@PhoneHome", TextBox23.Text);
                cmd.Parameters.AddWithValue("@PhoneStudent", TextBox24.Text);
                cmd.Parameters.AddWithValue("@PhoneFather", TextBox25.Text);
                cmd.Parameters.AddWithValue("@PhoneMother", TextBox26.Text);

                cmd.ExecuteNonQuery();

                // 2. الغياب / الحضور
                string AbsenceResults = RadioButtonList1.SelectedValue == "1" ? "غاب" : "لم يغِب";
                string insertAttendance = "INSERT INTO Absence (StudentID, AbsenceResults, CreatedAt) VALUES (@StudentID, @AbsenceResults, @CreatedAt)";
                SqlCommand cmdAttendance = new SqlCommand(insertAttendance, con);
                cmdAttendance.Parameters.AddWithValue("@StudentID", studentId);
                cmdAttendance.Parameters.AddWithValue("@AbsenceResults", AbsenceResults);
                cmdAttendance.Parameters.AddWithValue("@CreatedAt", DateTime.Now.Date);
                cmdAttendance.ExecuteNonQuery();

                // 3. المواد + الدرجة
                if (!string.IsNullOrWhiteSpace(DropDownList1.Text))
                {
                    if (DropDownList1.SelectedValue != "لايوجد اختبار")
                    {
                        string subject = DropDownList1.SelectedValue;
                        string insertSubject = "INSERT INTO Tests (StudentID, TestObject, TestResults) VALUES (@StudentID, @TestObject, @TestResults)";
                        SqlCommand cmdSubject = new SqlCommand(insertSubject, con);
                        cmdSubject.Parameters.AddWithValue("@StudentID", studentId);
                        cmdSubject.Parameters.AddWithValue("@TestObject", subject);
                        cmdSubject.Parameters.AddWithValue("@TestResults", TextBox27.Text);
                        cmdSubject.ExecuteNonQuery();
                    }

                }
            }
            ClearForm();
            ShowAfterEdite();
            Response.Write("<script>alert('✅ تم تعديل البيانات وحفظ الغياب والمادة بنجاح');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TextBox14.Text))
            {
                Response.Write("<script>alert('الرجاء إدخال رقم الطالب لحذفه');</script>");
                return;
            }

            int studentId;
            if (!int.TryParse(TextBox14.Text, out studentId))
            {
                Response.Write("<script>alert('رقم الطالب غير صالح');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(connString)
            )
            {
                con.Open();

                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    // 1. حذف المواد
                    string deleteTests = "DELETE FROM Tests WHERE StudentID=@StudentID";
                    SqlCommand cmdSubjects = new SqlCommand(deleteTests, con, tran);
                    cmdSubjects.Parameters.AddWithValue("@StudentID", studentId);
                    cmdSubjects.ExecuteNonQuery();

                    // 2. حذف الغياب
                    string deleteAbsence = "DELETE FROM Absence WHERE StudentID=@StudentID";
                    SqlCommand cmdAttendance = new SqlCommand(deleteAbsence, con, tran);
                    cmdAttendance.Parameters.AddWithValue("@StudentID", studentId);
                    cmdAttendance.ExecuteNonQuery();

                    // 3. حذف الطالب نفسه
                    string deleteStudent = "DELETE FROM Students2 WHERE StudentID=@StudentID";
                    SqlCommand cmdStudent = new SqlCommand(deleteStudent, con, tran);
                    cmdStudent.Parameters.AddWithValue("@StudentID", studentId);
                    cmdStudent.ExecuteNonQuery();

                    tran.Commit();
                    ClearForm();
                    Response.Write("<script>alert('✅ تم حذف بيانات الطالب من جميع الجداول بنجاح');</script>");

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Response.Write("<script>alert('خطأ أثناء الحذف: " + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonAddPayment_Click(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(TextBox14.Text) ||
                string.IsNullOrWhiteSpace(TextBoxTotalPayment.Text) ||
                string.IsNullOrWhiteSpace(TextBoxPaidNow.Text))
            {
                Response.Write("<script>alert('الرجاء ملء جميع الحقول');</script>");
                return;
            }

            int studentId;
            decimal total, paidNow;

            if (!int.TryParse(TextBox14.Text, out studentId) ||
                !decimal.TryParse(TextBoxTotalPayment.Text, out total) ||
                !decimal.TryParse(TextBoxPaidNow.Text, out paidNow))
            {
                Response.Write("<script>alert('الرجاء إدخال قيم صحيحة');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string insertPayment = @"INSERT INTO Payments (StudentID, TotalAmount, PaidAmount, CreatedAt)
                                 VALUES (@StudentID, @TotalAmount, @PaidAmount, @CreatedAt)";
                SqlCommand cmd = new SqlCommand(insertPayment, con);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                cmd.Parameters.AddWithValue("@TotalAmount", total);
                cmd.Parameters.AddWithValue("@PaidAmount", paidNow);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.ExecuteNonQuery();
            }

            LoadPayments(studentId);
            Response.Write("<script>alert('✅ تم إضافة الدفع بنجاح');</script>");
        }

        // دالة لتحميل المدفوعات وحساب المتبقي
        private void LoadPayments(int studentId)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string query = @"SELECT PaymentID, TotalAmount, PaidAmount,
                        (TotalAmount - SUM(PaidAmount) OVER (PARTITION BY StudentID ORDER BY PaymentID ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW)) AS Remaining
                        FROM Payments
                        WHERE StudentID=@StudentID
                        ORDER BY PaymentID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewPayments1.DataSource = dt;
                GridViewPayments1.DataBind();
            }
        }

        protected void ShowAfterEdite()
        {


            if (string.IsNullOrWhiteSpace(TextBox14.Text))
            {
                return;
            }

            int StudentID;
            if (!int.TryParse(TextBox14.Text, out StudentID))
            {
                return;
            }

            using (SqlConnection con = new SqlConnection(connString)
        )
            {
                con.Open();

                // 1) جلب بيانات الطالب من جدول Students
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Students2 WHERE StudentID = @StudentID", con);
                cmd1.Parameters.AddWithValue("@StudentID", StudentID);
                SqlDataReader dr = cmd1.ExecuteReader();

                if (dr.Read())
                {
                    TextBox15.Text = dr["FullName"].ToString();
                    TextBox16.Text = dr["BirthPlace"].ToString();
                    TextBox17.Text = Convert.ToDateTime(dr["BirthDate"]).ToString("yyyy-MM-dd");
                    TextBox18.Text = dr["Address"].ToString();
                    TextBox19.Text = dr["FatherJob"].ToString();
                    TextBox20.Text = dr["MotherJob"].ToString();
                    TextBox21.Text = dr["Grade11"].ToString();
                    TextBox22.Text = dr["Grade9"].ToString();
                    TextBox23.Text = dr["PhoneHome"].ToString();
                    TextBox24.Text = dr["PhoneStudent"].ToString();
                    TextBox25.Text = dr["PhoneFather"].ToString();
                    TextBox26.Text = dr["PhoneMother"].ToString();
                }
                dr.Close();

                // 2) جلب الغياب
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Absence WHERE StudentID = @StudentID", con);
                cmd2.Parameters.AddWithValue("@StudentID", StudentID);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                GridView2.DataSource = dt1;
                GridView2.DataBind();

                // 3) جلب المواد والنتائج
                SqlCommand cmd3 = new SqlCommand("SELECT * FROM Tests WHERE StudentID = @StudentID", con);
                cmd3.Parameters.AddWithValue("@StudentID", StudentID);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                GridView3.DataSource = dt2;
                GridView3.DataBind();
                // ... كود جلب البيانات الأساسية والغياب والمواد كما كان
                int studentIdss;
                if (int.TryParse(TextBox14.Text, out studentIdss))
                {
                    LoadPayments(studentIdss);
                }
            }
        }

        protected void ButtonDeletePayment_Click(object sender, EventArgs e)
        {
            int studentIdss = Convert.ToInt32(TextBox14.Text);
            if (string.IsNullOrWhiteSpace(TextBoxDeletePaymentID.Text))
            {
                Response.Write("<script>alert('الرجاء إدخال رقم الدفع للحذف');</script>");
                return;
            }

            int paymentId;
            if (!int.TryParse(TextBoxDeletePaymentID.Text, out paymentId))
            {
                Response.Write("<script>alert('رقم الدفع غير صالح');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                string deletePayment = "DELETE FROM Payments WHERE PaymentID=@PaymentID";

                using (SqlCommand cmd = new SqlCommand(deletePayment, con))
                {
                    cmd.Parameters.AddWithValue("@PaymentID", paymentId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('✅ تم حذف الدفع بنجاح');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('❌ لم يتم العثور على رقم الدفع');</script>");
                    }
                }
            }
            LoadPayments(studentIdss);
        }

    }

}

