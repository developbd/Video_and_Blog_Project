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
    public partial class subscribe : System.Web.UI.Page
    {
        SqlConnection video_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                check chk = new check();
                chk.ConfigarationName = "Settings";
                string UserID = Session["UserID"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = video_Conf;
                cmd.CommandText = "select * from Subscribe where UserID='" + UserID + "'";
                video_Conf.Open();
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    string subscribeID = data["SubscribeID"].ToString();
                    string Image = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + subscribeID + "'");
                    string FastName = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + subscribeID + "'");
                    string LastName = chk.stringCheck("select LastName from Registation_Tbl where UserID='" + subscribeID + "'");
                    string Name = FastName + " " + LastName;
                    string link = "channel?="+ subscribeID;
                    subscribeShow.Controls.Add(new LiteralControl(@"<div class='large-2 small-6 medium-3 columns'><div class='follower'><div class='follower-img'><a href = '" + link + "' ><img src='" + Image + "' alt='followers'></a></div><a href='" + link + "' ><span >" + Name + "</span></a><a class='btn-sub' href='Unsubscribe?=" + subscribeID + "'>Unsubscribe</a></div></div>"));
                }
                video_Conf.Close();
            }
            else
            {
                Response.Redirect("Login");

            }



        }
    }
}