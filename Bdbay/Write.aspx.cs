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
namespace Bdbay
{
    public partial class Write : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
               
                string userID = Session["UserID"].ToString();
                check chk = new check();
                chk.ConfigarationName = "Settings";
                if (chk.stringCheck("select writeAuthority from Registation_Tbl where UserID='" + userID + "'") == "TRUE")
                {
                    pnlMessege.Visible = false;
                    if (!IsPostBack)
                    {
                        catagory();
                        pnlwrite.Visible = false;
                        pnlUpdate.Visible =false;
                        btn_Publish_Update.Visible = false;
                    }
                    if(Request.QueryString["bid"]!=null)
                    {
                        string BlogID = Request.QueryString["bid"].ToString();
                        chk.ConfigarationName = "blogcs";
                        if(userID==chk.stringCheck("select UserID from blog_Tbl where BlogID='"+BlogID+"'"))
                        {
                            pnlwrite.Visible = true;
                            pnlUpload.Visible = false;
                        }
                        else
                        {
                            Response.Redirect("error?=BlogNotFound");
                        }
                    }

                    if(Request.QueryString["Edit"]!=null)
                    {
                        string Blog_ID = Request.QueryString["Edit"].ToString();

                        btnPublish.Visible = false;
                        btn_Publish_Update.Visible = true;
                        chk.ConfigarationName = "blogcs";
                        string Shortcut = " from blog_Tbl where BlogID='"+Blog_ID+"'";
                        txttitle.Text = chk.stringCheck("select Title "+Shortcut);
                        txtShortDetails.Text = chk.stringCheck("select ShortDetails "+Shortcut);
                        string Category = chk.stringCheck("select Catagory "+Shortcut);
                        chk.ConfigarationName = "Settings";
                        ddlCatagory.SelectedValue = chk.stringCheck("select ID from Blog_Catagory_Tbl where Catagoris='"+Category+"'");
                    }

                    if(Request.QueryString["Delete"] !=null && Request.QueryString["ref"] != null && Request.QueryString["uid"] != null)
                    {
                        string BlogID = Request.QueryString["Delete"].ToString();
                        string Page = Request.QueryString["ref"].ToString();
                        string UserID_Sess = Request.QueryString["uid"].ToString();
                        if(Session["UserID"].ToString() == UserID_Sess)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con_blog;
                            cmd.CommandText = "delete from blog_Tbl where BlogID='"+ BlogID + "'";
                            con_blog.Open();
                            cmd.ExecuteNonQuery();
                            con_blog.Close();
                            Response.Redirect("Blog");
                        }
                        else
                        {
                            Response.Redirect("Blog");
                        }

                        
                    }

                    if(Request.QueryString["bid"] != null && Request.QueryString["i"] != null && Request.QueryString["ref"] != null && Request.QueryString["uid"] != null)
                    {
                        string BlogID = Request.QueryString["bid"].ToString();
                        chk.ConfigarationName = "blogcs";
                        if (userID == chk.stringCheck("select UserID from blog_Tbl where BlogID='" + BlogID + "'"))
                        {
                            pnlwrite.Visible = true;                            
                            pnlUpload.Visible = false;
                            
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con_blog;
                            cmd.CommandText = "select * from "+ BlogID;
                            con_blog.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            GridView1.DataSource = dr;
                            GridView1.DataBind();
                            con_blog.Close();

                            if (!IsPostBack)
                            {
                                if (Request.QueryString["editid"] != null)
                                {
                                    string ID = Request.QueryString["editid"].ToString();
                                    txtWrite.Text = chk.stringCheck("select Blog_Write from " + BlogID + " where ID=" + ID);
                                    pnlUpdate.Visible = true;
                                    btnAdd.Enabled = false;
                                }
                                else
                                {
                                    btnAdd.Enabled = true;
                                }
                            }


                        }
                        else
                        {
                            Response.Redirect("error?=BlogNotFound");
                        }
                    }




                }
                else
                {
                    pnlUpload.Visible = false;
                    pnlwrite.Visible = false;
                    pnlMessege.Visible = true;
                    lblMessege.Text = "You Can't Write a Blog. Authority Cancle.";
                }

            }
        }

        SqlConnection Settings_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        private void catagory()
        {
            ddlCatagory.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Settings_Conf;
            cmd.CommandText = "select * from Blog_Catagory_Tbl";
            ddlCatagory.Items.Add(new ListItem("Select Category", "No Category"));
            Settings_Conf.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                ListItem li = new ListItem();
                li.Text = data["Catagoris"].ToString();
                li.Value = data["ID"].ToString();
                ddlCatagory.Items.Add(li);
            }

        }

        SqlConnection con_blog = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            int err = 0;
            string msg = "", ThambailoEXT = "";
            if (string.IsNullOrEmpty(txttitle.Text))
            {
                err++;
                msg += "[Title Requid !]";
            }
            if (ThambailUpload.HasFile)
            {
                string n = ThambailUpload.FileName.ToLower();
                if (n.EndsWith(".jpg"))
                {
                    ThambailoEXT = ".jpg";
                }
                else if (n.EndsWith(".jpeg"))
                {
                    ThambailoEXT = ".jpeg";
                }
                else
                {
                    err++;
                    msg += "[File (*.jpg *.jpeg) Requid]";
                }
            }
            else
            {
                msg += "[Thumbnail Upload!]";
                err++;
            }
            if (ddlCatagory.SelectedValue == "No Category")
            {
                msg += "[Select Catagory]";
                err++;
            }
            



            if (err == 0)
            {
                try
                {
                    RandomNumber ran = new RandomNumber();
                    ran.HowMuchNumber = 10;
                    string BlogID = "B" + ran.RandomStringNumber("Blog");
                    string userID = Session["UserID"].ToString();
                    check chk = new check();
                    chk.ConfigarationName = "Settings";
                    string DriveName = chk.stringCheck("select Drive from Drive where Active='ENABLE'");
                    string Drive = "~/Drive-1/";
                    //thumbnail
                    if (!Directory.Exists(Server.MapPath(Drive + userID + "/")))
                    {
                        Directory.CreateDirectory(Server.MapPath(Drive + userID + "/"));
                    }
                    if (!Directory.Exists(Server.MapPath(Drive + userID + "/BlogThumbnail/")))
                    {
                        Directory.CreateDirectory(Server.MapPath(Drive + userID + "/BlogThumbnail/"));
                    }
                    if (!Directory.Exists(Server.MapPath(Drive + userID + "/Temp/")))
                    {
                        Directory.CreateDirectory(Server.MapPath(Drive + userID + "/Temp/"));
                    }
                    string path =Server.MapPath( Drive + userID + "/Temp/" + BlogID + ThambailoEXT);
                    ThambailUpload.SaveAs(path);
                    string Download =Server.MapPath( Drive + userID + "/BlogThumbnail/" + BlogID + ThambailoEXT);

                    //-------------Image Edit---------------------
                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(path);
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 370, 220);
                    newimage.Save(Download, imgformat);
                    //------------Exit ---------------------------
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con_blog;
                    cmd.CommandText = @"insert into blog_Tbl 
                    (BlogID,Title,ShortDetails,Thumbnail,LinkThumbnail,Catagory,ShowCommants,PostingType,Languege,Drive,DriveName,Advetise,ErrorAuthority,ErrorMessege,PostingDate,Date,Month,Year,DateTime,UserID,PublishAutho,ViewBlog)
                    values (@BlogID,@Title,@ShortDetails,@Thumbnail,@LinkThumbnail,@Catagory,@ShowCommants,@PostingType,@Languege,@Drive,@DriveName,@Advetise,@ErrorAuthority,@ErrorMessege,@PostingDate,@Date,@Month,@Year,@DateTime,@UserID,@PublishAutho,@ViewBlog)";
                    cmd.Parameters.AddWithValue("@BlogID",BlogID);
                    cmd.Parameters.AddWithValue("@Title",txttitle.Text);
                    cmd.Parameters.AddWithValue("@ShortDetails",txtShortDetails.Text);
                    cmd.Parameters.AddWithValue("@Thumbnail", BlogID+ThambailoEXT);
                    cmd.Parameters.AddWithValue("@LinkThumbnail", DriveName + "/" + userID + "/BlogThumbnail/" + BlogID + ThambailoEXT);
                    cmd.Parameters.AddWithValue("@Catagory",ddlCatagory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ShowCommants",ddlcommants.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PostingType",ddlPostingType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Languege",ddlLanguage.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Drive", Drive);
                    cmd.Parameters.AddWithValue("@DriveName", DriveName);
                    cmd.Parameters.AddWithValue("@Advetise", "FALSE");
                    cmd.Parameters.AddWithValue("@ViewBlog",Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@ErrorAuthority", "FALSE");
                    string check = chk.stringCheck("select Authorise from settings where Name='All_Blog_Auth'");
                    if (check == "TRUE")
                    {
                        cmd.Parameters.AddWithValue("@ErrorMessege", "Published");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ErrorMessege", "Not Published");
                    }
                    cmd.Parameters.AddWithValue("@PostingDate", DateTime.Now.ToString("dd MMMM yy"));
                    cmd.Parameters.AddWithValue("@Date", Convert.ToInt32(DateTime.Now.ToString("dd")));
                    cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(DateTime.Now.ToString("MM")));
                    cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(DateTime.Now.ToString("yyyy")));
                    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@UserID",userID);
                    cmd.Parameters.AddWithValue("@PublishAutho",check);
                    con_blog.Open();
                    cmd.ExecuteNonQuery();
                    con_blog.Close();
                    cmd.CommandText = @"CREATE TABLE " + BlogID + " ( ID int IDENTITY(1, 1) PRIMARY KEY, Blog_Write nvarchar(4000) NULL, Authority varchar(50) NULL, DateTime varchar(500) NULL, Date int NULL, Month int NULL, Year int NULL  );";
                    con_blog.Open();
                    cmd.ExecuteNonQuery();
                    con_blog.Close();
                    Response.Redirect("write?bid="+BlogID);
                }
                catch (Exception er)
                {
                    lblResult.Text = "Error: "+er.Message;
                }
                pnlUpload.Visible = false;
            }
            else
            {
                lblResult.Text = msg;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string BlogWrite = txtWrite.Text;
            if (!string.IsNullOrEmpty(BlogWrite))
            {
                if(BlogWrite.Length > 3500)
                {
                    lblinfoShow.Text = "Blog Must Write Under 3500 Alphabet. Click Add And Type More !";
                }
                else
                {
                    if (Request.QueryString["bid"] != null)
                    {
                        string BlogID = Request.QueryString["bid"].ToString();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con_blog;
                        cmd.CommandText = "insert into "+BlogID+ " (Blog_Write,Authority,DateTime,Date,Month,Year) values (@Blog_Write,@Authority,@DateTime,@Date,@Month,@Year)";
                        cmd.Parameters.AddWithValue("@Blog_Write",txtWrite.Text);
                        cmd.Parameters.AddWithValue("@Authority","TRUE");
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@Date", Convert.ToInt32(DateTime.Now.ToString("dd")));
                        cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(DateTime.Now.ToString("MM")));
                        cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(DateTime.Now.ToString("yyyy")));
                        con_blog.Open();
                        cmd.ExecuteNonQuery();
                        con_blog.Close();
                        lblinfoShow.Text = "Sucessfully Add Your Blog.";
                        txtWrite.Text = "";

                        cmd.Connection = con_blog;
                        cmd.CommandText = "select * from " + BlogID;
                        con_blog.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        GridView1.DataSource = dr;
                        GridView1.DataBind();
                        con_blog.Close();
                    }
                }
            }
            else
            {
                lblinfoShow.Text = "You Must be Write a Blog.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["editid"] != null && Request.QueryString["bid"]!=null)
            {
                string ID = Request.QueryString["editid"].ToString();
                string BlogID = Request.QueryString["bid"].ToString();
                string Write_Blog = txtWrite.Text;
                Write_Blog = Write_Blog.Replace("'","");

                if(Write_Blog.Length < 3500)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con_blog;
                    cmd.CommandText = "update " + BlogID + " set Blog_Write='" + Write_Blog + "' where ID=" + ID;
                    con_blog.Open();
                    cmd.ExecuteNonQuery();
                    con_blog.Close();
                    lblinfoShow.ForeColor = Color.Green;
                    lblinfoShow.Text = "Blog ID: " + ID + " | Update Complete.";

                    cmd.Connection = con_blog;
                    cmd.CommandText = "select * from " + BlogID;
                    con_blog.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                    con_blog.Close();
                }
                else
                {
                    lblinfoShow.ForeColor = Color.Red;
                    lblinfoShow.Text = "You Must Type Under 3500 Character...";
                }
                

                

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string BlogID = Request.QueryString["bid"].ToString();
            Response.Redirect("write?Edit="+BlogID);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["editid"] != null)
            {
                string BlogID = Request.QueryString["bid"].ToString();
                string ID = Request.QueryString["editid"].ToString();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con_blog;
                cmd.CommandText = "delete from "+BlogID+" where ID="+ID ;
                con_blog.Open();
                cmd.ExecuteNonQuery();
                con_blog.Close();

                cmd.Connection = con_blog;
                cmd.CommandText = "select * from " + BlogID;
                con_blog.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                con_blog.Close();
                lblinfoShow.ForeColor = Color.Red;
                lblinfoShow.Text = "Delete |ID="+ID+"| is Sucessful.";
            }
        }

        protected void btn_Publish_Update_Click(object sender, EventArgs e)
        {
            string BlogID = Request.QueryString["Edit"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con_blog;
            cmd.CommandText = string.Format("update blog_Tbl set Title='{0}',ShortDetails='{1}',Catagory='{2}',ShowCommants='{3}',PostingType='{4}',Languege='{5}' where ID="+ID,txttitle.Text,txtShortDetails.Text,ddlCatagory.SelectedItem.ToString(),ddlcommants.SelectedItem.ToString(),ddlPostingType.SelectedItem.ToString(),ddlLanguage.SelectedItem.ToString());

            if(ThambailUpload.HasFile)
            {
                string ThambailoEXT = string.Empty;
                string n = ThambailUpload.FileName.ToLower();
                if (n.EndsWith(".jpg") || n.EndsWith(".JPG"))
                {
                    ThambailoEXT = ".jpg";
                }
                else if (n.EndsWith(".jpeg") || n.EndsWith(".JPEG"))
                {
                    ThambailoEXT = ".jpeg";
                }
                else
                {
                    lblResult.Text += "[File (*.jpg *.jpeg) Requid]<br/>";
                }
                if(ThambailoEXT!= string.Empty)
                {
                    check chk = new check();
                    chk.ConfigarationName = "blogcs";
                    string ID1 = chk.stringCheck("select ID from blog_Tbl where BlogID='"+ BlogID + "'");
                    var Drive = "~/Drive-1/";
                    var UserID = chk.stringCheck("select UserID from blog_Tbl where ID=" + ID1); 
                    var Thumbnail = chk.stringCheck("select Thumbnail from blog_Tbl where ID=" + ID1);
                    string path = Server.MapPath(Drive + UserID + "/Temp/" + BlogID + ThambailoEXT);
                    ThambailUpload.SaveAs(path);
                    string Download = Server.MapPath(Drive + UserID + "/BlogThumbnail/" + BlogID + ThambailoEXT);
                    //-------------Image Edit---------------------Drive
                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(path);
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 370, 220);
                    newimage.Save(Download, imgformat);
                    //------------Exit ---------------------------
                }


            }



        }
    }
}