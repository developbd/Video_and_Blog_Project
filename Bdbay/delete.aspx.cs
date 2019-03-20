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
    public partial class delete : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection Conb = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if( Session["UserID"]!=null &&
                Request.QueryString[""]!=null &&
                Request.QueryString["Cmdid"] != null &&
                Request.QueryString["url"] != null &&
                Request.QueryString["ses"] != null &&
                Request.QueryString["p"] != null &&
                Request.QueryString["mc"] != null)
            {
                string VideoID = Request.QueryString[""].ToString();
                string Command_ID = Request.QueryString["Cmdid"].ToString();
                string Skip = Request.QueryString["url"].ToString();
                string Session_ID = Request.QueryString["ses"].ToString();
                string Page = Request.QueryString["p"].ToString();
                string MC = Request.QueryString["mc"].ToString();
                if (Session["UserID"].ToString() == Session_ID)
                {
                    if(MC=="sub")
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = Conn;
                        cmd.CommandText = "delete from SubCommand where ID=" + Command_ID;
                        Conn.Open();
                        cmd.ExecuteNonQuery();
                        Conn.Close();
                    }
                    else if(MC=="Main")
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = Conn;
                        cmd.CommandText = "delete from " + VideoID + " where ID=" + Command_ID;
                        Conn.Open();
                        cmd.ExecuteNonQuery();
                        Conn.Close();
                    }
                   

                    if(Skip=="FALSE")
                    Response.Redirect(Page+"?="+VideoID+"&SK=FALSE");
                    else
                    Response.Redirect(Page + "?=" + VideoID);


                }
                else
                {
                    Response.Redirect("error?=ID Not Found ");
                }

            }
            else if (Request.QueryString["BID"] != null && Request.QueryString["CMDID"] != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conb;
                cmd.CommandText = "delete from BlogCommand where ID=" + Request.QueryString["CMDID"].ToString() + " and BlogID='" + Request.QueryString["BID"].ToString() + "' ";
                Conb.Open();
                cmd.ExecuteNonQuery();
                Conb.Close();
                Response.Redirect("Read?=" + Request.QueryString["BID"].ToString());
            }
            else
            {
                Response.Redirect("error?=Not Found");
            }



        }
    }
}