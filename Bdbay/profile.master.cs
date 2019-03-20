using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay
{
    public partial class profile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["UserFastName"] != null && Session["UserLastName"] != null)
            {
                Session.Timeout = 100000;

                check chk = new check();
                chk.ConfigarationName = "Settings";

                Panel1.CssClass = "topProfile ";
                Panel1.Style["position"] = "relative";
                Panel1.Style["height"] = "350px";
                Panel1.Style["background"] = "url('../CoverPhoto/"+chk.stringCheck("select CoverPhoto from Registation_Tbl where UserID='"+ Session["UserID"].ToString() + "'") +"') no-repeat";
				Panel1.Style["background-position"] = "center";
                Panel1.Style["background-size"] = "cover";
                Panel1.Style["width"] = "100%";
                Panel1.Style["margin-bottom"] = "90px";
                UserImage.ImageUrl = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                lblFullname.Text = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'") +" "+ chk.stringCheck("select LastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                lbljoinDate.Text = chk.stringCheck("select JoinDate from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");

                chk.ConfigarationName = "video";
                lblTotalSubscrib.Text = chk.stringCheck("select count(*) from Subscribe where SubscribeID='" + Session["UserID"].ToString() + "'");
                lblVideos.Text = chk.stringCheck("select count(*) from video where UserID='" + Session["UserID"].ToString() + "'");
                lblViews.Text = chk.stringCheck("select sum(VideoView) from video where UserID='" + Session["UserID"].ToString() + "'");

                chk.ConfigarationName = "blogcs";
                lblBlog.Text = chk.stringCheck("select count(*) from blog_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                lblBlogView.Text = chk.stringCheck("select SUM(ViewBlog) from blog_Tbl where UserID='" + Session["UserID"].ToString() + "'");
            }
            else
            {
                Response.Redirect("login");
            }
        }
    }
}