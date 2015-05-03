using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PsyForCom.Account
{
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        string v;
        protected void Page_Load(object sender, EventArgs e)
        {
             v = Request.QueryString["SelectedValue"];
            if (v == "1") // user 
            {
                
                Title1.InnerText = "דף איפוס סיסמא למשתמשים:";
                txtLiecence.Visible = false;
                Liecence.Visible = false;
                }
            else
            {
                Title1.InnerText = "דף איפוס סיסמא לפסיכולוגים:";
                txtUserName.Visible = false;
                userName.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (v == "1")
            {
                recoverUser();
            }
            else
            {
                recoverPsy();
            }
            
        }

        protected void recoverPsy()
        {
             int userId;

            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("RecoverPasswordPsy"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        FormsAuthentication.Initialize();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Licence", txtLiecence.Text.Trim());
                        cmd.Parameters.AddWithValue("@NewPassword", txtNewPassword.Text.Trim());
                       
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());

                        con.Close();

                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "אחד מהפרטי הזדהות שנתת אינם תואמים, אנא וודא כי הכנסת את הפרטים הנכונים.במידה ופרטי ההזדהות נכונים ועדיין אינך מצליח להכנס אנא צור קשר";
                        break;
                    
                    default:

                        message = " הליך איפוס הססמא  עבר בהצלחה.הססמא החדשה נשלחה לך במייל\\";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                        Response.Redirect("~/Default.aspx");
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

                
            }
        }
     
        protected void recoverUser()
        {
            int userId;

            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("RecoverPasswordUser"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                       
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@NewPassword", txtNewPassword.Text.Trim());

                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());

                        con.Close();

                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "אחד מהפרטי הזדהות שנתת אינם תואמים, אנא וודא כי הכנסת את הפרטים הנכונים.במידה ופרטי ההזדהות נכונים ועדיין אינך מצליח להכנס אנא צור קשר";
                        break;

                    default:

                        message = " הליך איפוס הססמא  עבר בהצלחה.הססמא החדשה נשלחה לך במייל\\";
                        SendRecoveryMail();
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                        Response.Redirect("~/Default.aspx");
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);


            }

        }
    
        private void SendRecoveryMail()
        {
            string filename = Server.MapPath("~/PasswordRecovery.html");
            string mailbody = System.IO.File.ReadAllText(filename);
            mailbody = mailbody.Replace("##NAME##", txtEmail.Text);
            mailbody = mailbody.Replace("##Password##", txtNewPassword.Text);
            string to = txtEmail.Text;
            string from = "yuvalbau@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Auto Response Email";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("", "");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential;
            try
            {
                client.Send(message);
                ShowMessage("האימייל עם סיסמתך החדשה נשלח אלייך אל כתובת המייל");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        void ShowMessage(string msg)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('" + msg + "');</script>");
        }
    }
}