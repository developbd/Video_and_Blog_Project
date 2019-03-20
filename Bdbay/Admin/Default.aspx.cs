using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace Bdbay.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Admin"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["AdminUserID"] = null;
                Session["AdminFullName"] = null;

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            check chk = new check();
            chk.ConfigarationName = "Admin";
            var scut = " from AdminID where username='"+txtUsername.Text+ "' and password='"+txtpassword.Text+"'";
            if(chk.int32Check("select count(*) "+scut)==1)
            {
                Session["AdminUserID"] = chk.stringCheck("select UserID "+scut); 
                Session["AdminFullName"] = chk.stringCheck("select FullName " + scut);
                Response.Redirect("Dashboard");
            }
            else
            {
                lblResult.Text = "Invalid Username/Password !";
            }


        }
    }
}