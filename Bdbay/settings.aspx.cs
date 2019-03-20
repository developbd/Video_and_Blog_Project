using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
namespace Bdbay
{
    public partial class settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                if (!IsPostBack)
                {
                    show();
                }
            }
        }
        private void show()
        {
            string UserID = Session["UserID"].ToString();
            check chk = new check();
            chk.ConfigarationName = "Settings";
            string shortcut = "from Registation_Tbl where UserID='" + UserID + "'";

            txtFastName.Text = chk.stringCheck("select FastName " + shortcut);
            txtLastName.Text = chk.stringCheck("select LastName " + shortcut);
            txtEmail.Text = chk.stringCheck("select Email " + shortcut);
            string wb = chk.stringCheck("select Website " + shortcut);
            if (wb == "No WebSite Available")
            { txtWebsite.Text = ""; }
            else
            { txtWebsite.Text = wb; }
            string ph = chk.stringCheck("select Phone " + shortcut);
            if (ph == "No Pnone Number Available")
            { txtPhone.Text = ""; }
            else
            { txtPhone.Text = ph; }

            string ad = chk.stringCheck("select Address " + shortcut);
            if (ad == "Address Not Available")
            { txtAddress.Text = ""; }
            else
            { txtAddress.Text = ad; }

            string ds = chk.stringCheck("select Description " + shortcut);
            if (ds == "No Description")
            { txtDetails.Text = ""; }
            else
            { txtDetails.Text = ds; }

            ddlgender.SelectedValue = chk.stringCheck("select Gender "+shortcut);
            //txtWebsite.Text = chk.stringCheck("select Website "+shortcut);
            //txtPhone.Text = chk.stringCheck("select Phone " + shortcut);
            //txtAddress.Text = chk.stringCheck("select Address " + shortcut);
            //txtDetails.Text = chk.stringCheck("select Description " + shortcut);
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void btnupdateNamePassword_Click(object sender, EventArgs e)
        {
            bool password = false;
            int err = 0;
            lblUpdateNamePassword.ForeColor = System.Drawing.Color.Red;
            lblUpdateNamePassword.Text = "";
            if (string.IsNullOrEmpty(txtFastName.Text))
            {
                err++;
                lblUpdateNamePassword.Text += "[Fast Name Requid]<br/>";
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                err++;
                lblUpdateNamePassword.Text += "[Last Name Requid]<br/>";
            }
            if (!string.IsNullOrEmpty(txtNewPassword.Text))
            {
                if (string.IsNullOrEmpty(txtRetypePassword.Text))
                {
                    err++;
                    lblUpdateNamePassword.Text += "[Password Retype Requid]<br/>";
                }
                else
                {
                    if (txtNewPassword.Text == txtRetypePassword.Text)
                    {
                        password = true;
                    }
                    else
                    {
                        err++;
                        lblUpdateNamePassword.Text += "[Password Not Match]<br/>";
                    }
                }
            }

                if (err == 0)
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        if (password == true)
                        {
                            cmd.CommandText = "update Registation_Tbl set FastName='" + txtFastName.Text + "', LastName='" + txtLastName.Text + "', Password='"+txtNewPassword.Text+"' where UserID='" + Session["UserID"].ToString() +"'";
                        }
                        else
                        {
                            cmd.CommandText = "update Registation_Tbl set FastName='"+txtFastName.Text+"', LastName='"+txtLastName.Text+"' where UserID='" + Session["UserID"].ToString() + "'";
                        }
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        lblUpdateNamePassword.ForeColor = System.Drawing.Color.Green;
                        lblUpdateNamePassword.Text = "Update Sucessfully";
                        show();
                    }
                    catch (Exception er)
                    { lblUpdateNamePassword.Text = "Error: " + er.Message; }
                }
            }

        protected void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update Registation_Tbl set Website='"+txtWebsite.Text+ "', Phone='"+txtPhone.Text+ "', Gender='"+ddlgender.SelectedItem.ToString()+ "',Address='"+txtAddress.Text+ "',Description='"+txtDetails.Text+ "' where UserID='" + Session["UserID"].ToString() + "'";
                con.Open();
                cmd.ExecuteScalar();
                con.Close();
                lblUpdateDetails.ForeColor = System.Drawing.Color.Green;
                lblUpdateDetails.Text = "Update Sucessfully.";
                show();
            }
            catch (Exception err)
            {
                lblUpdateDetails.Text = "Error : " + err.Message;
            }
        }

        protected void btnProfilePhoto_Click(object sender, EventArgs e)
        {
            lblProfilePhoto.Text = "";
            lblProfilePhoto.ForeColor = System.Drawing.Color.Green;
            if (FUprofilePhoto.HasFile)
            {
                string userID = Session["UserID"].ToString();
                string EXT=string.Empty;
                string n = FUprofilePhoto.FileName.ToLower();
                if (n.EndsWith(".jpg"))
                {
                    EXT = ".jpg";
                }                
                else
                {
                    lblProfilePhoto.ForeColor = System.Drawing.Color.Red;
                    lblProfilePhoto.Text += "[*.jpg Formate Requied.]";                    
                }
                if (EXT != string.Empty)
                {
                    int Size = FUprofilePhoto.PostedFile.ContentLength;
                    if (Size < 2097152)
                    {
                        string Path = Server.MapPath("~/Temp/pf/" + userID + EXT);
                        string Download = Server.MapPath("~/Profileimage/" + userID + EXT);
                        FUprofilePhoto.SaveAs(Path);

                        System.Drawing.Image obj;
                        Bitmap newimage;
                        obj = System.Drawing.Image.FromFile(Path);
                        ImageFormat imgformat = obj.RawFormat;
                        newimage = new Bitmap(obj, 120, 110);
                        newimage.Save(Download, imgformat);

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "update Registation_Tbl set Image='" + userID + EXT + "' where UserID='" + Session["UserID"].ToString() + "'";
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        lblProfilePhoto.Text += "Profile Photo is Upload.";
                        //Response.Redirect("settings");
                    }
                    else
                    {
                        lblProfilePhoto.ForeColor = System.Drawing.Color.Red;
                        lblProfilePhoto.Text += "[Profile Image Size is upto 2MB Requied.]";
                    }
                }
            }

            if(FUCoverphoto.HasFile)
            {
                string userID = Session["UserID"].ToString();
                string EXT = string.Empty;
                string n = FUCoverphoto.FileName.ToLower();
                if (n.EndsWith(".jpg"))
                {
                    EXT = ".jpg";
                }                
                else
                {
                    lblProfilePhoto.ForeColor = System.Drawing.Color.Red;
                    lblProfilePhoto.Text += "[*.jpg Formate Requied.]";
                }
                if (EXT != string.Empty)
                {
                    int Size = FUCoverphoto.PostedFile.ContentLength;
                    if (Size < 2097152)
                    {
                        string Path = Server.MapPath("~/Temp/cf/" + userID + EXT);
                        string Download = Server.MapPath("~/CoverPhoto/" + userID + EXT);
                        FUCoverphoto.SaveAs(Download);

                        //System.Drawing.Image obj;
                        //Bitmap newimage;
                        //obj = System.Drawing.Image.FromFile(Path);
                        //ImageFormat imgformat = obj.RawFormat;
                        //newimage = new Bitmap(obj, 1600, 350);
                        //newimage.Save(Download, imgformat);

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "update Registation_Tbl set CoverPhoto='" + userID + EXT + "' where UserID='" + Session["UserID"].ToString() + "'";
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                        lblProfilePhoto.Text += "Cover Photo is Upload.";
                    }
                    else
                    {
                        lblProfilePhoto.ForeColor = System.Drawing.Color.Red;
                        lblProfilePhoto.Text += "[Cover Photo Size is upto 2MB Requied.]";
                    }
                }

            }

            Response.Redirect("settings");



        }
    }
}