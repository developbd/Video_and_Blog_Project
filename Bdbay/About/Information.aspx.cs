using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay.About
{
    public partial class Information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            check chk = new check();
            chk.ConfigarationName = "video";
            lblVideo.Text = chk.stringCheck("select count(*) from video");
            lblSubscribers.Text = chk.stringCheck("select count(*) from Subscribe");
            lblTodayView.Text = chk.stringCheck("select count(*) from DailyView where Date=" + DateTime.Now.ToString("dd") + " and Month=" + DateTime.Now.ToString("MM") + " and Year=" + DateTime.Now.ToString("yyyy") + " ");

            chk.ConfigarationName = "Settings";
            lblView.Text = chk.stringCheck("select sum(TotalView) from Registation_Tbl");

            chk.ConfigarationName = "blogcs";
            lblBlog.Text = chk.stringCheck("select count(*) from blog_Tbl");
                 
            
        }
    }
}