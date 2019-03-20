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
    public partial class uploadVideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catagory();
                ChannelShowID();
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
                li.Text = data["FastName"].ToString() + " " + data["LastName"].ToString();
                li.Value = data["UserID"].ToString();
                ddlChanelSelected.Items.Add(li);
            }
            Settings_Conf.Close();

        }
        SqlConnection Settings_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        private void catagory()
        {
            ddlCatagory.Items.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Settings_Conf;
            cmd.CommandText = "select * from Video_Catagories_Tbl";
            ddlCatagory.Items.Add(new ListItem("Select Category", "No Category"));
            Settings_Conf.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                ListItem li = new ListItem();
                li.Text = data["Catagories"].ToString();
                li.Value = data["ID"].ToString();
                ddlCatagory.Items.Add(li);
            }
            Settings_Conf.Close();

        }
        SqlConnection video_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void btnpublish_Click(object sender, EventArgs e)
        {
            int error = 0;
            string messege = "";
            string tag = "\n";
            if (string.IsNullOrEmpty(txttitle.Text))
            {
                error++;
                messege += "[Title Requid]" + tag;
            }
            if (string.IsNullOrEmpty(txtDetails.Text))
            {
                error++;
                messege += "[Description Requid]" + tag;
            }
            //--------------------------------------------
            string VideoEXT = string.Empty;
            if (FileUpload.HasFile)
            {
                string n = FileUpload.FileName.ToLower();
                if (n.EndsWith(".mp4"))
                {
                    VideoEXT = ".mp4";
                }
                else if (n.EndsWith(".mpeg"))
                {
                    VideoEXT = ".mpeg";
                }
                else
                {
                    error++;
                    messege += "[File (*.mp4 *.mpeg) Requid]" + tag;
                }
            }
            else
            {
                error++;
                messege += "[Video File Requid]" + tag;
            }
            //---------------------------------------------
            string ThambailoEXT = string.Empty;
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
                    error++;
                    messege += "[File (*.jpg *.jpeg) Requid]" + tag;
                }
            }
            else
            {
                error++;
                messege += "[File Thambail Requid]" + tag;
            }
            if(ddlChanelSelected.SelectedValue=="0")
            {
                error++;
                messege += "[Channel Selected]" + tag;
            }


            if (error == 0)
            {
                try
                {
                    RandomNumber ran = new RandomNumber();
                    ran.HowMuchNumber = 10;
                    string VideoID = "V" + ran.RandomStringNumber("Video");
                    string userID = ddlChanelSelected.SelectedValue.ToString(); ;
                    check chk = new check();
                    chk.ConfigarationName = "Settings";
                    string DriveName = chk.stringCheck("select Drive from Drive where Active='ENABLE'");
                    string Drive = chk.stringCheck("select Value from Drive where Active='ENABLE'");

                    //thumbnail
                    if (!Directory.Exists(Drive + userID + "\\"))
                    {
                        Directory.CreateDirectory(Drive + userID + "\\");
                    }
                    if (!Directory.Exists(Drive + userID + "\\thumbnail\\"))
                    {
                        Directory.CreateDirectory(Drive + userID + "\\thumbnail\\");
                    }
                    if (!Directory.Exists(Drive + userID + "\\Temp\\"))
                    {
                        Directory.CreateDirectory(Drive + userID + "\\Temp\\");
                    }
                    //-----------
                    FileUpload.SaveAs(Drive + userID + "\\" + VideoID + VideoEXT);
                    string path = Drive + userID + "\\Temp\\" + VideoID + ThambailoEXT;
                    ThambailUpload.SaveAs(path);
                    string Download = Drive + userID + "\\thumbnail\\" + VideoID + ThambailoEXT;

                    //-------------Image Edit---------------------
                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(path);
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 370, 220);
                    newimage.Save(Download, imgformat);
                    //------------Exit ---------------------------

                    string KMG_B;
                    double size = FileUpload.PostedFile.ContentLength;
                    size = size / 1024;

                    if (size <= 1024)
                    {
                        size.ToString("0.00");
                        KMG_B = "KB";
                    }
                    else if (size <= 1048576)
                    {
                        size = size / 1024;
                        size.ToString("0.00");
                        KMG_B = "MB";
                    }
                    else
                    {
                        size = size / 1048576;
                        size.ToString("0.00");
                        KMG_B = "GB";
                    }




                    string description = txtDetails.Text;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = video_Conf;
                    cmd.CommandText = @"insert into video (Video_ID,Title,Description,Video,videoLink,Thambail,ThambailLink,PostingType,Language,Catagory,VideoLocation,RecodingDate,ShowCommants,Drive,DriveName,Advertise,ErrorAuthority,ErrorMessege,publishAuth,postingDate,Date,Month,Year,DateTime,UserID,VideoLike,VideoView,Size,KMG_B,AoS)
                    values (@Video_ID,@Title,@Description,@Video,@videoLink,@Thambail,@ThambailLink,@PostingType,@Language,@Catagory,@VideoLocation,@RecodingDate,@ShowCommants,@Drive,@DriveName,@Advertise,@ErrorAuthority,@ErrorMessege,@publishAuth,@postingDate,@Date,@Month,@Year,@DateTime,@UserID,@VideoLike,@VideoView,@Size,@KMG_B,@AoS)";
                    cmd.Parameters.AddWithValue("@Video_ID", VideoID);
                    cmd.Parameters.AddWithValue("@AoS", Session["AdminUserID"].ToString());
                    cmd.Parameters.AddWithValue("@Title", txttitle.Text);
                    cmd.Parameters.AddWithValue("@Description", (description.ToString().Length > 3500) ? (description.ToString().Substring(0, 3500)) : (description));
                    cmd.Parameters.AddWithValue("@Video", VideoID + VideoEXT);
                    cmd.Parameters.AddWithValue("@videoLink", DriveName + "/" + userID + "/" + VideoID + VideoEXT);
                    cmd.Parameters.AddWithValue("@Thambail", VideoID + ThambailoEXT);
                    cmd.Parameters.AddWithValue("@ThambailLink", DriveName + "/" + userID + "/thumbnail/" + VideoID + ThambailoEXT);
                    cmd.Parameters.AddWithValue("@PostingType", ddlPostingType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Language", ddlLanguage.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Catagory", ddlCatagory.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@VideoLocation", txtVideoLocation.Text);
                    cmd.Parameters.AddWithValue("@RecodingDate", txtrecodingDate.Text);
                    cmd.Parameters.AddWithValue("@ShowCommants", ddlcommants.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Drive", Drive);
                    cmd.Parameters.AddWithValue("@DriveName", DriveName);
                    cmd.Parameters.AddWithValue("@Advertise", "FALSE");
                    string check = chk.stringCheck("select Authorise from settings where Name='All_video_Auth'");
                    cmd.Parameters.AddWithValue("@publishAuth", check);
                    cmd.Parameters.AddWithValue("@ErrorAuthority", "FALSE");
                    if (check == "TRUE")
                    {
                        cmd.Parameters.AddWithValue("@ErrorMessege", "Published");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ErrorMessege", "Not Published");
                    }
                    cmd.Parameters.AddWithValue("@postingDate", DateTime.Now.ToString("dd MMMM yy"));
                    cmd.Parameters.AddWithValue("@Date", Convert.ToInt32(DateTime.Now.ToString("dd")));
                    cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(DateTime.Now.ToString("MM")));
                    cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(DateTime.Now.ToString("yyyy")));
                    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@VideoLike", Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@VideoView", Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@Size", Convert.ToDouble(size));
                    cmd.Parameters.AddWithValue("@KMG_B", KMG_B);
                    video_Conf.Open();
                    cmd.ExecuteNonQuery();
                    video_Conf.Close();

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = video_Conf;
                    cmd2.CommandText = @"CREATE TABLE " + VideoID + " ( ID int IDENTITY(1, 1) PRIMARY KEY, Command nvarchar(3500) NULL, Name varchar(500) NULL, Authority varchar(50) NULL, DateTime varchar(500) NULL, UserID varchar(500) NULL );";
                    video_Conf.Open();
                    cmd2.ExecuteNonQuery();
                    video_Conf.Close();
                    txtDetails.Text = "";
                    txtrecodingDate.Text = "";
                    txttag.Text = "";
                    txttitle.Text = "";
                    txtVideoLocation.Text = "";
                    ddlCatagory.SelectedValue = "0";
                    ddlChanelSelected.SelectedValue = "0";
                    ddlcommants.SelectedValue = "0";                 


                    lblResult.Text = "Sucessfully Video Upload.";




                }
                catch (Exception er)
                {

                    lblResult.Text = er.ToString();
                }

            }
            else
            {
                lblResult.Text = messege;
            }
        }
    }
}