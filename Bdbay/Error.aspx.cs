using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString[""] == "Authority_Cancle")
            {
                lblMessege.Text = "Authority is Delete this Video ?";
            }
        }
    }
}