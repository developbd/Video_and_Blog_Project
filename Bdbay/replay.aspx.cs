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
    public partial class replay : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection conb = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        check chk = new check();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Evid"] != null && Request.QueryString["Ecid"] != null && Request.QueryString["Evb"] != null && Request.QueryString["Euid"] != null)
            {
                btnEdit.Visible = true;
                btnReplay.Visible = false;
                btnEditB.Visible = false;
                string VideoID = Request.QueryString["Evid"].ToString();
                string CommandID = Request.QueryString["Ecid"].ToString();
                string UserID = Request.QueryString["Euid"].ToString();
                chk.ConfigarationName = "video";
                if (!IsPostBack)
                {
                    txtCommand.Text = chk.stringCheck("select Command from SubCommand where MCID='" + CommandID + "' and VideoID='" + VideoID + "' ");
                }
            }
            else if (Request.QueryString["C"] != null && Request.QueryString["I"] != null)
            {
                btnEdit.Visible = false;
                btnReplay.Visible = false;
                btnEditx.Visible = true;
                btnEditB.Visible = false;
                string ID = Request.QueryString["I"].ToString();
                string VideoID = Request.QueryString["C"].ToString();
                chk.ConfigarationName = "video";
                if (!IsPostBack)
                {
                    txtCommand.Text = chk.stringCheck("select Command from " + VideoID + " where ID="+ID);
                }
            }
            else if (Request.QueryString["bid"] != null && Request.QueryString["bcid"] != null)
            {
                btnEdit.Visible = false;
                btnEditx.Visible = false;
                btnEditB.Visible = true;
                btnReplay.Visible = false;
                string BlogID = Request.QueryString["bid"].ToString();
                string ComID = Request.QueryString["bcid"].ToString();
                chk.ConfigarationName = "blogcs";
                if (!IsPostBack)
                {
                    txtCommand.Text = chk.stringCheck("select Command from BlogCommand where ID=" + ComID + " and BlogID='" + BlogID + "' ");
                }
                
            }
            else
            {
                btnEdit.Visible = false;
                btnEditx.Visible = false;
                btnEditB.Visible = false;
                btnReplay.Visible = true;
            }
        }

        protected void btnReplay_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text != "")
            {
                if (Request.QueryString["vid"] != null && Request.QueryString["cid"] != null && Request.QueryString["vb"] != null && Request.QueryString["uid"] != null)
                {
                    string VID = Request.QueryString["vid"].ToString();
                    string cid = Request.QueryString["cid"].ToString();
                    string vb = Request.QueryString["vb"].ToString();
                    string uid = Request.QueryString["uid"].ToString();

                    check chk = new check();
                    chk.ConfigarationName="Settings";
                    string name = chk.stringCheck("select FastName from Registation_Tbl where UserID='"+uid+"' ") + " "+ chk.stringCheck("select LastName from Registation_Tbl where UserID='"+uid+"' ") ;

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into SubCommand(MCID,Command,Name,Authority,Date,UserID,VideoID) values(@MCID,@Command,@Name,@Authority,@Date,@UserID,@VideoID)";
                    cmd.Parameters.AddWithValue("@MCID", cid);
                    cmd.Parameters.AddWithValue("@Command",txtCommand.Text);
                    cmd.Parameters.AddWithValue("@Name",name);
                    cmd.Parameters.AddWithValue("@Authority","TRUE");
                    cmd.Parameters.AddWithValue("@Date",DateTime.Now.ToString("dd MMM yyyy"));
                    cmd.Parameters.AddWithValue("@UserID",uid);
                    cmd.Parameters.AddWithValue("@VideoID",VID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);

                }
                else
                {
                    Response.Close();
                }
            }
            else
            {
                lblResult.Text = "You Can not Empty This box.";
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text != "")
            {
                if (Request.QueryString["Evid"] != null && Request.QueryString["Ecid"] != null && Request.QueryString["Evb"] != null && Request.QueryString["Euid"] != null)
                {
                    string VideoID = Request.QueryString["Evid"].ToString();
                    string CommandID = Request.QueryString["Ecid"].ToString();
                    string UserID = Request.QueryString["Euid"].ToString();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update SubCommand set Command='" + txtCommand.Text + "' where MCID='" + CommandID + "' and VideoID='" + VideoID + "' ";
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                }
                else
                {
                    lblResult.Text = "Someting Wrong in Query Close the Window.";
                }
            }
            else
            {
                lblResult.Text = "You Can not Empty This box.";
            }           

        }

        protected void btnEditx_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text != "")
            {
                if (Request.QueryString["C"] != null && Request.QueryString["I"] != null)
                {
                    string VideoID = Request.QueryString["C"].ToString();
                    string CommandID = Request.QueryString["I"].ToString();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update " + VideoID + " set Command='" + txtCommand.Text + "' where ID=" + CommandID ;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                }
                else
                {
                    lblResult.Text = "Someting Wrong in Query Close the Window.";
                }
            }
            else
            {
                lblResult.Text = "You Can not Empty This box.";
            }           
        }

        protected void btnEditB_Click(object sender, EventArgs e)
        {
            if (txtCommand.Text != "")
            {
                if (Request.QueryString["bid"] != null && Request.QueryString["bcid"] != null)
                {
                    string BID = Request.QueryString["bid"].ToString();
                    string CID = Request.QueryString["bcid"].ToString();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conb;
                    cmd.CommandText = "update BlogCommand set Command='" + txtCommand.Text + "' where ID=" + CID + " and BlogID='" + BID + "' ";
                    conb.Open();
                    cmd.ExecuteNonQuery();
                    conb.Close();
                    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                }
                else
                {
                    lblResult.Text = "Someting Wrong in Query Close the Window.";
                }
            }
            else
            {
                lblResult.Text = "You Can not Empty This box.";
            }        
        }




    }
}