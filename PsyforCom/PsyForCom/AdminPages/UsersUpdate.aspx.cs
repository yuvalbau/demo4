using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PsyForCom.AdminPages
{
    public partial class UsersUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridViewUsers.Rows[e.RowIndex];
            string constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            // Create our connection and command objects
            SqlConnection conn = new SqlConnection(constr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd = new SqlCommand("delete FROM USERS where id='" + Convert.ToInt32(GridViewUsers.DataKeys[e.RowIndex].Value.ToString()) + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();


        }

    }
}