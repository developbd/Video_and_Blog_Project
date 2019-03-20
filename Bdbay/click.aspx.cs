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
    public partial class click : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString[""]!=null)
            {
                var ID = Request.QueryString[""].ToString();
                check chk = new check();
                chk.ConfigarationName = "Settings";
                int count = chk.int32Check("select Click from Advertisement where ID=" + ID);
                count++;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Advertisement set Click=" + count + "  where ID=" + ID;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(chk.stringCheck("select Link from Advertisement where ID=" + ID));
            }
            else
            {
                Response.Redirect("Error?=Not Found");
            }

        }
    }
}