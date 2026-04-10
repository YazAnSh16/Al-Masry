using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AL_Masry
{
    public partial class ShowAllStudents : System.Web.UI.Page
    {
        static private string connString = @"Data Source=Yazan\SQLEXPRESS;Initial Catalog=Masry;Integrated Security=True;TrustServerCertificate=True";

        SqlConnection con = new SqlConnection(connString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllData();
            }
        }

        private void LoadAllData()
        {
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
    }
}
