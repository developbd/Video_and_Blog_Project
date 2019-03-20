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
    public partial class channel : System.Web.UI.Page
    {
        SqlConnection blogcon = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString[""]!=null)
            {

                if (Session["UserID"] != null)
                {
                    string uid = Session["UserID"].ToString();
                    check chk2 = new check();
                    chk2.ConfigarationName = "video";
                    string ID = Request.QueryString[""].ToString();
                    if (chk2.int32Check("select count(*) from Subscribe where UserID='" + uid + "' and SubscribeID='" + ID + "' ") == 0)
                    {
                        btnSubscribe.Visible = true;
                        btnUnsubscribe.Visible = false;
                    }
                    else
                    {
                        btnSubscribe.Visible = false;
                        btnUnsubscribe.Visible = true;
                    }
                    if (uid == Request.QueryString[""].ToString())
                    {
                        btnSubscribe.Visible = false;
                        btnUnsubscribe.Visible = false;
                    }
                }
                else
                {
                    btnSubscribe.Visible = false;
                    btnUnsubscribe.Visible = false;
                }
                check chk = new check();
                chk.ConfigarationName = "Settings";
                string UserID = Request.QueryString[""].ToString();

                if (chk.int32Check("select count(*) from Registation_Tbl where UserID='" + UserID + "'") == 1)
                {
                    Panel1.CssClass = "topProfile ";
                    Panel1.Style["position"] = "relative";
                    Panel1.Style["height"] = "350px";
                    Panel1.Style["background"] = "url('../CoverPhoto/" + chk.stringCheck("select CoverPhoto from Registation_Tbl where UserID='" + UserID + "'") + "') no-repeat";
                    Panel1.Style["background-size"] = "cover";
                    Panel1.Style["width"] = "100%";
                    Panel1.Style["margin-bottom"] = "90px";
                    UserImage.ImageUrl = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + UserID + "'");
                    lblFullname.Text = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'") + " " + chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                    lbljoinDate.Text = chk.stringCheck("select JoinDate from Registation_Tbl where UserID='" + UserID + "'");
                    lblDescription.Text = chk.stringCheck("select Description from Registation_Tbl where UserID='" + UserID + "'");
                    lblEmail.Text = chk.stringCheck("select Email from Registation_Tbl where UserID='" + UserID + "'");
                    lblsite.Text = chk.stringCheck("select Website from Registation_Tbl where UserID='" + UserID + "'");
                    //lblPhone.Text = chk.stringCheck("select Phone from Registation_Tbl where UserID='" + UserID + "'");
                    
                    chk.ConfigarationName = "video";
                    lblVideo.Text = chk.stringCheck("select count(*) from video where UserID='" + UserID + "'");
                    lblView.Text = chk.stringCheck("select SUM(VideoView) from video where UserID='" + UserID + "'");

                    chk.ConfigarationName = "blogcs";
                    lblBlogView.Text = chk.stringCheck("select SUM(ViewBlog) from blog_Tbl where UserID='" + UserID + "'");
                    chk.ConfigarationName = "video";

                    SqlCommand cmd = new SqlCommand();
                    if (chk.int32Check("select count(*) from video where UserID='" + UserID + "'") != 0)
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "select * from video where UserID='" + UserID + "'";
                        con.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        while (data.Read())
                        {
                            string Image = data["ThambailLink"].ToString();
                            string Like = data["VideoLike"].ToString();
                            string Title = data["Title"].ToString();
                            Title = (Title.ToString().Length > 25) ? (Title.ToString().Substring(0, 25) + "...") : (Title);
                            string Posting_Date = data["postingDate"].ToString();
                            string View = data["VideoView"].ToString();
                            string link = "watch?=" + data["Video_ID"].ToString();
                            VideoShow.Controls.Add(new LiteralControl(@"<div class='item large-4 medium-6 columns group-item-grid-default end'><div class='post thumb-border'><div class='post-thumb'><img src='" + Image + "' alt='new video'><a href='" + link + "' class='hover-posts'><span><i class='fa fa-play'></i>Watch Video</span></a><div class='video-stats clearfix'><div class='thumb-stats pull-left'><i class='fa fa-thumbs-o-up'></i><span>" + Like + "</span></div></div></div><div class='post-des'><h6><a href='" + link + "' >" + Title + "</a></h6><div class='post-stats clearfix'><p class='pull-left'><i class='fa fa-clock-o'></i><span>" + Posting_Date + "</span></p><p class='pull-left'><i class='fa fa-eye'></i><span>" + View + "</span></p></div><div class='post-summary'><p> </p></div><div class='post-button'><a href = '" + link + "' class='secondary-button'><i class='fa fa-play-circle'></i>watch video</a></div></div></div></div>"));
                        }
                        con.Close();
                    }
                    else
                    {
                        lblVideoHave.Text = "No Video Upload This Chennel.";
                    }

                    chk.ConfigarationName = "blogcs";
                    lblBlog.Text = chk.stringCheck("select count(*) from blog_Tbl where UserID='"+UserID+"'");
                    if (chk.int32Check("select count(*) from blog_Tbl where UserID='" + UserID + "'") != 0)
                    {
                        cmd.Connection = blogcon;
                        cmd.CommandText = "select * from blog_Tbl where UserID='" + UserID + "'";
                        blogcon.Open();
                        SqlDataReader blogdata = cmd.ExecuteReader();
                        blogShow.Controls.Clear();
                        while (blogdata.Read())
                        {
                            string Image = blogdata["LinkThumbnail"].ToString();
                            string Title = blogdata["Title"].ToString();
                            Title = (Title.ToString().Length > 25) ? (Title.ToString().Substring(0, 25) + "...") : (Title);
                            string Posting_Date = blogdata["PostingDate"].ToString();
                            string link = "Read?=" + blogdata["BlogID"].ToString();
                            string View = blogdata["ViewBlog"].ToString();
                            blogShow.Controls.Add(new LiteralControl(@"<div class='item large-4 medium-6 columns group-item-grid-default end'><div class='post thumb-border'><div class='post-thumb'><img src='" + Image + "' alt='new video'><a href='" + link + "' class='hover-posts'><span><i class='fa fa-book'></i> Read </span></a></div><div class='post-des'><h6><a href='" + link + "' >" + Title + "</a></h6><div class='post-stats clearfix'><p class='pull-left'><i class='fa fa-clock-o'></i><span>" + Posting_Date + "</span></p><p class='pull-left'><i class='fa fa-eye'></i><span> "+View+" </span></p></div><div class='post-summary'><p> </p></div><div class='post-button'><a href = '" + link + "' class='secondary-button'><i class='fa fa-play-circle'></i>watch video</a></div></div></div></div>"));
                        }
                        blogcon.Close();
                    }
                    else
                    {
                        lblBlogHave.Text = "No Blog Write this Channel.";
                    }


                }
                else
                {
                    Response.Redirect("subscribe");
                }
            }
            else
            {
                Response.Redirect("Default");
            }
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            if(Request.QueryString[""]!=null)
            {

                if (Session["UserID"] != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Subscribe (UserID,SubscribeID,datetime,date) values(@UserID,@SubscribeID,@datetime,@date)";
                    cmd.Parameters.AddWithValue("@UserID",Session["UserID"].ToString());
                    cmd.Parameters.AddWithValue("@SubscribeID",Request.QueryString[""].ToString());
                    cmd.Parameters.AddWithValue("@datetime",DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd MMM yyyy"));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("channel?=" + Request.QueryString[""].ToString());
                }
            }
        }

        protected void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            if (Request.QueryString[""] != null)
            {

                if (Session["UserID"] != null)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from Subscribe where UserID='" + Session["UserID"].ToString() + "' and SubscribeID='" + Request.QueryString[""].ToString() + "' ";                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("channel?=" + Request.QueryString[""].ToString());
                }
            }
        }
    }
}