using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Data.SqlClient;

namespace AL_Masry
{
    public partial class showtest : System.Web.UI.Page
    {
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
            TextBox13.Text = "";

            // DropDownList (لو عندك)
            DropDownList1.ClearSelection();

            // RadioButton (لو عندك نعم/لا)
            RadioButtonList1.ClearSelection();

            
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox16.Text = DateTime.Now.ToString();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            
                if (string.IsNullOrWhiteSpace(TextBox13.Text))
                {
                    return;
                }

                int StudentID;
                if (!int.TryParse(TextBox13.Text, out StudentID))
                {
                    return;
                }

                using (SqlConnection con = new SqlConnection(@"Data Source=Yazan\SQLEXPRESS;Initial Catalog=Masry;Integrated Security=True;TrustServerCertificate=True")
            )
                {
                    con.Open();

                    // 1) جلب بيانات الطالب من جدول Students
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Students2 WHERE StudentID = @StudentID", con);
                    cmd1.Parameters.AddWithValue("@StudentID", StudentID);
                    SqlDataReader dr = cmd1.ExecuteReader();

                    if (dr.Read())
                    {
                        TextBox1.Text = dr["FullName"].ToString();
                        TextBox2.Text = dr["BirthPlace"].ToString();
                        TextBox3.Text = Convert.ToDateTime(dr["BirthDate"]).ToString("yyyy-MM-dd");
                        TextBox4.Text = dr["Address"].ToString();
                        TextBox5.Text = dr["FatherJob"].ToString();
                        TextBox6.Text = dr["MotherJob"].ToString();
                        TextBox7.Text = dr["Grade11"].ToString();
                        TextBox8.Text = dr["Grade9"].ToString();
                        TextBox9.Text = dr["PhoneHome"].ToString();
                        TextBox10.Text = dr["PhoneStudent"].ToString();
                        TextBox11.Text = dr["PhoneFather"].ToString();
                        TextBox12.Text = dr["PhoneMother"].ToString();
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
                if (int.TryParse(TextBox13.Text, out studentIdss))
                {
                    LoadPayments(studentIdss);
                }
            }
            }

        protected void btnEdite_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(TextBox13.Text))
            {
                Response.Write("<script>alert('الرجاء إدخال رقم الطالب');</script>");
                return;
            }

            int studentId;
            if (!int.TryParse(TextBox13.Text, out studentId))
            {
                Response.Write("<script>alert('رقم الطالب غير صالح');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=Yazan\SQLEXPRESS;Initial Catalog=Masry;Integrated Security=True;TrustServerCertificate=True")
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
                    string subject = DropDownList1.SelectedValue;
                    string insertSubject = "INSERT INTO Tests (StudentID, TestObject, TestResults) VALUES (@StudentID, @TestObject, @TestResults)";
                    SqlCommand cmdSubject = new SqlCommand(insertSubject, con);
                    cmdSubject.Parameters.AddWithValue("@StudentID", studentId);
                    cmdSubject.Parameters.AddWithValue("@TestObject", subject);
                    cmdSubject.Parameters.AddWithValue("@TestResults", TextBox15.Text);
                    cmdSubject.ExecuteNonQuery();
                }
            }
            ClearForm();
            Response.Write("<script>alert('✅ تم تعديل البيانات وحفظ الغياب والمادة بنجاح');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(TextBox13.Text))
            {
                Response.Write("<script>alert('الرجاء إدخال رقم الطالب لحذفه');</script>");
                return;
            }

            int studentId;
            if (!int.TryParse(TextBox13.Text, out studentId))
            {
                Response.Write("<script>alert('رقم الطالب غير صالح');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=Yazan\SQLEXPRESS;Initial Catalog=Masry;Integrated Security=True;TrustServerCertificate=True")
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
            if (string.IsNullOrWhiteSpace(TextBox13.Text) ||
                string.IsNullOrWhiteSpace(TextBoxTotalPayment.Text) ||
                string.IsNullOrWhiteSpace(TextBoxPaidNow.Text))
            {
                Response.Write("<script>alert('الرجاء ملء جميع الحقول');</script>");
                return;
            }

            int studentId;
            decimal total, paidNow;

            if (!int.TryParse(TextBox13.Text, out studentId) ||
                !decimal.TryParse(TextBoxTotalPayment.Text, out total) ||
                !decimal.TryParse(TextBoxPaidNow.Text, out paidNow))
            {
                Response.Write("<script>alert('الرجاء إدخال قيم صحيحة');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(@"Data Source=Yazan\SQLEXPRESS;Initial Catalog=Masry;Integrated Security=True;TrustServerCertificate=True"))
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
            using (SqlConnection con = new SqlConnection(@"Data Source=Yazan\SQLEXPRESS;Initial Catalog=Masry;Integrated Security=True;TrustServerCertificate=True"))
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

                GridViewPayments.DataSource = dt;
                GridViewPayments.DataBind();
            }
        }

    }
}

    
   
