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
    public partial class Unsubscribe : System.Web.UI.Page
    {
        SqlConnection video_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["UserID"] != null && Session["UserFastName"] != null && Session["UserLastName"] != null)
            {
                if (Request.QueryString[""] != null)
                {
                    string SID = Request.QueryString[""].ToString();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = video_Conf;
                    cmd.CommandText = "delete from Subscribe where UserID='" + Session["UserID"].ToString() + "' and SubscribeID='" + SID + "' ";
                    video_Conf.Open();
                    cmd.ExecuteNonQuery();
                    video_Conf.Close();
                    Response.Redirect("subscribe");
                }
                else
                {
                    Response.Redirect("subscribe");
                }

            }
            else
            {
                Response.Redirect("Login");
            }


        }
    }
}