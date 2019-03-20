using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Bdbay.Admin
{
    public partial class ShowUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            string ID = e.CommandArgument.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from Registation_Tbl where ID="+ID+"";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();



        }
    }
}