using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PsyForCom
{
    public partial class PsyList : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("User") && (!User.IsInRole("Admin")))
                Server.Transfer("~/Account/Login.aspx", true);
                 
        }

        protected int getNumOfRows()
        {
            int count = 0;
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Create our connection and command objects
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT COUNT(P_Id) AS NumberOfRows FROM PsycologistInfo";
            conn.Open();
            count = (int)cmd.ExecuteScalar();
            return count;
        }

        protected void SqlDataSource3_Updating(object sender, SqlDataSourceCommandEventArgs e) 
       {
           
        }

                       
    }

}
