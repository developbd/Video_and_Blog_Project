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
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!this.IsPostBack)
            {
                pnlAdvanceSettings.Visible = false;
                btnUpdate.Visible = false;
                //pnlProcess.Visible = false;

                if (Request.QueryString["EditData"] != null && Request.QueryString["ref"] != null && Request.QueryString["uid"] != null)
                {
                    string Video_ID = Request.QueryString["EditData"].ToString();
                    string Page = Request.QueryString["ref"].ToString();
                    string UserID = Request.QueryString["uid"].ToString();
                    pnlMessege.Visible = false;
                    pnlUpload.Visible = true;
                    check chk = new check();
                    chk.ConfigarationName = "video";
                    pnlVideoUpload.Visible = false;
                    btnUpdate.Visible = true;
                    btnPublish.Visible = false;
                 
                        var Shortcut = " from video where Video_ID='" + Video_ID + "'";
                        txttitle.Text = chk.stringCheck("select Title " + Shortcut);
                        txtDetails.Text = chk.stringCheck("select Description " + Shortcut);
                        txtrecodingDate.Text = chk.stringCheck("select RecodingDate " + Shortcut);
                        txtVideoLocation.Text = chk.stringCheck("select VideoLocation " + Shortcut);
                    
                }

                if (Request.QueryString["Delete"] != null && Request.QueryString["ref"] != null && Request.QueryString["uid"] != null)
                {
                    string Video_ID = Request.QueryString["Delete"].ToString();
                    string Page = Request.QueryString["ref"].ToString();
                    string UserID_Sess = Request.QueryString["uid"].ToString();
                    if (Session["UserID"].ToString() == UserID_Sess)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = video_Conf;
                        cmd.CommandText = "delete from video where Video_ID='" + Video_ID + "'";
                        video_Conf.Open();
                        cmd.ExecuteNonQuery();
                        video_Conf.Close();
                        Response.Redirect("Videos");
                    }
                    else
                    {
                        Response.Redirect("Videos");
                    }
                }



           }

        

            if (Session["UserID"] != null)
            {
                catagory();
                string UserID = Session["UserID"].ToString();
                check chk = new check();
                chk.ConfigarationName = "Settings";
                string shortcut = "from Registation_Tbl where UserID='" + UserID + "'";
                if (chk.stringCheck("select uploadAuthority " + shortcut) == "TRUE")
                {
                    lblMessege.Text = "";
                    pnlMessege.Visible = false;
                    pnlUpload.Visible = true;
                   
                }
                else
                {
                    pnlMessege.Visible = true;
                    pnlUpload.Visible = false;
                    lblMessege.Text = "You are No longer To Upload Video. Contact us !";
                }
            }
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

        }
        protected void btnAdvance_Click(object sender, EventArgs e)
        {
            pnlAdvanceSettings.Visible = true;
        }
        SqlConnection video_Conf = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            //pnlProcess.Visible = true;
           // pnlUpload.Visible = false;

            int error = 0;
            string messege = "";
            string tag = "\n";
            btnPublish.CssClass = "backDef";
            if(string.IsNullOrEmpty(txttitle.Text))
            {
                error++;
                messege += "[Title Requid]"+tag;
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

            if (error == 0)
            {
                try
                {
                    
                    RandomNumber ran = new RandomNumber();
                    ran.HowMuchNumber = 10;
                    string VideoID = "V"+ ran.RandomStringNumber("Video");
                    string userID = Session["UserID"].ToString();
                    check chk = new check();
                    chk.ConfigarationName = "Settings";
                    string DriveName = chk.stringCheck("select Drive from Drive where Active='ENABLE'");
                    string Drive = "~/Drive-1/";

                    //thumbnail
                    if (!Directory.Exists(Server.MapPath(Drive+userID+"/")))
                    {
                        Directory.CreateDirectory(Server.MapPath(Drive + userID+"/"));
                    }
                    if (!Directory.Exists(Server.MapPath(Drive + userID + "/thumbnail/")))
                    {
                        Directory.CreateDirectory(Server.MapPath(Drive + userID + "/thumbnail/"));
                    }
                    if (!Directory.Exists(Server.MapPath(Drive + userID + "/Temp/")))
                    {
                        Directory.CreateDirectory(Server.MapPath(Drive + userID + "/Temp/"));
                    }
                    //-----------
                    FileUpload.SaveAs(Server.MapPath(Drive+userID+"/"+VideoID+VideoEXT));
                    string path = Server.MapPath(Drive + userID + "/Temp/" + VideoID + ThambailoEXT);
                    ThambailUpload.SaveAs(path);
                    string Download =Server.MapPath(Drive + userID + "/thumbnail/" + VideoID + ThambailoEXT);

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
                    cmd.CommandText = @"insert into video (Video_ID,Title,Description,Video,videoLink,Thambail,ThambailLink,PostingType,Language,Catagory,VideoLocation,RecodingDate,ShowCommants,Drive,DriveName,Advertise,ErrorAuthority,ErrorMessege,publishAuth,postingDate,Date,Month,Year,DateTime,UserID,VideoLike,VideoView,Size,KMG_B)
                    values (@Video_ID,@Title,@Description,@Video,@videoLink,@Thambail,@ThambailLink,@PostingType,@Language,@Catagory,@VideoLocation,@RecodingDate,@ShowCommants,@Drive,@DriveName,@Advertise,@ErrorAuthority,@ErrorMessege,@publishAuth,@postingDate,@Date,@Month,@Year,@DateTime,@UserID,@VideoLike,@VideoView,@Size,@KMG_B)";
                    cmd.Parameters.AddWithValue("@Video_ID", VideoID);
                    cmd.Parameters.AddWithValue("@Title",txttitle.Text);
                    cmd.Parameters.AddWithValue("@Description",(description.ToString().Length > 3500) ? ( description.ToString().Substring(0,3500)) : (description)) ;
                    cmd.Parameters.AddWithValue("@Video",VideoID+VideoEXT);
                    cmd.Parameters.AddWithValue("@videoLink", DriveName + "/" + userID + "/" + VideoID + VideoEXT);
                    cmd.Parameters.AddWithValue("@Thambail",VideoID+ThambailoEXT);
                    cmd.Parameters.AddWithValue("@ThambailLink", DriveName + "/" + userID + "/thumbnail/" + VideoID + ThambailoEXT);
                    cmd.Parameters.AddWithValue("@PostingType",ddlPostingType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Language", ddlLanguage.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Catagory",ddlCatagory.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@VideoLocation",txtVideoLocation.Text);
                    cmd.Parameters.AddWithValue("@RecodingDate",txtrecodingDate.Text);
                    cmd.Parameters.AddWithValue("@ShowCommants",ddlcommants.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Drive",Drive);
                    cmd.Parameters.AddWithValue("@DriveName",DriveName);
                    cmd.Parameters.AddWithValue("@Advertise","FALSE");
                    string check = chk.stringCheck("select Authorise from settings where Name='All_video_Auth'");
                    cmd.Parameters.AddWithValue("@publishAuth", check);
                    cmd.Parameters.AddWithValue("@ErrorAuthority","FALSE");
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
                    cmd2.CommandText = @"CREATE TABLE "+VideoID+ " ( ID int IDENTITY(1, 1) PRIMARY KEY, Command nvarchar(3500) NULL, Name varchar(500) NULL, Authority varchar(50) NULL, DateTime varchar(500) NULL, UserID varchar(500) NULL );";
                    video_Conf.Open();
                    cmd2.ExecuteNonQuery();
                    video_Conf.Close();
                    Response.Redirect("watch?="+VideoID);

                }
                catch (Exception er)
                {
                    btnPublish.CssClass = "denger";
                    lblResult.Text = er.Message.ToString();
                    pnlUpload.Style.Add("display", "inherit");
                    //pnlProcess.Visible = false;
                    //pnlUpload.Visible = true;
                }

            }
            else
            {
                btnPublish.CssClass = "denger";
                lblResult.Text = messege;
                pnlUpload.Style.Add("display", "inherit");
                //pnlProcess.Visible = false;
                //pnlUpload.Visible = true;
            }




                
                    
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int err = 0;
            lblResult.ForeColor = Color.Red;
            lblResult.Text = "";
            bool Th_o_f = false;
            string ThambailoEXT = "";
            if (txttitle.Text=="")
            {
                err++;
                lblResult.Text += "Title Empty. Please type Title!<br/>";
            }
            if(txtDetails.Text =="")
            {
                err++;
                lblResult.Text += "Details Empty. Please type Video Details!<br/>";
            }
            if(ThambailUpload.HasFile)
            {
                Th_o_f = true;
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
                    err++;
                    lblResult.Text += "[File (*.jpg *.jpeg) Requid]<br/>";
                }
            }
            else
            {
                Th_o_f = false;
            }
            if (err == 0)
            {


                if (Th_o_f == true)
                {
                    check chk = new check();
                    chk.ConfigarationName = "video";
                    string Video_ID2 = Request.QueryString["EditData"].ToString();
                    string Page = Request.QueryString["ref"].ToString();
                   // string Drive = chk.stringCheck("select Drive from video where Video_ID='" + Video_ID2 + "'");
                    string Drive = "~/Drive-1/";
                    string UserID = Request.QueryString["uid"].ToString();
                    string path =Server.MapPath( Drive + UserID + "/Temp/" + Video_ID2 + ThambailoEXT);
                    ThambailUpload.SaveAs(path);
                    string Download = Server.MapPath(Drive + UserID + "/thumbnail/" + Video_ID2 + ThambailoEXT);

                    //-------------Image Edit---------------------
                    System.Drawing.Image obj;
                    Bitmap newimage;
                    obj = System.Drawing.Image.FromFile(path);
                    ImageFormat imgformat = obj.RawFormat;
                    newimage = new Bitmap(obj, 370, 220);
                    newimage.Save(Download, imgformat);
                    //------------Exit ---------------------------
                }
                if (Request.QueryString["EditData"] != null && Request.QueryString["ref"] != null && Request.QueryString["uid"] != null)
                {


                    string Video_ID_Gen = Request.QueryString["EditData"].ToString();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = video_Conf;
                    cmd.CommandText = string.Format("update video set Title='{0}', Description='{1}', VideoLocation='{2}', RecodingDate='{3}' where Video_ID='{4}'", txttitle.Text, txtDetails.Text, txtVideoLocation.Text, txtrecodingDate.Text, Video_ID_Gen);
                    video_Conf.Open();
                    cmd.ExecuteNonQuery();
                    video_Conf.Close();
                    lblResult.ForeColor = Color.Green;
                    lblResult.Text = "Saved";
                }

            }





        }
    }
}