using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PsyForCom.Account
{
    public partial class PsyRegistration : System.Web.UI.Page
    {
        private int curId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Wizard1.ActiveStepIndex = 0;
            }

        }

        protected void RegisterPsyInfo(object sender, EventArgs e)
        {

            int userId;
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_Psy"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        string Password = txtPassword.Text;
                        txtPassword.Attributes.Add("value", Password);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", txtName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", TextLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@PhoneNum", txtPhoneNum.Text.Trim());
                        cmd.Parameters.AddWithValue("@Gender", rdoGender.Text.Trim());
                        cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                        cmd.Parameters.AddWithValue("@Licence", txtLiecence.Text.Trim());
                        cmd.Parameters.AddWithValue("@Speciality", txtSpeciality.Text.Trim());
                        cmd.Parameters.AddWithValue("@Degree", txtDegree.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        int tempId = getPsyId(txtEmail.Text.ToString());
                        curId = tempId;
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {

                    case -1:
                        message = "כתובת האימייל קיימת במערכת.";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                        break;
                    default:
                        break;
                }

            }
        }

        protected void RegisterPsyClinicInfo(object sender, EventArgs e)
        {
            int userId;
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_ClinicInfo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        curId = getPsyId(txtEmail.Text.ToString());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@City", txtClinicLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Street", txtClinicStreet.Text.Trim());
                        cmd.Parameters.AddWithValue("@StreetNum", txtClinicStreetNum.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtClinicEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@ClPhoneNum", txtClinicPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@WebSite", txtClinicWeb.Text.Trim());
                        cmd.Parameters.AddWithValue("@Psy_Id", Convert.ToInt32(curId));

                        cmd.Connection = con;
                        con.Open();

                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }

            }
        }

        protected void RegisterTherapyInfo(object sender, EventArgs e)
        {


            int userId;
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_TherapyInfo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {

                        curId = getPsyId(txtEmail.Text.ToString());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());

                        cmd.Parameters.AddWithValue("@Speciality", txtSpeciality.Text.Trim());
                        cmd.Parameters.AddWithValue("@Comment", txtComment.Text.Trim());

                        List<String> LangList = new List<string>();
                        string Lang = "";
                        foreach (var item in CheckBoxLang.Items.Cast<ListItem>().Where(item => item.Selected))
                        {
                            LangList.Add(item.Text);
                            //Lang = Lang + item.Text;
                        }
                        Lang = String.Join(",", LangList.ToArray());

                        List<String> MikudList = new List<string>();
                        string Mikud = "";
                        foreach (var item in CheckBoxMikud.Items.Cast<ListItem>().Where(item => item.Selected))
                        {
                            MikudList.Add(item.Text);
                            //Mikud = Mikud + item.Text;
                        }
                        Mikud = String.Join(",", MikudList.ToArray());

                        List<String> AgesList = new List<string>();
                        string Ages = "";
                        foreach (var item in CheckBoxAges.Items.Cast<ListItem>().Where(item => item.Selected))
                        {
                            AgesList.Add(item.Text);
                            //Ages = Ages + item.Text;
                        }
                        Ages = String.Join(",", AgesList.ToArray());

                        cmd.Parameters.AddWithValue("@Languages", Lang.Trim());
                        cmd.Parameters.AddWithValue("@Mikud", Mikud.Trim());
                        cmd.Parameters.AddWithValue("@Ages", Ages.Trim());
                        cmd.Parameters.AddWithValue("@C_Id", Convert.ToInt32(curId));
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
                        message = "כתובת האימייל קיימת במערכת.";

                        break;
                    default:
                        message = "הליך ההרשמה עבר בהצלחה.\\nUser Id: " + userId.ToString();
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            UpdatePsy(sender, e);
            Server.Transfer("~/Default.aspx", true);
        }

        protected void UpdatePsy(object sender, EventArgs e)
        {

            RegisterPsyInfo(sender, e);
            RegisterPsyClinicInfo(sender, e);
            RegisterTherapyInfo(sender, e);
            SendMail();
        }

        private int getPsyId(string email)
        {
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT P_Id  FROM PsycologistInfo WHERE Email = @param_email"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        int id = 0;
                        SqlParameter e_mail = new SqlParameter("param_email", email);
                        DataTable dt = new DataTable();
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.Add(e_mail);
                        cmd.ExecuteNonQuery();
                        sda.SelectCommand = cmd;
                        sda.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            id = (int)(row["P_Id"]);

                        }
                        return id;
                    }
                }
            }
        }

        private void SendMail()
        {
           
            string filename = Server.MapPath("~/MailConfirmation.html");
            string mailbody = System.IO.File.ReadAllText(filename);
            mailbody = mailbody.Replace("##NAME##", txtName.Text);
            mailbody = mailbody.Replace("##FirstName##", txtName.Text);
            mailbody = mailbody.Replace("##LastName##", TextLastName.Text);
            mailbody = mailbody.Replace("##UserName##", txtEmail.Text);
            mailbody = mailbody.Replace("##Password##", txtPassword.Text);
            string to = txtEmail.Text;
          
            string from = "yuvalbau@gmail.com"; // IDC mail needs to be added
            MailMessage message = new MailMessage(from, to);           
            message.Subject = "רישום לפסיכולוגים למען הקהילה";
            message.Body = mailbody;
            message.CC.Add("yuvalbau@gmail.com");//admin mail needs to be added
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("yuvalbau@gmail.com", "yuvalbau2012");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential;
            try
            {
                client.Send(message);
                ShowMessage("Email Sending successfully...!");
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

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            int userId;

            if (e.CurrentStepIndex == 1)
            {
                string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("ValidatePsy"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
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
                            message = "כתובת האימייל קיימת במערכת.";
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                            e.Cancel = true;
                            break;
                        default:
                            break;
                    }

                }
            }
            else
            {

            }
        }

        protected void Wizard1_SideBarButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
