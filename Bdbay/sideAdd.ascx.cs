using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;


namespace Bdbay
{
    public partial class sideAdd : System.Web.UI.UserControl
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection conb = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[""] != null && Request.QueryString[""]!="")
            {
                string ID = Request.QueryString[""].ToString();
                if(ID!="")
                {
                check chk = new check();
                chk.ConfigarationName = "Settings";
                
                string Fast_count = ID.Substring(0,1);
                
                if (Fast_count=="V")
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    showAdd.Controls.Clear();
                    chk.ConfigarationName = "video";
                    string user_ID = chk.stringCheck("select UserID from video where Video_ID='" + ID + "'");

                    cmd.CommandText = "select top 10 * from video where publishAuth='TRUE' and UserID='"+ user_ID + "' order by newid()";
                    con.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while (data.Read())
                    {
                        string Video_ID = data["Video_ID"].ToString();
                        string Title = data["Title"].ToString();
                        string postingDate = data["postingDate"].ToString();
                        string UserID = data["UserID"].ToString();
                        string Image = data["ThambailLink"].ToString();
                        chk.ConfigarationName = "Settings";
                        string fastname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'");
                        showAdd.Controls.Add(new LiteralControl(@" <div class='media-object stack-for-small'><div class='media-object-section'><div class='recent-img'><img src='" + Image + "' alt='recent'><a href='watch?=" + Video_ID + "' class='hover-posts'><span><i class='fa fa-play'></i></span></a></div></div><div class='media-object-section'><div class='media-content'><h6><a href = 'watch?=" + Video_ID + "' >" + Title + "</a></h6><p><i class='fa fa-user'></i><span>" + fastname + "</span><i class='fa fa-clock-o'></i><span>" + postingDate + "</span></p></div></div></div>"));

                    }
                    con.Close();

                    cmd.CommandText = "select top 10 * from video where publishAuth='TRUE' and UserID!='"+ user_ID + "' order by newid()";
                    con.Open();
                    SqlDataReader data2 = cmd.ExecuteReader();
                    while (data2.Read())
                    {
                        string Video_ID = data2["Video_ID"].ToString();
                        string Title = data2["Title"].ToString();
                        string postingDate = data2["postingDate"].ToString();
                        string UserID = data2["UserID"].ToString();
                        string Image = data2["ThambailLink"].ToString();
                        chk.ConfigarationName = "Settings";
                        string fastname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'");
                        showAdd.Controls.Add(new LiteralControl(@" <div class='media-object stack-for-small'><div class='media-object-section'><div class='recent-img'><img src='" + Image + "' alt='recent'><a href='watch?=" + Video_ID + "' class='hover-posts'><span><i class='fa fa-play'></i></span></a></div></div><div class='media-object-section'><div class='media-content'><h6><a href = 'watch?=" + Video_ID + "' >" + Title + "</a></h6><p><i class='fa fa-user'></i><span>" + fastname + "</span><i class='fa fa-clock-o'></i><span>" + postingDate + "</span></p></div></div></div>"));

                    }
                    con.Close();


                }
                else if(Fast_count == "B")
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conb;
                    showAdd.Controls.Clear();
                    chk.ConfigarationName = "blogcs";
                    string user_ID = chk.stringCheck("select UserID from blog_Tbl where BlogID='" + ID + "'");

                    cmd.CommandText = "select top 10 * from blog_Tbl where PublishAutho='TRUE' and UserID='" + user_ID + "' order by newid()";
                    conb.Open();
                    SqlDataReader data = cmd.ExecuteReader();
                    while(data.Read())
                    {
                        string Video_ID = data["BlogID"].ToString();
                        string Title = data["Title"].ToString();
                        Title = (Title.ToString().Length > 30) ? (Title.ToString().Substring(0, 30) + "...") : (Title);
                        string postingDate = data["PostingDate"].ToString();
                        string UserID = data["UserID"].ToString();
                        string Image = data["LinkThumbnail"].ToString();
                        chk.ConfigarationName = "Settings";
                        string fastname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'");
                        showAdd.Controls.Add(new LiteralControl(@" <div class='media-object stack-for-small'><div class='media-object-section'><div class='recent-img'><img src='" + Image + "' alt='recent'><a href='Read?=" + Video_ID + "' class='hover-posts'><span><i class='fa fa-play'></i></span></a></div></div><div class='media-object-section'><div class='media-content'><h6><a href = 'watch?=" + Video_ID + "' >" + Title + "</a></h6><p><i class='fa fa-user'></i><span>" + fastname + "</span><i class='fa fa-clock-o'></i><span>" + postingDate + "</span></p></div></div></div>"));

                    }
                    conb.Close();

                    cmd.CommandText = "select top 10 * from blog_Tbl where PublishAutho='TRUE' and UserID!='" + user_ID + "' order by newid()";
                    conb.Open();
                    SqlDataReader data2 = cmd.ExecuteReader();
                    while (data2.Read())
                    {
                        string Video_ID = data2["BlogID"].ToString();
                        string Title = data2["Title"].ToString();
                        Title = (Title.ToString().Length > 30) ? (Title.ToString().Substring(0, 30) + "...") : (Title);
                        string postingDate = data2["PostingDate"].ToString();
                        string UserID = data2["UserID"].ToString();
                        string Image = data2["LinkThumbnail"].ToString();
                        chk.ConfigarationName = "Settings";
                        string fastname = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'");
                        showAdd.Controls.Add(new LiteralControl(@" <div class='media-object stack-for-small'><div class='media-object-section'><div class='recent-img'><img src='" + Image + "' alt='recent'><a href='Read?=" + Video_ID + "' class='hover-posts'><span><i class='fa fa-play'></i></span></a></div></div><div class='media-object-section'><div class='media-content'><h6><a href = 'watch?=" + Video_ID + "' >" + Title + "</a></h6><p><i class='fa fa-user'></i><span>" + fastname + "</span><i class='fa fa-clock-o'></i><span>" + postingDate + "</span></p></div></div></div>"));

                    }
                    conb.Close();

                }
            }
                
            }

        }


        SqlConnection cons = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);


    }
}