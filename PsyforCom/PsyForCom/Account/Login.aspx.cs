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
    public partial class WebForm1 : System.Web.UI.Page
    {
        DAL.DataAccess m_DataAccess;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (User.IsInRole("User"))
                Server.Transfer("~/MembersPages/PsyList.aspx", true);

            else if (User.IsInRole("Admin"))
                Server.Transfer("~/AdminPages/AdminPage.aspx", true);

            else if (User.IsInRole("Psychologist"))
                Server.Transfer("~/Default.aspx", true);
        }

        protected void Login_User()
        {
            m_DataAccess = new DAL.DataAccess();
            bool status = m_DataAccess.Login_User(Username.Value, Password.Value);

            if (status)
            {
                // Create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                   1, // Ticket version
                   Username.Value, // Username associated with ticket
                   DateTime.Now, // Date/time issued
                   DateTime.Now.AddMinutes(30), // Date/time to expire
                   true, // "true" for a persistent user cookie
                   "User", // User-data, in this case the roles
                   FormsAuthentication.FormsCookiePath);// Path cookie valid for

                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                   FormsAuthentication.FormsCookieName, // Name of auth cookie
                   hash); // Hashed ticket

                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent)
                    cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response
                //cookie.Value["userName"] = Username.Value;
                Response.Cookies.Add(cookie);

                // Redirect to requested URL, or homepage if no previous page
                // requested

                string returnUrl = "~/MembersPages/PsyList.aspx";
                if (returnUrl == null) returnUrl = "/";

                // Don't call FormsAuthentication.RedirectFromLoginPage since it
                // could
                // replace the authentication ticket (cookie) we just added
                Response.Redirect(returnUrl);

            }
            else
            {
                // Never tell the user if just the username is password is incorrect.
                // That just gives them a place to start
                ErrorLabel.Text = "Username / password incorrect. Please try again.";
                ErrorLabel.Visible = true;
            }

        }

        protected void Login_Psy()
        {

            m_DataAccess = new DAL.DataAccess();
            bool status = m_DataAccess.Login_Psy(Username.Value, Password.Value);

            // Initialize FormsAuthentication
            FormsAuthentication.Initialize();


            if (status)
            {
                // Create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                   1, // Ticket version
                   Username.Value, // Username associated with ticket
                   DateTime.Now, // Date/time issued
                   DateTime.Now.AddMinutes(30), // Date/time to expire
                   true, // "true" for a persistent user cookie
                   "Psychologist", // User-data, in this case the roles
                   FormsAuthentication.FormsCookiePath);// Path cookie valid for

                // Encrypt the cookie using the machine key for secure transport

                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName, // Name of auth cookie
                    hash); // Hashed ticket


                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response 

                Response.Cookies.Add(cookie);

                // Redirect to requested URL, or homepage if no previous page
                // requested
                string returnUrl = Request.QueryString["~/Default.aspx"];
                if (returnUrl == null) returnUrl = "~/";

                // Don't call FormsAuthentication.RedirectFromLoginPage since it
                // could
                // replace the authentication ticket (cookie) we just added


                Response.Redirect(returnUrl);
            }
            else
            {
                // Never tell the user if just the username is password is incorrect.
                // That just gives them a place to start, once they've found one or
                // the other is correct!
                ErrorLabel.Text = "Username / password incorrect. Please try again.";
                ErrorLabel.Visible = true;
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0) // user 
            {
                Login_User();
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                Login_Psy();
            }
            else
                Login_Admin();
        }

        protected void Login_Admin()
        {

            m_DataAccess = new DAL.DataAccess();
            bool status = m_DataAccess.Login_Admin(Username.Value, Password.Value);

            // Initialize FormsAuthentication
            FormsAuthentication.Initialize();


            if (status)
            {
                // Create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                   1, // Ticket version
                   Username.Value, // Username associated with ticket
                   DateTime.Now, // Date/time issued
                   DateTime.Now.AddMinutes(30), // Date/time to expire
                   true, // "true" for a persistent user cookie
                   "Admin", // User-data, in this case the roles
                   FormsAuthentication.FormsCookiePath);// Path cookie valid for

                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                   FormsAuthentication.FormsCookieName, // Name of auth cookie
                   hash); // Hashed ticket

                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response
                Response.Cookies.Add(cookie);

                // Redirect to requested URL, or homepage if no previous page
                // requested
                if (ticket.UserData.Equals("Admin"))
                {
                    string returnUrl = "~/AdminPages/AdminPage.aspx";
                    if (returnUrl == null) returnUrl = "~/";

                    // Don't call FormsAuthentication.RedirectFromLoginPage since it
                    // could
                    // replace the authentication ticket (cookie) we just added
                    Response.Redirect(returnUrl);
                }

            }
            else
            {
                // Never tell the user if just the username is password is incorrect.
                // That just gives them a place to start, once they've found one or
                // the other is correct!
                ErrorLabel.Text = "Username / password incorrect. Please try again.";
                ErrorLabel.Visible = true;
            }
        }

        protected void btnPasswordRecovery(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Value.Length > 0)
            {
                Response.Redirect("~/Account/PasswordRecovery.aspx?SelectedValue=" + DropDownList1.SelectedValue);
            }
        }

        

    }

}