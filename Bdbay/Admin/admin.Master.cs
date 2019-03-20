using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay.Admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminUserID"] == null && Session["AdminFullName"] == null)
            {
                Response.Redirect("~/Admin/");
            }
        }
    }
}