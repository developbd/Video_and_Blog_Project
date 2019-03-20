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
    public partial class Default : System.Web.UI.Page
    {
        private static int Active_Video;
        private static int Active_Blog;
        private static int Default_Show_V;
        private static int Default_Show_B;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Default_Show_V = Convert.ToInt32(txtShowFirstVideo.Text);
                Default_Show_B = Convert.ToInt32(txtShowFirstBlog.Text);
                //this.ViewState["vs"] = Default_Show_V;
                //Active_Blog= ShowBlog(Default_Show_B);
                //Active_Video= Show(Default_Show_V);
                ShowBlog(Default_Show_B);
                Show(Default_Show_V);
                
            }
            showHomeAdd();
           // HImageShow();
        }

        private void showHomeAdd()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from HomePageEdit order by ID DESC";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while(data.Read())
            {
                string Title = data["Title"].ToString();
                string Subtitle = data["Subtitle"].ToString();
                string Link = data["Link"].ToString(); ;
                string Image = data["Image"].ToString();
                showADD.Controls.Add(new LiteralControl(@"<div class='item'><figure class='premium-img'><img src = '"+Image+"' alt='carousel'><figcaption><h5>"+Title+"</h5><p>"+Subtitle+"</p></figcaption></figure><a target='_blank' href='"+Link+"' class='hover-posts'><span><i class='fa fa-play'></i>View Details</span></a></div>"));
            }
            con.Close();                                                                                                                                                                                                                            
        }
        
       SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
       SqlConnection conv = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
       SqlConnection conb = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        private int Show(int shownumber)
        {
            check chk = new check();
            chk.ConfigarationName = "Settings";
            int count = chk.int32Check("select count(*) from Registation_Tbl where Authority='TRUE' and TotalVideos > 3");
            string[] UserID = new string[count];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select top "+ shownumber + " UserID from Registation_Tbl where Authority='TRUE' and TotalVideos > 3 order by TotalView DESC";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            int i = 0;
            while(data.Read())
            {
                UserID[i] = data["UserID"].ToString();
                i++;
            }
            con.Close();
            int act_vid = 0;
            for (i = 0; i < count; i++)
            {
                chk.ConfigarationName = "video";
                if (chk.int32Check("select count(*) from video where UserID='" + UserID[i] + "' and publishAuth='TRUE'") > 3)
                {
                    act_vid++;
                    chk.ConfigarationName = "Settings";
                    string image = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + UserID[i] + "'");
                    string FastName = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID[i] + "'");
                    string LastName = chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID[i] + "'");
                    string Name = "&nbsp;&nbsp;" + FastName + " " + LastName;
                    string Link = "channel?=" + UserID[i];
                    string show_video_list = "";
                    SqlCommand ccc = new SqlCommand();
                    ccc.Connection = conv;
                    ccc.CommandText = "select top 4 * from video where UserID='" + UserID[i] + "' and publishAuth='TRUE' order by VideoView DESC";
                    conv.Open();
                    SqlDataReader dr = ccc.ExecuteReader();
                    while (dr.Read())
                    {
                        string videoImage = dr["ThambailLink"].ToString();
                        string title = dr["Title"].ToString();
                        string like = dr["VideoLike"].ToString();
                        string view = dr["VideoView"].ToString();
                        string postingdate = dr["postingDate"].ToString();
                        string watchLink = "watch?=" + dr["Video_ID"].ToString();
                        show_video_list += @"<div class='item large-3 medium-6 columns group-item-grid-default end'><div class='post thumb-border'><div class='post-thumb'><img src='" + videoImage + "' alt='new video'><a href='" + watchLink + "' class='hover-posts'><span><i class='fa fa-play'></i>Watch</span></a><div class='video-stats clearfix'><div class='thumb-stats pull-left'><i class='fa fa-thumbs-up'></i><span>" + like + "</span></div></div></div><div class='post-des'><h6><a href='" + watchLink + "' >" + title + "</a></h6><div class='post-stats clearfix'><p class='pull-left'><i class='fa fa-clock-o'></i><span>&nbsp;&nbsp;" + postingdate + " </span></p><p class='pull-left'><i class='fa fa-eye'></i><span>&nbsp;&nbsp;" + view + "</span></p></div></div></div></div>";
                    }
                    conv.Close();
                    showAll.Controls.Add(new LiteralControl(@"<section class='content'><div class='row secBg'><div class='large-12 columns'><div class='row column head-text clearfix'><p class='pull-left' style='color:#808080; '><img width='30' height='30' style='border-radius:50%;' src='" + image + "' /> <a href='" + Link + "'> " + Name + " </a></p> </div><div class='tabs-content' data-tabs-content='newVideos'><div class='tabs-panel is-active' id='new-all'><div class='row list-group'>" + show_video_list + " </div></div></div></div></div></section><br/>"));
                }
            }
            Active_Video = act_vid;
            return act_vid;
        }

        private int ShowBlog(int shownumber)
        {
            check chk = new check();
            chk.ConfigarationName = "Settings";
            int count = chk.int32Check("select count(*) from Registation_Tbl  where Authority='TRUE' and TotalBlog > 3");
            string[] UserID = new string[count];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select top " + shownumber + " UserID from Registation_Tbl where Authority='TRUE' and TotalBlog > 3 order by TotalBlog DESC";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            int i = 0;
            while (data.Read())
            {
                UserID[i] = data["UserID"].ToString();
                i++;
            }
            con.Close();
            int act_blog = 0;
            for (i = 0; i < count; i++)
            {
                chk.ConfigarationName = "blogcs";
                if (chk.int32Check("select count(*) from blog_Tbl where UserID='" + UserID[i] + "' and PublishAutho='TRUE' ") > 3)
                {
                    act_blog++;
                    chk.ConfigarationName = "Settings";
                    string image = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + UserID[i] + "'");
                    string FastName = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID[i] + "'");
                    string LastName = chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID[i] + "'");
                    string Name = "&nbsp;&nbsp;" + FastName + " " + LastName;
                    string Link = "channel?=" + UserID[i];
                    string show_video_list = "";
                    SqlCommand ccc = new SqlCommand();
                    ccc.Connection = conb;
                    ccc.CommandText = "select top 4 * from blog_Tbl where UserID='" + UserID[i] + "' and PublishAutho='TRUE' order by ID DESC";
                    conb.Open();
                    SqlDataReader dr = ccc.ExecuteReader();
                    while (dr.Read())
                    {
                        string videoImage = dr["LinkThumbnail"].ToString();
                        string title = dr["Title"].ToString();
                        //string like = dr["VideoLike"].ToString();
                        string view = dr["ViewBlog"].ToString();
                        string postingdate = dr["PostingDate"].ToString();
                        string watchLink = "Read?=" + dr["BlogID"].ToString();
                        show_video_list += @"<div class='item large-3 medium-6 columns group-item-grid-default end'><div class='post thumb-border'><div class='post-thumb'><img src='" + videoImage + "' alt='new video'><a href='" + watchLink + "' class='hover-posts'><span><i class='fa fa-book'></i>Read</span></a></div><div class='post-des'><h6><a href='" + watchLink + "' >" + title + "</a></h6><div class='post-stats clearfix'><p class='pull-left'><i class='fa fa-clock-o'></i><span>&nbsp;&nbsp;" + postingdate + " </span></p><p class='pull-left'><i class='fa fa-eye'></i><span>&nbsp;&nbsp;" + view + "</span></p></div></div></div></div>";
                    }
                    conb.Close();
                    showBlog.Controls.Add(new LiteralControl(@"<section class='content'><div class='row secBg'><div class='large-12 columns'><div class='row column head-text clearfix'><p class='pull-left' style='color:#808080; '><img width='30' height='30' style='border-radius:50%;' src='" + image + "' /> <a href='" + Link + "'> " + Name + " </a> </p>  </div><div class='tabs-content' data-tabs-content='newVideos'><div class='tabs-panel is-active' id='new-all'><div class='row list-group'>" + show_video_list + " </div></div></div></div></div></section><br/>"));
                }
            }
            Active_Blog = act_blog;
            return act_blog;


        }

        //private void HImageShow()
        //{
        //    check chk = new check();
        //    chk.ConfigarationName = "Settings";
        //    if (chk.int32Check("select count(*) from Advertisement where HV='Horizontal'") > 0)
        //    {
        //        GridView1.Visible = true;
        //        var ID = chk.stringCheck("select top 1 ID from Advertisement where HV='Horizontal' ORDER BY NEWID()");
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "select * from Advertisement where ID="+ID;
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        GridView1.DataSource = dr;
        //        GridView1.DataBind();
                
        //        con.Close();
        //        //AdvertisementShowHorzontal.ImageUrl = chk.stringCheck("select Image from Advertisement where ID="+ID);
        //        //AdvertisementShowHorzontal.PostBackUrl = chk.stringCheck("select Link from Advertisement where ID=" + ID);
                
        //    }
        //    else
        //    {
        //        GridView1.Visible = false;
        //    }
        //}

        protected void btnViewMoreVideo_Click(object sender, EventArgs e)
        {
            Default_Show_V += 10;
            Show(Default_Show_V);
            btnViewMoreBlog.Visible = false;
        }

        protected void btnViewMoreBlog_Click(object sender, EventArgs e)
        {
            Default_Show_B += 10;
            ShowBlog(Default_Show_B);
            btnViewMoreVideo.Visible = false;
        }

    }
}