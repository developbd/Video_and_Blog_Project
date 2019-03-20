using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace Bdbay
{
    public partial class blog : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from blog_Tbl where UserID='" + UserID + "' order by ID DESC";
                con.Open();
                SqlDataReader data = cmd.ExecuteReader();
                GridView1.DataSource = data;
                GridView1.DataBind();
                con.Close();


            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            //edit
            Response.Redirect("write?bid="+e.CommandArgument.ToString());
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            //delete
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from blog_Tbl where BlogID='"+e.CommandArgument.ToString()+"' ";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.CommandText = "DROP TABLE "+e.CommandArgument.ToString()+";";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}