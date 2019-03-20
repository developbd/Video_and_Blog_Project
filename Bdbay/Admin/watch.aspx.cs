using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Bdbay.Admin
{
    public partial class watch : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString[""] != null && Request.QueryString["ref"] != null)
                {
                    var ID = Request.QueryString[""].ToString();
                    var Ref_Id = Request.QueryString["ref"].ToString();
                    //
                    if (Ref_Id == "Video" || Ref_Id == "NonAuthoriseVideo" || Ref_Id == "AuthoriseVideo")
                    {
                        pnlVideo.Visible = true;
                        pnlBlog.Visible = false;
                        pnlVideoShow.Visible = true;
                        pnlBlogShow.Visible = false;

                        check chk = new check();
                        chk.ConfigarationName = "video";

                        string videoSrc = chk.stringCheck("select videoLink from video where Video_ID='" + ID + "'");
                        videoShow.Controls.Add(new LiteralControl("<video src='../" + videoSrc + "' width='350' height='250'  controls='controls' />"));
                        txtTitle.Text = chk.stringCheck("select Title from video where Video_ID='" + ID + "'");
                        txtDeatils.Text = chk.stringCheck("select Description from video where Video_ID='" + ID + "'");
                        txtErrorMessege.Text = chk.stringCheck("select ErrorMessege from video where Video_ID='" + ID + "'");
                        ddlAuthority.SelectedValue = chk.stringCheck("select publishAuth from video where Video_ID='" + ID + "'");
                        ddlADD.SelectedValue = chk.stringCheck("select Advertise from video where Video_ID='" + ID + "'");
                    }
                    else if (Ref_Id == "Blog" || Ref_Id == "NonAuthoriseBlog" || Ref_Id == "AuthoriseBlog")
                    {
                        pnlVideoShow.Visible = false;
                        pnlVideo.Visible = false;
                        pnlBlog.Visible = true;
                        pnlBlogShow.Visible = true;

                        check chk = new check();
                        chk.ConfigarationName = "blogcs";

                        txtBlogDetails.Text = chk.stringCheck("select ShortDetails from blog_Tbl where BlogID='" + ID + "'");
                        txtBlogTitle.Text = chk.stringCheck("select Title from blog_Tbl where BlogID='" + ID + "'");
                        txtBlogErrorMessege.Text = chk.stringCheck("select ErrorMessege from blog_Tbl where BlogID='" + ID + "'");
                        ddlBlogAuthority.SelectedValue = chk.stringCheck("select PublishAutho from blog_Tbl where BlogID='" + ID + "'");
                        ddlADDBlog.SelectedValue = chk.stringCheck("select Advetise from blog_Tbl where BlogID='" + ID + "'");
                    }
                }
                else
                {
                    Response.Redirect("Home");
                }
            }

        }
        SqlConnection conv = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string VID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conv;
            string vr = string.Format("update video set Title='{0}', publishAuth='{1}',  ErrorMessege='{2}', Advertise='{3}' where Video_ID='{4}'", txtTitle.Text, ddlAuthority.SelectedValue.ToString(), txtErrorMessege.Text, ddlADD.SelectedValue.ToString(), VID);
            cmd.CommandText = vr;
            conv.Open();
            cmd.ExecuteNonQuery();
            conv.Close();
            lblResult.Text = "Sucessfully update..";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile && txtsec.Text !=null)
            {
                string FileName = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-tt");
                string Ext = Path.GetExtension(FileUpload1.FileName.ToLower());
                if (Ext == ".mp4")
                {
                    FileUpload1.SaveAs("~/Drive-1/ADD/" + FileName + Ext);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conv;
                    cmd.CommandText = "insert into VideoADD (VideoID,ADDLink,ShowVideo,Sec) values(@VideoID,@ADDLink,@ShowVideo,@Sec)";
                    cmd.Parameters.AddWithValue("@VideoID", Request.QueryString[""].ToString());
                    cmd.Parameters.AddWithValue("@ADDLink","Drive-1/ADD/"+FileName+ Ext);
                    cmd.Parameters.AddWithValue("@ShowVideo",Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@Sec", Convert.ToInt32(txtsec.Text));
                    conv.Open();
                    cmd.ExecuteNonQuery();
                    conv.Close();
                    lblAddResult.Text = "";
                    cmd.CommandText = "update video set Advertise='TRUE' where Video_ID='"+ Request.QueryString[""].ToString() + "'";
                    conv.Open();
                    cmd.ExecuteNonQuery();
                    conv.Close();
                }
            }
        }

        protected void btnBlogShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Read?="+Request.QueryString[""].ToString());
        }
        SqlConnection conB = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void btnBlogADDSave_Click(object sender, EventArgs e)
        {
            if (FileUpload2.HasFile)
            {
                string Ext = Path.GetExtension(FileUpload2.FileName.ToLower());
                if (Ext == ".jpg")
                {
                    string BlogID = Request.QueryString[""].ToString();
                    FileUpload2.SaveAs(Server.MapPath("~/Drive-1/ADDBlog/" + BlogID + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + Ext));
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conB;
                    cmd.CommandText = "insert into BlogADD (BlogID,AddLink) values(@BlogID,@AddLink)";
                    cmd.Parameters.AddWithValue("@BlogID", BlogID);
                    cmd.Parameters.AddWithValue("@AddLink", "Drive-1/ADDBlog/" + BlogID+DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss")+ Ext);    
                    conB.Open();
                    cmd.ExecuteNonQuery();
                    conB.Close();
                    lblBlogResult.Text = "Sucessfully Blog Add";
                }
                else
                {
                    lblBlogResult.Text = "only jpg file need.";
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //delete video 
            string VideoID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conv;
            cmd.CommandText = "delete from video where Video_ID='"+ VideoID + "'";
            conv.Open();
            cmd.ExecuteNonQuery();
            conv.Close();
            lblResult.Text = "Delete Sucessfully.";



        }

        protected void btnDeleteBlog_Click(object sender, EventArgs e)
        {
            string UserID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conB;
            cmd.CommandText = "delete from blog_Tbl where BlogID='" + UserID + "'";
            conB.Open();
            cmd.ExecuteNonQuery();
            conB.Close();
            lblResult.Text = "Delete Sucessfully.";
        }

        protected void btnBlogSave_Click(object sender, EventArgs e)
        {
            if (txtBlogTitle.Text != "" && txtBlogErrorMessege.Text != "" && txtBlogDetails.Text != "" && ddlBlogAuthority.SelectedValue!="0")
            {
                var ID = Request.QueryString[""].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conB;
                cmd.CommandText = string.Format("update blog_Tbl set Title='{0}',ShortDetails='{1}',ErrorMessege='{2}',PublishAutho='{3}',Advetise='{4}' where BlogID='{5}'   ",txtBlogTitle.Text,txtBlogDetails.Text,txtBlogErrorMessege.Text,ddlBlogAuthority.SelectedValue.ToString(),ddlADDBlog.SelectedValue.ToString(),ID);
                conB.Open();
                cmd.ExecuteNonQuery();
                conB.Close();
                lblBlogResult.Text = "Update";
            }
            else
            {
                lblBlogResult.Text = "Type Blog Details";
            }
        }
    }
}