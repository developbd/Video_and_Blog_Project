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
    public partial class SideBar : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Admin"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from AuthorisePage where UserID='"+Session["AdminUserID"] + "' order by PageName";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();            
            while(data.Read())
            {
                string PageName = data["PageName"].ToString();
                string PageLink = data["PageLink"].ToString();
                showSideBar.Controls.Add(new LiteralControl("<li class='nav-item'><a href='"+PageLink+"'><span class='menu-title'>"+PageName+"</span></a></li>"));
            }
            con.Close();


        }

    }
}