using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PsyForCom
{
    public partial class SiteMaster : MasterPage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
           
                
        }
 
        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
           

            //Session.Abandon();
           FormsAuthentication.SignOut();
           
           FormsAuthentication.RedirectToLoginPage();
        }
    }
}