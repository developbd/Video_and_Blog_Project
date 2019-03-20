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
using System.Drawing;
using System.Drawing.Imaging;

namespace Bdbay.Admin
{
    public partial class bodyShow : System.Web.UI.UserControl
    {
        SqlConnection Settings_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        SqlConnection con_blog = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        SqlConnection con_Video = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUserID"] == null && Session["AdminFullName"] == null)
            {
                Response.Redirect("~/Admin/");
            }
            else
            {

                if (Request.QueryString[""]!=null)
                {
                    SqlCommand cmd = new SqlCommand();
                    check chk = new check();
                    string Qurey = Request.QueryString[""].ToString();
                    Show.Controls.Clear();
                    if (Qurey == "Blog")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_blog;
                        cmd.CommandText = "select * from blog_Tbl order by ID DESC";
                        con_blog.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["BlogID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["PostingDate"].ToString();
                            string PublishAutho = data["PublishAutho"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref="+Qurey+ "&UsrID=" + UserID + "'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Read </a></td></tr> "));
                        }
                        con_blog.Close();

                    }
                    else if (Qurey == "Video")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_Video;
                        cmd.CommandText = "select * from video order by ID DESC";
                        con_Video.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["Video_ID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["postingDate"].ToString();
                            string PublishAutho = data["publishAuth"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref=" + Qurey + "&UsrID=" + UserID + "'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Watch </a></td></tr> "));
                        }
                        con_Video.Close();
                    }
                    else if(Qurey== "NonAuthoriseBlog")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_blog;
                        cmd.CommandText = "select * from blog_Tbl where PublishAutho='FALSE'  order by ID DESC";
                        con_blog.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["BlogID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["PostingDate"].ToString();
                            string PublishAutho = data["PublishAutho"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref=" + Qurey + "&UsrID=" + UserID + "'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Read </a></td></tr> "));
                        }
                        con_blog.Close();
                    }
                    else if(Qurey== "NonAuthoriseVideo")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_Video;
                        cmd.CommandText = "select * from video where publishAuth='FALSE' order by ID DESC";
                        con_Video.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["Video_ID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["postingDate"].ToString();
                            string PublishAutho = data["publishAuth"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref=" + Qurey + "&UsrID=" + UserID + "'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Watch </a></td></tr> "));
                        }
                        con_Video.Close();
                    }
                    else if (Qurey == "AuthoriseBlog")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_blog;
                        cmd.CommandText = "select * from blog_Tbl where PublishAutho='TRUE'  order by ID DESC";
                        con_blog.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["BlogID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["PostingDate"].ToString();
                            string PublishAutho = data["PublishAutho"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref=" + Qurey + "&UsrID=" + UserID + "'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Read </a></td></tr> "));
                        }
                        con_blog.Close();
                    }
                    else if (Qurey == "AuthoriseVideo")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_Video;
                        cmd.CommandText = "select * from video where publishAuth='TRUE' order by ID DESC";
                        con_Video.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["Video_ID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["postingDate"].ToString();
                            string PublishAutho = data["publishAuth"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref=" + Qurey + "&UsrID=" + UserID+"'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Watch </a></td></tr> "));
                        }
                        con_Video.Close();
                    }
                    else if(Qurey == "PandingBlog")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_blog;
                        cmd.CommandText = "select * from blog_Tbl where PublishAutho='PANDING'  order by ID DESC";
                        con_blog.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["BlogID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["PostingDate"].ToString();
                            string PublishAutho = data["PublishAutho"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref=" + Qurey + "&UsrID=" + UserID + "'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Read </a></td></tr> "));
                        }
                        con_blog.Close();
                    }
                    else if (Qurey == "PandingVideo")
                    {
                        chk.ConfigarationName = "Settings";
                        cmd.Connection = con_Video;
                        cmd.CommandText = "select * from video where publishAuth='PANDING' order by ID DESC";
                        con_Video.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string BlogID = data["Video_ID"].ToString();//data[""].ToString();
                            string Title = data["Title"].ToString();
                            string UserID = data["UserID"].ToString();
                            string Fullname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                            string Catagory = data["Catagory"].ToString();
                            string PostingDate = data["postingDate"].ToString();
                            string PublishAutho = data["publishAuth"].ToString();
                            string Pament = data["Pament"].ToString();
                            Show.Controls.Add(new LiteralControl(@"<tr><td>" + BlogID + "</td><td>" + Title + "</td><td>" + Fullname + "</td><td>" + Catagory + "</td><td>" + PostingDate + "</td><td>" + PublishAutho + "</td><td>" + Pament + " (<a href='pay.aspx?id=" + BlogID + "&ref=" + Qurey + "&UsrID=" + UserID + "'>Pay Here</a>)</td><td><a href = 'watch.aspx?=" + BlogID + "&ref=" + Qurey + "' > Watch </a></td></tr> "));
                        }
                        con_Video.Close();
                    }












                }

            }



        }
    }
}