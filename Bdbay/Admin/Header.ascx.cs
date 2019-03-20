using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay.Admin
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            check chk = new check();
            chk.ConfigarationName = "Admin";
            if (Session["AdminUserID"] != null && Session["AdminFullName"] != null)
            {
                lblFullname.Text =  Session["AdminFullName"].ToString();
                Imageshow.ImageUrl = "Image/" + chk.stringCheck("select Image from AdminID where UserID='"+Session["AdminUserID"].ToString()+"'");
            }
            else
            {
                Response.Redirect("~/Admin/");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["AdminUserID"] = null; Session["AdminFullName"] = null;
            Response.Redirect("~/Admin/");
        }
    }
}