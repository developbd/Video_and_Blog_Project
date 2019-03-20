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
    public partial class profile : System.Web.UI.Page
    {
        SqlConnection conv = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection conb = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[""] != null)
            {
                string ID = Request.QueryString[""].ToString();
                check chk = new check();
                chk.ConfigarationName = "Settings";
                string shortCut = " from Registation_Tbl where ID="+ID;
                lblFastname.Text = chk.stringCheck("select FastName "+shortCut);
                lblLastname.Text = chk.stringCheck("select LastName " + shortCut);
                lblAddress.Text = chk.stringCheck("select Address " + shortCut);
                lblDetails.Text = chk.stringCheck("select Description " + shortCut);
                lblEmail.Text = chk.stringCheck("select Email " + shortCut);
                lblJoinDate.Text = chk.stringCheck("select JoinDate " + shortCut);
                lblMobile.Text = chk.stringCheck("select Phone " + shortCut);
                lblPassword.Text = chk.stringCheck("select Password " + shortCut);
                lblTotalBlog.Text = chk.stringCheck("select TotalBlog " + shortCut);
                lblTotalVideo.Text = chk.stringCheck("select TotalVideos " + shortCut);
                string UserID = chk.stringCheck("select UserID " + shortCut);

                SqlCommand cmd = new SqlCommand();
                pnlBlog.Controls.Clear();
                pnlVideo.Controls.Clear();
                cmd.Connection = conb;
                cmd.CommandText = "select * from blog_Tbl where UserID='"+UserID+"'";
                conb.Open();
                SqlDataReader data = cmd.ExecuteReader();
                while(data.Read())
                {
                    string image = data["LinkThumbnail"].ToString();
                    string title = data["Title"].ToString();
                    string BlogID = data["BlogID"].ToString();
                    pnlBlog.Controls.Add(new LiteralControl("<figure class='col-lg-3 col-md-6 col-12'><a href='../Read?="+BlogID+"'><img class='img-thumbnail img-fluid' src='../" + image+"' alt='"+title+"' /><p>"+title+ "</p><a href='pay?id="+BlogID+"&ref=AuthoriseBlog&UsrID="+Session["AdminUserID"].ToString()+ "' class='btn btn-info'>Pay</a> <a href='watch?="+BlogID+"&ref=AuthoriseBlog' class='btn btn-info'>Edit</a></a></figure>"));

                }
                conb.Close();

                cmd.Connection = conv;
                cmd.CommandText = "select * from video where UserID='"+UserID+"'";
                conv.Open();
                SqlDataReader datav = cmd.ExecuteReader();
                while(datav.Read())
                {
                    string image = datav["ThambailLink"].ToString();
                    string title = datav["Title"].ToString();
                    string VideoID = datav["Video_ID"].ToString();
                    string Video_Src ="../"+ datav["videoLink"].ToString();
                    pnlVideo.Controls.Add(new LiteralControl("<div class='col-lg-3 col-md-6 col-12'><div class='embed-responsive embed-responsive-item embed-responsive-16by9'><video src = '"+Video_Src+"' class='img-thumbnail' controls='controls' width='640' height='360' /></div><p>"+title+ "</p><a href='pay?id="+VideoID+"&ref=AuthoriseVideo&UsrID="+Session["AdminUserID"].ToString()+ "' class='btn btn-info'>Pay</a> <a href='watch?="+VideoID+"&ref=AuthoriseVideo' class='btn btn-info'>Edit</a></div>"));
                }
                conv.Close();

            }
            else
            {
                Response.Redirect("ShowUser");
            }
        }
    }
}