using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay.Admin
{
    public partial class ShowAdminStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            var ID = e.CommandArgument.ToString();
            check chk = new check();
            chk.ConfigarationName = "Admin";
            Response.Redirect("AdminorStaff?Edit="+ID+ "&UserID="+chk.stringCheck("select UserID from AdminID where ID="+ID));
        }
    }
}