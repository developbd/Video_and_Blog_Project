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
    public partial class Like : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                check chk = new check();
                chk.ConfigarationName = "video";
                string UserID = Session["UserID"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Like_Tbl where UserID='" + UserID + "' order by ID DESC";
                con.Open();
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    string VideoID = data["VideoID"].ToString();
                    string ShortCut = "from video where Video_ID='" + VideoID + "'";
                    int ID = Convert.ToInt32(data["ID"]);
                    string Image = chk.stringCheck("select ThambailLink " + ShortCut);
                    string Title = chk.stringCheck("select Title " + ShortCut);
                    string PostingDate = chk.stringCheck("select postingDate " + ShortCut);
                    string view = chk.stringCheck("select VideoLike " + ShortCut);
                    string HistoryDate = chk.stringCheck("select date from Like_Tbl where UserID='" + UserID + "' and VideoID='" + VideoID + "'");
                    string link = "watch?=" + VideoID;
                    //<a href='#' class='secondary-button'><i class='fa fa-play-circle'></i>UnLike</a>
                    likeShow.Controls.Add(new LiteralControl(@"<div class='item large-4 medium-6 columns list'><div class='post thumb-border'><div class='post-thumb'><img src='" + Image + "' alt='new video'><a href='" + link + "' class='hover-posts'><span><i class='fa fa-play'></i>Watch Video</span></a></div><div class='post-des'><h6><a href = '" + link + "' > " + Title + " </a></h6><div class='post-stats clearfix'><p class='pull-left'><i class='fa fa-clock-o'></i><span>" + PostingDate + "</span></p><p class='pull-left'><i class='fa fa-thumbs-up'></i><span>" + view + "</span></p></div><div class='post-button'><a href='" + link + "' class='secondary-button'><i class='fa fa-play-circle'></i>watch video</a></div> <hr /><div class='post-stats clearfix'><p class='pull-left'><span>Like Date: </span></p><p class='pull-left'><i class='fa fa-clock-o'></i><span>" + HistoryDate + "</span></p></div></div></div></div>"));
                }
                con.Close();
            }
            else
            {
                lblMessege.Text = "No Likes. Please Login ?";
            }
        }
    }
}