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
    public partial class HomePageAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Edit"]!=null)
            {
                string ID = Request.QueryString["Edit"].ToString();
                pnlEditAdd.Visible = true;
                pnlAdd.Visible = false;
                check chk = new check();
                chk.ConfigarationName = "Settings";
                EditImageShow.ImageUrl = "../"+chk.stringCheck("select Image from HomePageEdit where ID="+ID);
                txtEditSubtitle.Text= chk.stringCheck("select Title from HomePageEdit where ID=" + ID);
                txtEditTitle.Text = chk.stringCheck("select Subtitle from HomePageEdit where ID=" + ID);
                txtEditVideoLink.Text = chk.stringCheck("select Link from HomePageEdit where ID=" + ID);

            }
            else
            {
                pnlEditAdd.Visible = false;
                pnlAdd.Visible = true;
            }
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void btnsave_Click(object sender, EventArgs e)
        {
            string ThambailoEXT;
            if (txtlink.Text != "" && txtsubtxtle.Text != "" && txttitle.Text != "" && FileUpload1.HasFile)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into HomePageEdit (Title,Subtitle,Link,Image) values(@Title,@Subtitle,@Link,@Image)";
                cmd.Parameters.AddWithValue("@Title",txttitle.Text);
                cmd.Parameters.AddWithValue("@Subtitle",txtsubtxtle.Text);
                cmd.Parameters.AddWithValue("@Link",txtlink.Text);
                string FileName = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-tt");
                string n = FileUpload1.FileName.ToLower();
                if (n.EndsWith(".jpg"))
                {
                    ThambailoEXT = ".jpg";
                    cmd.Parameters.AddWithValue("@Image", "Admin/HomeImage/" + FileName + ThambailoEXT);
                    FileUpload1.SaveAs(Server.MapPath("~/Admin/Temp/" + FileName+ThambailoEXT));

                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Temp/" + FileName + ThambailoEXT));
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 400, 300);
                    newimage.Save(Server.MapPath("~/Admin/HomeImage/" + FileName + ThambailoEXT), imgformat);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblResult.Text = "upload Sucessfully.";
                    txttitle.Text = "";
                    txtsubtxtle.Text = "";
                    txtlink.Text = "";
                    GridView1.DataBind();
                }
                else if (n.EndsWith(".png"))
                {
                    ThambailoEXT = ".png";
                    cmd.Parameters.AddWithValue("@Image", "Admin/HomeImage/" + FileName + ThambailoEXT);
                    FileUpload1.SaveAs(Server.MapPath("~/Admin/Temp/" + FileName + ThambailoEXT));

                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Temp/" + FileName + ThambailoEXT));
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 400, 300);
                    newimage.Save(Server.MapPath("~/Admin/HomeImage/" + FileName + ThambailoEXT), imgformat);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblResult.Text = "upload Sucessfully.";
                    txttitle.Text = "";
                    txtsubtxtle.Text = "";
                    txtlink.Text = "";
                    GridView1.DataBind();
                }
                else if (n.EndsWith(".gif"))
                {
                    ThambailoEXT = ".gif";
                    cmd.Parameters.AddWithValue("@Image", "Admin/HomeImage/" + FileName + ThambailoEXT);
                    FileUpload1.SaveAs(Server.MapPath("~/Admin/HomeImage/" + FileName + ThambailoEXT));                 
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblResult.Text = "upload Sucessfully.";
                    txttitle.Text = "";
                    txtsubtxtle.Text = "";
                    txtlink.Text = "";
                    GridView1.DataBind();
                }
                else
                {
                    lblResult.Text = "Error: Image Upload in jpg,png";
                }
            }
            else
            {
                lblResult.Text = "Error: Type Correctly!!";
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("HomePageAdd?Edit=" + e.CommandArgument.ToString());
        }

        protected void btnDetailsUpdate_Click(object sender, EventArgs e)
        {
            if(txtEditTitle.Text!="" && txtEditSubtitle.Text!="" && txtEditVideoLink.Text !="")
            {
                string ID = Request.QueryString["Edit"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = string.Format("update HomePageEdit set Title='{0}', Subtitle='{1}', Link='{2}'  where ID={3}",txtEditTitle.Text,txtEditSubtitle.Text,txtEditVideoLink.Text, ID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblEditResult.Text = "Sucessfully Contain Update..";
                GridView1.DataBind();
            }
            else
            {
                lblEditResult.Text = "Do not Empty Box..";
            }
        }


        protected void btnImageUpdate_Click(object sender, EventArgs e)
        {
            if(FileUpload2.HasFile)
            {
                string ID = Request.QueryString["Edit"].ToString();
                string FileName = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-tt");
                string ThambailoEXT="";
                string n = FileUpload2.FileName.ToLower();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update HomePageEdit set Image='' where ID="+ID;
                if (n.EndsWith(".jpg") || n.EndsWith(".JPG"))
                {
                    ThambailoEXT = ".jpg";
                    cmd.CommandText = "update HomePageEdit set Image='Admin/HomeImage/"+ FileName + ThambailoEXT + "' where ID=" + ID;
                    FileUpload2.SaveAs(Server.MapPath("~/Admin/Temp/" + FileName + ThambailoEXT));
                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Temp/" + FileName + ThambailoEXT));
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 400, 300);
                    newimage.Save(Server.MapPath("~/Admin/HomeImage/" + FileName + ThambailoEXT), imgformat);                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblEditResult.Text = "Update Sucessfully.";
                    GridView1.DataBind();
                    EditImageShow.ImageUrl = "../Admin/HomeImage/" + FileName + ThambailoEXT;
                }
                else if (n.EndsWith(".png") || n.EndsWith(".PNG"))
                {
                    ThambailoEXT = ".png";
                    cmd.Parameters.AddWithValue("@Image", "Admin/HomeImage/" + FileName + ThambailoEXT);
                    cmd.CommandText = "update HomePageEdit set Image='Admin/HomeImage/" + FileName + ThambailoEXT + "' where ID=" + ID;
                    FileUpload2.SaveAs(Server.MapPath("~/Admin/Temp/" + FileName + ThambailoEXT));

                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Temp/" + FileName + ThambailoEXT));
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 400, 300);
                    newimage.Save(Server.MapPath("~/Admin/HomeImage/" + FileName + ThambailoEXT), imgformat);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblEditResult.Text = "upload Sucessfully.";
                    txttitle.Text = "";
                    txtsubtxtle.Text = "";
                    txtlink.Text = "";
                    GridView1.DataBind();
                    EditImageShow.ImageUrl = "../Admin/HomeImage/" + FileName + ThambailoEXT;
                    
                }
                else
                {
                    lblEditResult.Text = "Error: Image Upload in jpg, png";
                }

            }
            else
            {
                lblEditResult.Text = "Please Image Upload Image.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePageAdd");
        }

        protected void btnSave_Click1(object sender, EventArgs e)
        {
            if (logoupload.HasFile)
            {
                string File = logoupload.FileName.ToLower();
                if (File.EndsWith(".png"))
                {
                    logoupload.SaveAs(Server.MapPath("~/images/logo2.png"));
                    lblResult.Text = "logo upload";
                }
                else
                {
                    lblResult.Text = "Upload File into png";
                }
            }
            else
            {
                lblResult.Text = "Upload File";
            }
        }
    }
}