using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;

namespace AL_Masry
{
    public partial class ShowStudentData : Page
    {
        private string connString = ConfigurationManager.ConnectionStrings["MasryConnectionString"].ConnectionString;

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            int studentId;
            if (!int.TryParse(txtStudentID.Text, out studentId))
            {
                Response.Write("<script>alert('الرجاء إدخال رقم طالب صحيح');</script>");
                return;
            }

            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();

                // البيانات الأساسية



                string sqlBasic = @"SELECT StudentID ,FullName, BirthPlace, BirthDate, Address, FatherJob, MotherJob, Grade11, Grade9, PhoneHome, PhoneStudent, PhoneFather, PhoneMother ,ProfileImage
                                    FROM Students2
                                    WHERE StudentID = @StudentID";
                SqlDataAdapter daBasic = new SqlDataAdapter(sqlBasic, con);
                daBasic.SelectCommand.Parameters.AddWithValue("@StudentID", studentId);
                DataTable dtBasic = new DataTable();
                daBasic.Fill(dtBasic);
                //GridViewBasic.DataSource = dtBasic;
                //GridViewBasic.DataBind();
                if (dtBasic.Rows.Count > 0)
                {
                    PanelStudentCard.Visible = true;
                    lblName.Text = dtBasic.Rows[0]["FullName"].ToString();
                    lblID.Text = dtBasic.Rows[0]["StudentID"].ToString();
                    lblClass.Text = dtBasic.Rows[0]["PhoneStudent"].ToString();
                    //lblAge.Text = dtBasic.Rows[0]["BirthDate"].ToString();
                    DateTime birthDate;
                    if (DateTime.TryParse(dtBasic.Rows[0]["BirthDate"].ToString(), out birthDate))
                    {
                        // حساب العمر
                        DateTime today = DateTime.Today;
                        TimeSpan difference = today - birthDate;

                        int years = (int)(difference.Days / 365.25); // السنوات
                        int days = difference.Days - (int)(years * 365.25); // الأيام المتبقية

                        lblAge.Text = $"{years} سنة و {days} يوم";
                    }
                    else
                    {
                        lblAge.Text = "غير متوفر";
                    }
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlBasic, con);
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    // الصورة (تأكد أن عندك حقل صورة بالجدول مثل Photo أو ImagePath)
                    using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {


                            // تحميل الصورة من قاعدة البيانات (varbinary)
                            if (!(reader["ProfileImage"] is DBNull))
                            {
                                byte[] imgData = (byte[])reader["ProfileImage"];
                                string base64String = Convert.ToBase64String(imgData);
                                imgStudent.ImageUrl = "data:image/png;base64," + base64String;
                            }
                            else
                            {
                                imgStudent.ImageUrl = "https://via.placeholder.com/150"; // صورة افتراضية
                            }
                            reader.Close();
                        }


                        // الحضور والغياب
                        string sqlAttendance = @"SELECT AbsenceResults, CreatedAt FROM Absence WHERE StudentID = @StudentID";
                        SqlDataAdapter daAttendance = new SqlDataAdapter(sqlAttendance, con);
                        daAttendance.SelectCommand.Parameters.AddWithValue("@StudentID", studentId);
                        DataTable dtAttendance = new DataTable();
                        daAttendance.Fill(dtAttendance);
                        GridViewAttendance.DataSource = dtAttendance;
                        GridViewAttendance.DataBind();

                        // المواد والنتائج
                        string sqlTests = @"SELECT TestObject, TestResults ,TestDate FROM Tests WHERE StudentID = @StudentID";
                        SqlDataAdapter daTests = new SqlDataAdapter(sqlTests, con);
                        daTests.SelectCommand.Parameters.AddWithValue("@StudentID", studentId);
                        DataTable dtTests = new DataTable();
                        daTests.Fill(dtTests);
                        GridViewTests.DataSource = dtTests;
                        GridViewTests.DataBind();

                        // المدفوعات
                        LoadPayments(con, studentId);
                    }
                }
            }
        }

        private void LoadPayments(SqlConnection con, int studentId)
        {
            string query = @"SELECT PaymentID, CreatedAt, TotalAmount, PaidAmount,
            (TotalAmount - ISNULL(SUM(PaidAmount) OVER (ORDER BY PaymentID ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW),0)) AS Remaining
            FROM Payments
            WHERE StudentID=@StudentID
            ORDER BY PaymentID;
                    ";

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
