using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay
{
    public partial class about : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                check chk = new check();
                chk.ConfigarationName = "Settings";
                string shortcut = "from Registation_Tbl where UserID='" + UserID + "'";
                lblSite.Text = chk.stringCheck("select Website "+shortcut);
                lblPhone.Text = chk.stringCheck("select Phone " + shortcut);
                lblEmail.Text = chk.stringCheck("select Email " + shortcut);
                lblDetails.Text = chk.stringCheck("select Description " + shortcut);
            }
        }
    }
}