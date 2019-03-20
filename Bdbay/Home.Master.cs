using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Bdbay
{
    public partial class Home : System.Web.UI.MasterPage
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["UserFastName"] != null && Session["UserLastName"] != null)
            {
                Session.Timeout = 100000;
                ImageShow();
                if (!IsPostBack)
                {
                    string UserID = Session["UserID"].ToString();
                    check CHK = new check();
                    CHK.ConfigarationName = "video";
                    check chkb = new check();
                    chkb.ConfigarationName = "blogcs";
                    if (CHK.int32Check("select count(*) from video where UserID='" + UserID + "'") > 0 && chkb.int32Check("select count(*) from blog_Tbl where UserID='" + UserID + "'") > 0)
                    {
                        int totalView = CHK.int32Check("select sum(VideoView) from video where UserID='" + UserID + "'");
                        int totalVideos = CHK.int32Check("select count(*) from video where UserID='" + UserID + "'");
                        CHK.ConfigarationName = "blogcs";
                        int totalBlog = CHK.int32Check("select count(*) from blog_Tbl where UserID='" + UserID + "'");
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "update Registation_Tbl set TotalView=" + totalView + ",TotalVideos=" + totalVideos + ",TotalBlog="+ totalBlog + "  where UserID='" + UserID + "'";
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                }
            }
            else
            {
                Session["UserID"] = null;
                Session["UserFastName"] = null;
                Session["UserLastName"] = null;

                loginName.Controls.Add(new LiteralControl("<a class='loginReg' style='margin-left:40px;' data-toggle='example-dropdown' href='#'>login/Register</a>"));
                pnllogin.Visible = true;
                pnlWalcome.Visible = false;
                WalcomImage.Controls.Add(new LiteralControl(""));
            }
            
        }
        private void ImageShow()
        {
            check CHK = new check();
            CHK.ConfigarationName = "Settings";
            WalcomImage.Controls.Add(new LiteralControl("<img src='" + "Profileimage/" + CHK.stringCheck("select Image from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'") + "' style='cursor: pointer; border-radius: 50%; margin-left: 30px;' width='30' height='30' class='loginReg' data-toggle='example-dropdown' />"));
            lblFullname.Text = "<a href='settings'> " + CHK.stringCheck("select FastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'") + " " + CHK.stringCheck("select LastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'")+"</a>";
            pnllogin.Visible = false;
            pnlWalcome.Visible = true;
            loginName.Controls.Add(new LiteralControl(""));
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string Shortcut = " from Registation_Tbl where Email = '" + txtEmail.Text + "' and Password = '" + txtpassword.Text + "'";
            check CHK = new check();
            CHK.ConfigarationName = "Settings";
            if (CHK.int32Check("select count(*) from Registation_Tbl where Email='" + txtEmail.Text + "' and Password='" + txtpassword.Text + "'") == 1)
            {
                Session["UserID"] = CHK.stringCheck("select UserID " + Shortcut);
                Session["UserFastName"] = CHK.stringCheck("select FastName " + Shortcut);
                Session["UserLastName"] = CHK.stringCheck("select LastName " + Shortcut);
                // ImageShow();
                CHK.ConfigarationName = "video";
                int totalVideo = CHK.int32Check("select count(*) from video where UserID='"+ Session["UserID"].ToString() + "' ");
                CHK.ConfigarationName = "blogcs";
                int totalBlog = CHK.int32Check("select count(*) from blog_Tbl where UserID='" + Session["UserID"].ToString() + "'");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Registation_Tbl set TotalVideos="+totalVideo+", TotalBlog="+totalBlog+" where UserID='"+ Session["UserID"].ToString() + "'";
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("Default");


            }
            else
            {
                Response.Redirect("Registation?=False&ref=Master");
            }
            


        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("login?=False&ref=Master");
            
        }

        protected void btnScarch_Click(object sender, EventArgs e)
        {
            Response.Redirect("search?="+txtScarch.Text);
        }
    }
}