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
    public partial class Advertisement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                pnlEditAdd.Visible = false;
            }
            if(Request.QueryString["Edit"]!=null)
            {
                string ID = Request.QueryString["Edit"].ToString();
                pnlAdd.Visible = false;
                pnlEditAdd.Visible = true;
                check chk = new check();
                chk.ConfigarationName = "Settings";
                EditImageShow.ImageUrl= "../" + chk.stringCheck("select Image from Advertisement where ID=" + ID);
                txtEditLink.Text = chk.stringCheck("select Link from Advertisement where ID=" + ID);


            }
        }
        SqlConnection conv = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (txtlink.Text != "" && FileUpload1.HasFile && ddlHV.SelectedValue != "0")
            {
                int er = 0;
                string EXT="";
                string FileName = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-tt");
                string n = FileUpload1.FileName.ToLower();
                if (n.EndsWith(".jpg") || n.EndsWith(".JPG"))
                {
                    EXT = ".jpg";
                }
                else if(n.EndsWith(".png") || n.EndsWith(".PNG"))
                {
                    EXT = ".png";
                }
                else if (n.EndsWith(".gif") || n.EndsWith(".GIF"))
                {
                    EXT = ".gif";
                }
                else
                {
                    er++;
                    
                }
                if (er == 0)
                {                   

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Advertisement(Link,HV,Image,Click) values(@Link,@HV,@Image,@Click)";
                    cmd.Parameters.AddWithValue("@Link",txtlink.Text);
                    cmd.Parameters.AddWithValue("@HV",ddlHV.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Image", "Admin/Advertisement_Image/"+FileName+EXT);
                    cmd.Parameters.AddWithValue("@Click",Convert.ToInt32(0));
                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    if(ddlHV.SelectedValue== "Horizontal")
                    {
                        if (EXT == ".gif")
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT));
                        }
                        else
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            System.Drawing.Image obj;
                            Bitmap newimage;
                            obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            ImageFormat imgformat = obj.RawFormat;
                            newimage = new Bitmap(obj, 728, 90);
                            newimage.Save(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT), imgformat);
                        }
                    }
                    else if(ddlHV.SelectedValue == "Vertical")
                    {
                        if (EXT == ".gif")
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT));
                        }
                        else
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            System.Drawing.Image obj;
                            Bitmap newimage;
                            obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            ImageFormat imgformat = obj.RawFormat;
                            newimage = new Bitmap(obj, 300, 250);
                            newimage.Save(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT), imgformat);
                        }
                    }
                    lblResult.Text = "sucessfully Advertisement Insert.";
                    txtlink.Text = "";
                    ddlHV.SelectedValue = "0";
                    GridView1.DataBind();

                }
                else
                {
                    lblResult.Text = "Error: File Upload must be jpg,jpeg,gif";
                }
            }
            else
            {
                lblResult.Text = "Upload File And Link Add";
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Advertisement?Edit="+e.CommandArgument.ToString());
        }

        protected void btnImageUpdate_Click(object sender, EventArgs e)
        {
            if(FileUpload2.HasFile)
            {
                int er = 0;
                string EXT = "";
                string FileName = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-tt");
                string n = FileUpload1.FileName.ToLower();
                if (n.EndsWith(".jpg") || n.EndsWith(".JPG"))
                {
                    EXT = ".jpg";
                }
                else if (n.EndsWith(".png") || n.EndsWith(".PNG"))
                {
                    EXT = ".png";
                }
                else if (n.EndsWith(".gif") || n.EndsWith(".GIF"))
                {
                    EXT = ".gif";
                }
                else
                {
                    er++;
                }
                if(er==0)
                {

                    
                    if (ddleditA.SelectedValue == "Horizontal")
                    {
                        if (EXT == ".gif")
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT));
                        }
                        else
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            System.Drawing.Image obj;
                            Bitmap newimage;
                            obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            ImageFormat imgformat = obj.RawFormat;
                            newimage = new Bitmap(obj, 728, 90);
                            newimage.Save(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT), imgformat);
                        }

                    }
                    else if (ddleditA.SelectedValue == "Vertical")
                    {
                        if (EXT == ".gif")
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT));
                        }
                        else
                        {
                            FileUpload1.SaveAs(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            System.Drawing.Image obj;
                            Bitmap newimage;
                            obj = System.Drawing.Image.FromFile(Server.MapPath("~/Admin/Advertisement_Image/Temp/" + FileName + EXT));
                            ImageFormat imgformat = obj.RawFormat;
                            newimage = new Bitmap(obj, 300, 250);
                            newimage.Save(Server.MapPath("~/Admin/Advertisement_Image/" + FileName + EXT), imgformat);
                        }
                    }


                    string ID = Request.QueryString["Edit"].ToString();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "update from Advertisement set Image='Admin/Advertisement_Image/"+FileName+EXT+"' where ID="+ID;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lblEditResult.Text = "Update Sucessfully.";


                }


            }
            else
            {
                lblEditResult.Text = "Upload File.";

            }

        }

        protected void btnDetailsUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Edit"] != null && txtEditLink.Text != "" && ddleditA.SelectedValue != "0")
            {
                string ID = Request.QueryString["Edit"].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string command = string.Format("update Advertisement set Link='{0}',HV='{1}' where ID={2}", txtEditLink.Text, ddleditA.SelectedValue.ToString(), ID);
                cmd.CommandText = command;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblEditResult.Text = "Sucessfully Update..";
            }
            else
            {
                lblEditResult.ForeColor = Color.Red;
                lblEditResult.Text = "Error : Please Type and Select Currectly..";
            }

        }

        protected void btnVideoAdd_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile && txtsec.Text != "")
            {
                string FileName = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-tt");
                string Ext = Path.GetExtension(FileUpload3.FileName.ToLower());
                if (Ext == ".mp4")
                {
                    FileUpload3.SaveAs(Server.MapPath("~/Drive-1/ADD/" + FileName + Ext));
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conv;
                    cmd.CommandText = "insert into VideoADD (VideoID,ADDLink,ShowVideo,Sec) values(@VideoID,@ADDLink,@ShowVideo,@Sec)";
                    cmd.Parameters.AddWithValue("@VideoID", "For All");
                    cmd.Parameters.AddWithValue("@ADDLink", "Drive-1/ADD/" + FileName + Ext);
                    cmd.Parameters.AddWithValue("@ShowVideo", Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@Sec", Convert.ToInt32(txtsec.Text));
                    conv.Open();
                    cmd.ExecuteNonQuery();
                    conv.Close();
                    GridView2.DataBind();
                    lblResult.Text = "Video Advertisement Insert..";
                }
            }
        }
    }
}