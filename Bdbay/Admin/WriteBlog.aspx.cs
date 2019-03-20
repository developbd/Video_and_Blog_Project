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
    public partial class WriteBlog : System.Web.UI.Page
    {
        SqlConnection Settings_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ChannelShowID();
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
        }
        private void ChannelShowID()
        {
            ddlChanelSelected.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Settings_Conf;
            cmd.CommandText = "select * from Registation_Tbl";
            ddlChanelSelected.Items.Add(new ListItem("Select Category", "0"));
            Settings_Conf.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                ListItem li = new ListItem();
                li.Text = data["FastName"].ToString() + " "+ data["LastName"].ToString();
                li.Value = data["UserID"].ToString();
                ddlChanelSelected.Items.Add(li);
            }

        }
        SqlConnection con_blog = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void Button1_Click(object sender, EventArgs e)
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
            if (ddlCatagory.SelectedValue == "0")
            {
                msg += "[Select Catagory]";
                err++;
            }
            if (ddlChanelSelected.SelectedValue == "0")
            {
                msg += "[Select Channel ID]";
                err++;
            }



            if (err == 0)
            {
                try
                {
                    RandomNumber ran = new RandomNumber();
                    ran.HowMuchNumber = 10;
                    string BlogID = "B" + ran.RandomStringNumber("Blog");
                    string userID = ddlChanelSelected.SelectedValue.ToString();
                    check chk = new check();
                    chk.ConfigarationName = "Settings";
                    string DriveName = chk.stringCheck("select Drive from Drive where Active='ENABLE'");
                    string Drive = chk.stringCheck("select Value from Drive where Active='ENABLE'");
                    //thumbnail
                    if (!Directory.Exists(Drive + userID + "\\"))
                    {
                        Directory.CreateDirectory(Drive + userID + "\\");
                    }
                    if (!Directory.Exists(Drive + userID + "\\BlogThumbnail\\"))
                    {
                        Directory.CreateDirectory(Drive + userID + "\\BlogThumbnail\\");
                    }
                    if (!Directory.Exists(Drive + userID + "\\Temp\\"))
                    {
                        Directory.CreateDirectory(Drive + userID + "\\Temp\\");
                    }
                    string path = Drive + userID + "\\Temp\\" + BlogID + ThambailoEXT;
                    ThambailUpload.SaveAs(path);
                    string Download = Drive + userID + "\\BlogThumbnail\\" + BlogID + ThambailoEXT;

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
                    (BlogID,Title,ShortDetails,Thumbnail,LinkThumbnail,Catagory,ShowCommants,PostingType,Languege,Drive,DriveName,Advetise,ErrorAuthority,ErrorMessege,PostingDate,Date,Month,Year,DateTime,UserID,PublishAutho,AoS)
                    values (@BlogID,@Title,@ShortDetails,@Thumbnail,@LinkThumbnail,@Catagory,@ShowCommants,@PostingType,@Languege,@Drive,@DriveName,@Advetise,@ErrorAuthority,@ErrorMessege,@PostingDate,@Date,@Month,@Year,@DateTime,@UserID,@PublishAutho,@AoS)";
                    cmd.Parameters.AddWithValue("@BlogID", BlogID);
                    cmd.Parameters.AddWithValue("@Title", txttitle.Text);
                    cmd.Parameters.AddWithValue("@ShortDetails", txtShortDetails.Text);
                    cmd.Parameters.AddWithValue("@Thumbnail", BlogID + ThambailoEXT);
                    cmd.Parameters.AddWithValue("@LinkThumbnail", DriveName + "/" + userID + "/BlogThumbnail/" + BlogID + ThambailoEXT);
                    cmd.Parameters.AddWithValue("@Catagory", ddlCatagory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ShowCommants", ddlcommants.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PostingType", ddlPostingType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Languege", ddlLanguage.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Drive", Drive);
                    cmd.Parameters.AddWithValue("@DriveName", DriveName);
                    cmd.Parameters.AddWithValue("@Advetise", "FALSE");
                    cmd.Parameters.AddWithValue("@ErrorAuthority", "FALSE");//AoS
                    cmd.Parameters.AddWithValue("@AoS", Session["AdminUserID"].ToString());
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
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@PublishAutho", check);
                    con_blog.Open();
                    cmd.ExecuteNonQuery();
                    con_blog.Close();
                    cmd.CommandText = @"CREATE TABLE " + BlogID + " ( ID int IDENTITY(1, 1) PRIMARY KEY, Blog_Write nvarchar(4000) NULL, Authority varchar(50) NULL, DateTime varchar(500) NULL, Date int NULL, Month int NULL, Year int NULL  );";
                    con_blog.Open();
                    cmd.ExecuteNonQuery();
                    con_blog.Close();
                    Response.Redirect("WriteBlog.aspx?bid=" + BlogID);
                }
                catch (Exception er)
                {
                    lblResult.Text = "Error: " + er.Message;
                }
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                lblResult.Text = msg;
            }


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string BlogWrite = txtWrite.Text;
            if (!string.IsNullOrEmpty(BlogWrite))
            {
                if (BlogWrite.Length > 3500)
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
                        cmd.CommandText = "insert into " + BlogID + " (Blog_Write,Authority,DateTime,Date,Month,Year) values (@Blog_Write,@Authority,@DateTime,@Date,@Month,@Year)";
                        cmd.Parameters.AddWithValue("@Blog_Write", txtWrite.Text);
                        cmd.Parameters.AddWithValue("@Authority", "TRUE");
                        cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@Date", Convert.ToInt32(DateTime.Now.ToString("dd")));
                        cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(DateTime.Now.ToString("MM")));
                        cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(DateTime.Now.ToString("yyyy")));
                        con_blog.Open();
                        cmd.ExecuteNonQuery();
                        con_blog.Close();
                        lblinfoShow.Text = "Sucessfully Add Your Blog.";
                        txtWrite.Text = "";
                    }
                }
            }
            else
            {
                lblinfoShow.Text = "You Must be Write a Blog.";
            }
        }
    }
}