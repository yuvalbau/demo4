using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PsyForCom.Account
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId;

            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        FormsAuthentication.Initialize();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", TextName.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", TextLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);

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
                        message = "שם המשתמש קיים במערכת \\nאנא בחר שם משתמש אחר.";
                        break;
                    case -2:
                        message = "כתובת האימייל קיימת במערכת.";
                        break;
                    default:

                        message = "הליך ההרשמה עבר בהצלחה.\\nUser Id: " + userId.ToString();
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                        Response.Redirect("~/Default.aspx");
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);


            }
        }


    }

}
