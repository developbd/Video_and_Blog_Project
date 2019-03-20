using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            check chk = new check();
            chk.ConfigarationName = "blogcs";
            lblTotalBlog.Text = chk.int32Check("select count(*) from blog_Tbl").ToString();
            lblTodayBlogPost.Text = chk.int32Check("select count(*) from blog_Tbl where Date='" + DateTime.Now.ToString("dd")+"'").ToString();
            lblUnpublishBlog.Text = chk.int32Check("select count(*) from blog_Tbl where PublishAutho='FALSE'").ToString();
            lblPubishBlog.Text = chk.int32Check("select count(*) from blog_Tbl where PublishAutho='TRUE'").ToString();

            chk.ConfigarationName = "video";
            lblTotalVideo.Text = chk.int32Check("select count(*) from video").ToString();
            lblToadypostVideo.Text = chk.int32Check("select count(*) from video where Date='" + DateTime.Now.ToString("dd") + "'").ToString();
            lblUnpublishedVideo.Text = chk.int32Check("select count(*) from video where publishAuth='FALSE'").ToString();
            lblPublishedVideo.Text = chk.int32Check("select count(*) from video where publishAuth='TRUE'").ToString();

        }
    }
}