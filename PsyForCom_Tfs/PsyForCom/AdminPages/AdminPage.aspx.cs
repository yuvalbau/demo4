using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PsyForCom.AdminPages
{
    public partial class AdminPage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownListAdmin.SelectedItem.Value == "2")
            {
                Response.Redirect("~/MembersPages/PsyList.aspx?SelectedValue=" + DropDownListAdmin.SelectedValue);
            }
            else if ((DropDownListAdmin.SelectedItem.Value == "1"))
            {
                Response.Redirect("~/AdminPages/UsersUpdate.aspx?SelectedValue=" + DropDownListAdmin.SelectedValue);
            }
        }
    }
}