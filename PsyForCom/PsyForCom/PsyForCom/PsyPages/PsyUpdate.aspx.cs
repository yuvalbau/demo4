using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PsyForCom.PsyPages
{
    public partial class PsyUpdate : System.Web.UI.Page
    {
        string UserName;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!User.IsInRole("Psychologist"))
            {
                               
            }
            this.UserName = Request.QueryString["value"];
               
        }

        protected void ChangeStatus(object sender, EventArgs e)
        {
            UserName=HttpContext.Current.User.Identity.Name.ToString();
          
          
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
           
          

            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd2 = new SqlCommand("UPDATE PsycologistInfo SET PsycologistInfo.Availability=@Availability WHERE [Email] =@email", conn))
                {

                cmd2.Parameters.AddWithValue("@Availability", DropDownListStatus.SelectedValue);
                cmd2.Parameters.AddWithValue("@Email", UserName);
    	        conn.Open();
    	        cmd2.ExecuteNonQuery();
                conn.Close();
    }
}
            string message = string.Empty;
            message = "העדכון עבר בהצלחה";
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}