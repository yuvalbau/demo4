using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Web.Http;


namespace PsyForCom.DAL
{
    public class DataAccess
    {
        #region Members
        public string constr;
        SqlConnection conn;
        SqlCommand cmd; 
        #endregion

        public DataAccess()
        {
            PrepConnection();
             
        }

        private void PrepConnection()
        {
            constr = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            conn = new SqlConnection(constr);
            cmd = conn.CreateCommand();
        }

        public bool Login_User(string name, string pass)
        {
            // Create our connection and command objects          
            cmd.CommandText = "SELECT Role FROM Users WHERE username=@Username " + "AND password=@Password";

            // Fill our parameters

            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 64).Value = name;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 128).Value = pass;

            // Execute the command
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return true;
            }
            else
            {
                reader.Close();
                conn.Close();
                return false;
            }
            
        }

        public bool Login_Psy(string name, string pass)
        {
            cmd.CommandText = "SELECT Role FROM PsycologistInfo WHERE Email=@Email " + "AND password=@Password";

            // Fill our parameters

            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 64).Value = name;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 128).Value = pass;

            // Execute the command
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return true;
            }
            else
            {
                reader.Close();
                conn.Close();
                return false;
            }
        }

        public bool Login_Admin(string name, string pass)
        {
            cmd.CommandText = "SELECT Role FROM Admin WHERE AdminName=@Username " + "AND password=@Password";

            // Fill our parameters

            cmd.Parameters.Add("@username", SqlDbType.NVarChar, 64).Value = name;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 128).Value = pass;

            // Execute the command
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                conn.Close();
                return true;
            }
            else
            {
                reader.Close();
                conn.Close();
                return false;
            }

        }


    }
}

