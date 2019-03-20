using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Bdbay.Admin
{
    public partial class AdminorStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Edit"]!=null)
            {
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                var ID = Request.QueryString["Edit"].ToString();
                check chk = new check();
                chk.ConfigarationName = "Admin";
                var ShortCut = " from AdminID where ID="+ID;
                txtAddress.Text = chk.stringCheck("select Address "+ShortCut);
                txtDetails.Text = chk.stringCheck("select Details " + ShortCut);
                txtEmail.Text = chk.stringCheck("select Email " + ShortCut);
                txtFullname.Text = chk.stringCheck("select FullName " + ShortCut);
                txtMobile.Text = chk.stringCheck("select Mobile " + ShortCut);
                txtNid.Text = chk.stringCheck("select NID " + ShortCut);
                txtPassword.Text = chk.stringCheck("select password " + ShortCut);
                txtUserName.Text = chk.stringCheck("select username " + ShortCut);
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                Image1.ImageUrl= "../Admin/Image/" + chk.stringCheck("select Image " + ShortCut);
                if(!IsPostBack)
                {
                    pnlAuthorise.Visible = false;
                }
            }
            else
            {
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                Image1.Visible = false;
                GridView1.Visible = false;
                pnlAuthorise.Visible = true;
            }




        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Admin"].ConnectionString);
        protected void Allyes_CheckedChanged(object sender, EventArgs e)
        {
            RBAuthorizeBlogYes.Checked = true;
            RBAuthorizeVideoYes.Checked = true;
            RBBlogSettingsYes.Checked = true;
            RBCreateAdminstaffYes.Checked = true;
            RBDashboardYes.Checked = true;
            RBHomePageYes.Checked = true;
            RBNonAuthorizeBlogYes.Checked = true;
            RBNonAuthorizeVideoYes.Checked = true;
            RBPaymentSettingsYes.Checked = true;
            RBShowAdminStaffYes.Checked = true;
            RBShowBlogYes.Checked = true;
            RBShowVideoYes.Checked = true;
            RBUploadYes.Checked = true;
            RBVideoSettingsYes.Checked = true;
            RBWriteBlogYes.Checked = true;
            RBShowUserYes.Checked = true;
            RBPandingBlogYes.Checked = true;
            RBPandingVideoYes.Checked = true;
            RBAdvertisementON.Checked = true;

            RBAuthorizeBlogNo.Checked = false;
            RBAuthorizeVideoNo.Checked = false;
            RBBlogSettingsNo.Checked = false;
            RBCreateAdminstaffNo.Checked = false;
            RBDashboardNO.Checked = false;
            RBHomePageNO.Checked = false;
            RBNonAuthorizeBlogNo.Checked = false;
            RBNonAuthorizeVideoNo.Checked = false;
            RBPaymentSettingsNo.Checked = false;
            RBShowAdminStaffNo.Checked = false;
            RBShowBlogNo.Checked = false;
            RBShowVideoNo.Checked = false;
            RBUploadNo.Checked = false;
            RBVideoSettingsNo.Checked = false;
            RBWriteBlogNo.Checked = false;
            RBShowUserNO.Checked = false;
            RBPandingBlogNo.Checked = false;
            RBPandingVideoNO.Checked = false;
            RBAdvertisementOFF.Checked = false;
        }

        protected void AllNo_CheckedChanged(object sender, EventArgs e)
        {
            RBAuthorizeBlogYes.Checked = false;
            RBAuthorizeVideoYes.Checked = false;
            RBBlogSettingsYes.Checked = false;
            RBCreateAdminstaffYes.Checked = false;
            RBDashboardYes.Checked = false;
            RBHomePageYes.Checked = false;
            RBNonAuthorizeBlogYes.Checked = false;
            RBNonAuthorizeVideoYes.Checked = false;
            RBPaymentSettingsYes.Checked = false;
            RBShowAdminStaffYes.Checked = false;
            RBShowBlogYes.Checked = false;
            RBShowVideoYes.Checked = false;
            RBUploadYes.Checked = false;
            RBVideoSettingsYes.Checked = false;
            RBWriteBlogYes.Checked = false;
            RBShowUserYes.Checked = false;
            RBPandingBlogYes.Checked = false;
            RBPandingVideoYes.Checked = false;
            RBAdvertisementON.Checked = false;

            RBAuthorizeBlogNo.Checked = true;
            RBAuthorizeVideoNo.Checked = true;
            RBBlogSettingsNo.Checked = true;
            RBCreateAdminstaffNo.Checked = true;
            RBDashboardNO.Checked = true;
            RBHomePageNO.Checked = true;
            RBNonAuthorizeBlogNo.Checked = true;
            RBNonAuthorizeVideoNo.Checked = true;
            RBPaymentSettingsNo.Checked = true;
            RBShowAdminStaffNo.Checked = true;
            RBShowBlogNo.Checked = true;
            RBShowVideoNo.Checked = true;
            RBUploadNo.Checked = true;
            RBVideoSettingsNo.Checked = true;
            RBWriteBlogNo.Checked = true;
            RBShowUserNO.Checked = true;
            RBPandingBlogNo.Checked = true;
            RBPandingVideoNO.Checked = true;
            RBAdvertisementOFF.Checked = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RandomNumber ran = new RandomNumber();
            ran.HowMuchNumber = 10;
            string UserID = ran.RandomStringNumber("Create Admin/Staff");
            string EXT ="";
            int err = 0;
            if (imageUpload.HasFile)
            {
                string n = imageUpload.FileName.ToLower();
                if (n.EndsWith(".jpg"))
                {
                    EXT = ".jpg";
                    string Temppath = Server.MapPath("~/Admin/TempPath/" + UserID+EXT);
                    imageUpload.SaveAs(Temppath);
                    string path = Server.MapPath("~/Admin/Image/" + UserID + EXT);
                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(Temppath);
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 114, 113);
                    newimage.Save(path, imgformat);
                }
                else
                {
                    err++;
                    lblResult.Text = "Image Upload only {.jpg}";
                }
            }

            if (err == 0)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"insert into AdminID  (UserID,FullName,Address,NID,Mobile,Email,Image,Authority,IDType,Date,username,password,Gender)
values(@UserID,@FullName,@Address,@NID,@Mobile,@Email,@Image,@Authority,@IDType,@Date,@username,@password,@Gender)";
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@FullName", txtFullname.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@NID", txtNid.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue.ToString());
                    if (imageUpload.HasFile)
                    {
                        cmd.Parameters.AddWithValue("@Image", UserID + EXT);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Image", "noimage.jpg");
                    }                   
                    cmd.Parameters.AddWithValue("@Authority", ddlAuthority.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@IDType", ddlType.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@username", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                    InsertCheckBox(UserID);

                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtFullname.Text = "";
                    txtMobile.Text = "";
                    txtNid.Text = "";
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                    ddlGender.SelectedValue = "0";
                    

                }
                catch (Exception er)
                {
                    lblResult.Text = "Error: " + er.Message;
                }
            }


        }
        private void authorize(string userid,string pagename, string pagelink)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into AuthorisePage (UserID,PageName,PageLink) values(@UserID,@PageName,@PageLink)";
            cmd.Parameters.AddWithValue("@UserID", userid);
            cmd.Parameters.AddWithValue("@PageName", pagename);
            cmd.Parameters.AddWithValue("@PageLink", pagelink);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void chkEdit_CheckedChanged(object sender, EventArgs e)
        {
            if(chkEdit.Checked==true)
            {
                pnlAuthorise.Visible = true;
                GridView1.Visible = false;
            }
            else
            {
                pnlAuthorise.Visible = false;
                GridView1.Visible = true;
            }

        }
        private void InsertCheckBox(string UserID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from AuthorisePage where UserID='" + UserID + "'";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            if (RBAuthorizeBlogYes.Checked == true)
            {
                authorize(UserID, "Authorize Blog", "Show?=AuthoriseBlog");
            }
            if (RBAuthorizeVideoYes.Checked == true)
            {
                authorize(UserID, "Authorize Video", "Show?=AuthoriseVideo");
            }
            if (RBBlogSettingsYes.Checked == true)
            {
                authorize(UserID, "Blog Settings", "BlogSettings");
            }
            if (RBCreateAdminstaffYes.Checked == true)
            {
                authorize(UserID, "Create Admin/Staff", "AdminorStaff");
            }
            if (RBDashboardYes.Checked == true)
            {
                authorize(UserID, "Dashboard", "Dashboard");
            }
            if (RBHomePageYes.Checked == true)
            {
                authorize(UserID, "Home Page Add", "HomePageAdd");
            }
            if (RBNonAuthorizeBlogYes.Checked == true)
            {
                authorize(UserID, "Unauthorize Blog", "Show?=NonAuthoriseBlog");
            }
            if (RBNonAuthorizeVideoYes.Checked == true)
            {
                authorize(UserID, "Unauthorize Video", "Show?=NonAuthoriseVideo");
            }
            if (RBPaymentSettingsYes.Checked == true)
            {
                authorize(UserID, "Payment Settings", "PaymentSettings");
            }
            if (RBShowAdminStaffYes.Checked == true)
            {
                authorize(UserID, "Show Admin Staff", "ShowAdminStaff");
            }
            if (RBShowBlogYes.Checked == true)
            {
                authorize(UserID, "Show Blog", "Show?=Blog");
            }
            if (RBShowVideoYes.Checked == true)
            {
                authorize(UserID, "Show Video", "Show?=Video");
            }
            if (RBUploadYes.Checked == true)
            {
                authorize(UserID, "Upload Video", "uploadVideo");
            }
            if (RBVideoSettingsYes.Checked == true)
            {
                authorize(UserID, "Video Settings", "VideoSettings");
            }
            if (RBWriteBlogYes.Checked == true)
            {
                authorize(UserID, "Write Blog", "WriteBlog");
            }
            if (RBShowUserYes.Checked == true)
            {
                authorize(UserID, "Show User", "ShowUser");
            }
            if (RBPandingBlogYes.Checked==true)
            {
                authorize(UserID, "Panding Blog", "Show?=PandingBlog");
            }
            if(RBPandingVideoYes.Checked ==true)
            {
                authorize(UserID, "Panding Video", "Show?=PandingVideo");
            }
            if(RBAdvertisementON.Checked==true)
            {
                authorize(UserID, "Advertisement", "Advertisement");
            }


        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var Id = Request.QueryString["Edit"].ToString();
            var UserID = Request.QueryString["UserID"].ToString();
            if (imageUpload.HasFile)
            {
                string EXT;
                string n = imageUpload.FileName.ToLower();
                if (n.EndsWith(".jpg"))
                {
                    EXT = ".jpg";
                    string Temppath = Server.MapPath("~/Admin/TempPath/" + UserID + EXT);
                    imageUpload.SaveAs(Temppath);
                    string path = Server.MapPath("~/Admin/Image/" + UserID + EXT);
                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(Temppath);
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 114, 113);
                    newimage.Save(path, imgformat);

                }
                else
                {
                    lblResult.Text = "Image Only Jpg file..";
                }
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = string.Format(@"update AdminID set FullName='{0}',Gender='{1}',Address='{2}',NID='{3}',Mobile='{4}',Email='{5}',Authority='{6}',IDType='{7}',Details='{8}'    
            ", txtFullname.Text, ddlGender.SelectedValue.ToString(), txtAddress.Text, txtNid.Text, txtMobile.Text, txtEmail.Text, ddlAuthority.SelectedValue.ToString(), ddlType.SelectedValue.ToString(), txtDetails.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            lblResult.Text = "Sucessfully Update";
            if (chkEdit.Checked==true)
            {
                InsertCheckBox(UserID);
            }





        }
    }
}