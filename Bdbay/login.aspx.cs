using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Bdbay
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["UserID"] = null;
                Session["UserFastName"] = null;
                Session["UserLastName"] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Shortcut = " from Registation_Tbl where Email = '" + txtEmail.Text + "' and Password = '" + txtpassword.Text + "'";
            check CHK = new check();
            CHK.ConfigarationName = "Settings";
            if (CHK.int32Check("select count(*) from Registation_Tbl where Email='" + txtEmail.Text + "' and Password='" + txtpassword.Text + "'") == 1)
            {
                Session["UserID"] = CHK.stringCheck("select UserID " + Shortcut);
                Session["UserFastName"] = CHK.stringCheck("select FastName " + Shortcut);
                Session["UserLastName"] = CHK.stringCheck("select LastName " + Shortcut);
                // ImageShow();
                CHK.ConfigarationName = "video";
                int totalVideo = CHK.int32Check("select count(*) from video where UserID='" + Session["UserID"].ToString() + "' ");
                CHK.ConfigarationName = "blogcs";
                int totalBlog = CHK.int32Check("select count(*) from blog_Tbl where UserID='" + Session["UserID"].ToString() + "'");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Registation_Tbl set TotalVideos=" + totalVideo + ", TotalBlog=" + totalBlog + " where UserID='" + Session["UserID"].ToString() + "'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Default");


            }
            else
            {
                lblResult.Text = "Invalid Username/Password !";
            }
        }
    }
}