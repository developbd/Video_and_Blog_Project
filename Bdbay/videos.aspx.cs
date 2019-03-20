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
using System.IO;

namespace Bdbay
{
    public partial class videos : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from video where UserID='" + UserID+"' order by ID DESC";
                con.Open();
                SqlDataReader data = cmd.ExecuteReader();
                GridView1.DataSource = data;
                GridView1.DataBind();
                con.Close();
            }


        }

        //protected void LinkButton1_Command(object sender, CommandEventArgs e)
        //{
        //    string VideoID = e.CommandArgument.ToString();
        //    check chk = new check();
        //    chk.ConfigarationName = "video";
        //    string UserID = chk.stringCheck("select UserID from video where video='" + VideoID+"'");
        //    Response.Redirect("upload?Edit="+VideoID+"&id="+UserID);
        //}

       


    }
}