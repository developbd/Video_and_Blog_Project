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
    public partial class watch : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection Conv = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[""] != null)
            {
                showMessege();
                // < video src = "" controls = "controls" width = "420" height = "315" />
                check settingschk = new check();
                settingschk.ConfigarationName = "Settings";
                string VideoID = Request.QueryString[""].ToString();
                check chk = new check();
                chk.ConfigarationName = "video";
                lblCommantsCount.Text = chk.int32Check("select count(*) from " + VideoID + "").ToString();
                string Add_Status = "";
                if (!IsPostBack)
                {
                    Add_Status = "FALSE";
                    if (Session["UserID"] != null)
                    {
                        int count = chk.int32Check("select count(*) from Like_Tbl where UserID='" + Session["UserID"].ToString() + "' and VideoID='" + VideoID + "' ");
                        if (count > 0)
                        {
                            btnlike.Enabled = false;
                        }
                        else
                        {
                            btnlike.Enabled = true;
                        }
                    }
                }
                
                
                
                if (chk.stringCheck("select publishAuth from video where Video_ID='" + VideoID + "' ") == "TRUE")
                {
                    if (chk.stringCheck("select ErrorAuthority from video where Video_ID='" + VideoID + "'") == "FALSE")
                    {
                        bool AddStatus = false;

                        if (chk.stringCheck("select Advertise from video where Video_ID='" + VideoID + "'") == "TRUE" && AddStatus == false)
                        {
                            //Session[VideoID] = "TRUE";
                            Add_Status = "TRUE";
                            AddStatus = true;
                            //---------------------------------Add Show 
                        }
                        if (Request.QueryString["SK"] != null)
                        {
                            AddStatus = false;
                        }

                        if (AddStatus == false)
                        {                            
                            string VideoUrl = chk.stringCheck("select videoLink  from video where Video_ID='" + VideoID + "'");
                            plcVideo.Controls.Add(new LiteralControl("<video id='Myvideo' autoplay src='" + VideoUrl + "' controls='controls' width='420' height='315' />"));
                            btnSkipAdd.Visible = false;                          
                        }
                        else
                        {
                            Add_Status = "TRUE";
                            AddStatus = false;
                            string ID = chk.stringCheck("select top 1 ID  from VideoADD ORDER BY NEWID()");
                            string VideoUrl = chk.stringCheck("select ADDLink  from VideoADD where ID="+ID);// where VideoID='" + VideoID + "'
                            plcVideo.Controls.Add(new LiteralControl("<video id='Myvideo' autoplay src='" + VideoUrl +"' width='420' height='315' />"));
                            btnSkipAdd.Visible = true;
                            int c = chk.int32Check("select Sec from VideoADD where ID=" +ID );
                            SkipAdd(c, VideoID);
                        }                  


                        string shortcut = " from video where Video_ID='" + VideoID + "'";
                        string UserID = chk.stringCheck("select UserID " + shortcut);
                        string setShortcut = " from Registation_Tbl where UserID='" + UserID + "' ";
                        lblTitle.Text = chk.stringCheck("select Title " + shortcut);
                        lblDescription.Text = chk.stringCheck("select Description " + shortcut);
                        string FastName = settingschk.stringCheck("select FastName "+setShortcut);
                        string Lastname = settingschk.stringCheck("select LastName "+setShortcut);

                        lblName.Text = "<a href='channel?=" + chk.stringCheck("select UserID from video where Video_ID='"+VideoID+"' ") + "'>" + FastName + " " + Lastname + "</a>";


                        string ImageUrl = "Profileimage/" + settingschk.stringCheck("select Image " + setShortcut);

                        ProfilePhotos.Text = "<a href='channel?=" + chk.stringCheck("select UserID from video where Video_ID='" + VideoID + "' ") + "' ><img src='" + ImageUrl + "' /></a>";
                        lblPostingDate.Text = chk.stringCheck("select postingDate " + shortcut);
                        lblview.Text = chk.stringCheck("select VideoView " + shortcut);
                        lblLike.Text = chk.stringCheck("select VideoLike " + shortcut);
                        
                        if (Session["UserID"] != null)
                        {
                            string FastName2 = settingschk.stringCheck("select FastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                            string Lastname2 = settingschk.stringCheck("select LastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                            lblName.Text = "<a href='channel?=" + chk.stringCheck("select UserID from video where Video_ID='" + VideoID + "' ") + "' >" + FastName2 + " " + Lastname2 + "</a>";

                            pnlMessege.Visible = true;
                            ProfilePhotoCommants.ImageUrl = "Profileimage/" + settingschk.stringCheck("select Image from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                            lblUserIDName.Text = FastName + " " + Lastname;
                            if (Session["UserID"].ToString() == UserID)
                            {
                                btnSubscribe.Visible = false;
                                btnUnsubscribe.Visible = false;
                            }
                            else
                            {
                                //--------other people login --------------
                                if (chk.int32Check("select count(*) from Subscribe where UserID='" + Session["UserID"].ToString() + "' and SubscribeID='" + UserID + "'") == 0)
                                {
                                    btnSubscribe.Visible = true;
                                    btnUnsubscribe.Visible = false;
                                }
                                else
                                {
                                    btnSubscribe.Visible = false;
                                    btnUnsubscribe.Visible = true;
                                }
                            }
                            //video count ---------------------------------                           
                            if (chk.int32Check("select count(*) from View_Tbl where UserID='" + Session["UserID"].ToString() + "' and VideoID='" + VideoID + "'") == 0)
                            {
                                int view = chk.int32Check("select VideoView " + shortcut);
                                view++;
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = Conn;
                                cmd.CommandText = "update video set VideoView=" + view + " where Video_ID='" + VideoID + "'";
                                Conn.Open();
                                cmd.ExecuteNonQuery();
                                Conn.Close();
                                cmd.CommandText = "insert into View_Tbl (UserID,VideoID,datetime,date) values(@UserID,@VideoID,@datetime,@date)";
                                cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                                cmd.Parameters.AddWithValue("@VideoID", VideoID);
                                cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
                                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd MMMM yy"));
                                Conn.Open();
                                cmd.ExecuteNonQuery();
                                Conn.Close();
                            }





                        }// login enable end
                        else
                        {                                
                                int view = chk.int32Check("select VideoView " + shortcut);
                                view++;
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = Conn;
                                cmd.CommandText = "update video set VideoView=" + view + " where Video_ID='" + VideoID + "'";
                                Conn.Open();
                                cmd.ExecuteNonQuery();
                                Conn.Close();
                                chk.ConfigarationName = "video";
                                string userID = chk.stringCheck("select UserID from video where Video_ID='" + VideoID + "'");
                                cmd.CommandText = "insert into DailyView (Date,Month,Year,VideoView,VideoID,UserID) values(@Date,@Month,@Year,@VideoView,@VideoID,@UserID)";
                                cmd.Parameters.AddWithValue("@Date", Convert.ToInt32(DateTime.Now.ToString("dd")));
                                cmd.Parameters.AddWithValue("@Month", Convert.ToInt32(DateTime.Now.ToString("MM")));
                                cmd.Parameters.AddWithValue("@Year", Convert.ToInt32(DateTime.Now.ToString("yyyy")));
                                cmd.Parameters.AddWithValue("@VideoView", view);
                                cmd.Parameters.AddWithValue("@VideoID", VideoID);
                                cmd.Parameters.AddWithValue("@UserID", userID );
                                Conn.Open();
                                cmd.ExecuteNonQuery();
                                Conn.Close();
                            
                            pnlMessege.Visible = false;// when no one loging
                            btnUnsubscribe.Visible = false;
                        }






                    }//public autorise end





                    else
                    {
                        Response.Redirect("Error?=Authority_Cancle");
                    }
                }
                else if(chk.stringCheck("select publishAuth from video where Video_ID='" + VideoID + "' ") == "PANDING")
                {


                }
                //Error authority end
                else
                {
                    Response.Redirect("Error?=Authority_Cancle");
                }

            }// query string is not empty end
            else
            {
                Response.Redirect("Default");
            }
        }

        protected void btnlike_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["UserID"] != null)
            {
                string UserID = Session["UserID"].ToString();
                string VideoID = Request.QueryString[""].ToString();
                check chk = new check();
                chk.ConfigarationName = "video";
                int count = chk.int32Check("select count(*) from Like_Tbl where UserID='"+UserID+"' and VideoID='"+VideoID+"' ");
                if (count == 0)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Conn;
                    cmd.CommandText = "insert into Like_Tbl (UserID,VideoID,datetime,date) values(@UserID,@VideoID,@datetime,@date)";
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@VideoID", VideoID);
                    cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd MMMM yy"));
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                    int totalLike = chk.int32Check("select VideoLike from video where Video_ID='" + VideoID + "'");
                    totalLike++;
                    cmd.CommandText = "update video set VideoLike=" + totalLike + " where Video_ID='" + VideoID + "'";
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
                

            }
            else
            {
                Response.Redirect("login");
            }
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                string VideoID = Request.QueryString[""].ToString();
                check chk = new check();
                chk.ConfigarationName = "video";
                string UserID = chk.stringCheck("select UserID from video where Video_ID='" + VideoID + "'");


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = "insert into Subscribe (UserID,SubscribeID,datetime,date) values(@UserID,@SubscribeID,@datetime,@date)";
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
                cmd.Parameters.AddWithValue("@SubscribeID", UserID);
                cmd.Parameters.AddWithValue("@datetime", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd MMMM yy"));
                Conn.Open();
                cmd.ExecuteNonQuery();
                Conn.Close();
                //Response.Redirect("watch?=" + VideoID);
                btnUnsubscribe.Visible = true;
                btnSubscribe.Visible = false;
            }
            else
            {
                Response.Redirect("login");
            }
        }

        protected void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            string VideoID = Request.QueryString[""].ToString();
            check chk = new check();
            chk.ConfigarationName = "video";
            string UserID = chk.stringCheck("select UserID from video where Video_ID='" + VideoID + "'");


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "delete from Subscribe where UserID='"+ Session["UserID"].ToString() + "' and SubscribeID='"+UserID+"'";
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
            //Response.Redirect("watch?=" + VideoID);
            btnSubscribe.Visible = true;
            btnUnsubscribe.Visible = false;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            check chk = new check();
            chk.ConfigarationName = "Settings";
            string fastName = chk.stringCheck("select FastName from Registation_Tbl where UserID='"+UserID+"'");
            string lastName = chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");



            string VideoID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "insert into "+VideoID+ " (Command,Name,Authority,DateTime,UserID) values (@Command,@Name,@Authority,@DateTime,@UserID)";
            cmd.Parameters.AddWithValue("@Command",txtMessege.Text);
            cmd.Parameters.AddWithValue("@Name", fastName +" "+lastName);
            cmd.Parameters.AddWithValue("@Authority","TRUE");
            cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString("dd MMMM yy"));
            cmd.Parameters.AddWithValue("@UserID",UserID);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();
            txtMessege.Text = "";
            showMessege();
        }


        private string SubCom(int CommandID)
        {
            string SubCommands = "";
            check chk = new check();
            chk.ConfigarationName = "video";
            string VideoID = Request.QueryString[""].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conv;
            cmd.CommandText = "select * from SubCommand where VideoID='" + VideoID+ "' and MCID='"+CommandID+"'";
            Conv.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                chk.ConfigarationName = "Settings";
                string MCID = data["MCID"].ToString();
                string Command = data["Command"].ToString();
                string Name = data["Name"].ToString();
                string Date = data["Date"].ToString();
                string UserID = data["UserID"].ToString();
                int ID = Convert.ToInt32(data["ID"]);
                string Delete = "";
                string Image = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + UserID + "'");

                chk.ConfigarationName = "video";
                if (Session["UserID"] != null)
                {
                    if(chk.int32Check("select count(*) from SubCommand where MCID='"+ CommandID + "' and VideoID='"+ VideoID + "' and UserID='" + Session["UserID"].ToString() + "'")>0)
                    {
                        string sk = "";
                        if(Request.QueryString["SK"]!=null)
                        {
                            sk = "FALSE";
                        }
                        Delete = string.Format("<span><a href='delete?={0}&Cmdid={1}&url={2}&ses={3}&p={4}&mc={5}'><i class='fa fa-trash'></i> Delete</a></span> <span><a href='delete?E={0}&ECmdid={1}&Eurl={2}&Eses={3}&Ep={4}&Emc={5}'>", VideoID, ID, sk, Session["UserID"].ToString(), "watch", "sub");
                        //-----------------------
                        string Edit = string.Format("<span><a href='#' onclick=\"window.open('Replay?Evid={0}&Ecid={1}&Evb={2}&Euid={3}',null,'left=200,right=550, width=500, status=no, resizable=yes, scrollbars=yes, toolbar=no, location=no, menubar=no');\" ><i class='fa fa-pencil'></i> Edit</a></span>", VideoID, MCID, "Edit", Session["UserID"].ToString());

                        Delete += Edit;
                    }
                }
                SubCommands += string.Format(@"
                <div class='media-object stack-for-small reply-comment'>
                    <div class='media-object-section comment-img text-center'>
                        <div class='comment-box-img'>
                            <img src='{0}' alt='comment'>
                        </div>
                    </div>
                    <div class='media-object-section comment-desc'>
                        <div class='comment-title'>
                            <span class='name'><a href='#'>{1}</a> Said:</span>
                            <span class='time float-right'><i class='fa fa-clock-o'></i>{2}</span>
                     </div>
                     <div class='comment-text'>
                            <p>{3}</p>
                      </div>
                      <div class='comment-btns'>
                            {4}
                            <span class='reply float-right hide-reply'></span>
                       </div>                                                   
                   </div>
                </div>
        

",Image,Name,Date,Command,Delete);


                }
            Conv.Close();

            return SubCommands;
        }
        private void showMessege()
        {
            messegeshowplc.Controls.Clear();
        check chk = new check();
            chk.ConfigarationName = "Settings";
            string VideoID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandText = "select * from "+ VideoID;
            Conn.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while(data.Read())
            {
                chk.ConfigarationName = "Settings";
                int ID = Convert.ToInt32(data["ID"]);
                string command = data["Command"].ToString();
                string Name = data["Name"].ToString();
                string Authorise = data["Authority"].ToString();
                string Date = data["DateTime"].ToString();
                string userId = data["UserID"].ToString();
                string Image = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='"+userId+"'");

                if(Authorise=="TRUE")
                {
                    string DeleteCmd = "";
                    string SubCommand = "";
                    chk.ConfigarationName = "video";
                    if(Session["UserID"] !=null)
                    {
                        if (chk.int32Check("select count(*) from " + VideoID + " where UserID='" + Session["UserID"].ToString() + "' and ID="+ID+"") > 0)
                        {
                            string sk = "";
                            if (Request.QueryString["SK"] != null)
                            {
                                sk = "FALSE";
                            }
                            DeleteCmd = string.Format("<span><a href='delete?={0}&Cmdid={1}&url={2}&ses={3}&p={4}&mc={5}'><i class='fa fa-trash'></i> Delete</a></span>", VideoID, ID, sk, Session["UserID"].ToString(), "watch", "Main");
                            string Edit = string.Format("<span><a href='#' onclick=\"window.open('Replay?C={0}&I={1}',null,'left=200,right=550, width=500, status=no, resizable=yes, scrollbars=yes, toolbar=no, location=no, menubar=no');\" ><i class='fa fa-pencil'></i> Edit</a></span>", VideoID, ID);

                          //  string Edit = string.Format("<span><a href='#' onclick=\"window.open('Replay?Evid={0}&Ecid={1}&Evb={2}&Euid={3}',null,'left=200,right=550, width=500, status=no, resizable=yes, scrollbars=yes, toolbar=no, location=no, menubar=no');\" ><i class='fa fa-pencil'></i> Edit</a></span>", VideoID, ID, "Edit", Session["UserID"].ToString());
                            DeleteCmd += Edit;


                        }
                        else
                        {
                            DeleteCmd = "";
                        }
                    }

                    //if(chk.int32Check("select count(*) from "+VideoID+" where sub='TRUE' and ID="+ID+"")>0)
                    //{
                    //    if(chk.int32Check("select count(*) from SubCommand where MCID='"+VideoID+"'")>0)
                    //    {
                            SubCommand = "";
                    //    }
                    //}
                            string ss = "";
                    
                            if (Session["UserID"] != null)
                            {
                                ss = string.Format("<span><a href='#' onclick=\"window.open('Replay?vid={0}&cid={1}&vb={2}&uid={3}',null,'left=200,right=550, width=500, status=no, resizable=yes, scrollbars=yes, toolbar=no, location=no, menubar=no');\" ><i class='fa fa-share'></i>Reply</a></span>", VideoID, ID, "video", Session["UserID"].ToString());
                            }
messegeshowplc.Controls.Add(new LiteralControl(string.Format(@"

<div class='media-object stack-for-small'>
    <div class='media-object-section comment-img text-center'>
            <div class='comment-box-img'>
                <img src='{0}'>
            </div>
     </div>
    <div class='media-object-section comment-desc'>
        <div class='comment-title'>
            <span class='name'><a href='#'>{1}</a> Said:</span>
            <span class='time float-right'><i class='fa fa-clock-o'></i>{2}</span>
        </div>
        <div class='comment-text'>
            <p>{3}</p>
        </div>
        <div class='comment-btns'>
            {6}        
            {4}
            <span class='reply float-right hide-reply'></span>
        </div>
        {5}
    </div>
</div>

"




, Image,Name,Date,command,DeleteCmd, SubCom(ID), ss)));
                }
            }
            Conn.Close();

        }

        /* 
              
                                    <div class='media-object stack-for-small'>
                                        <div class='media-object-section comment-img text-center'>
                                            <div class='comment-box-img'>
                                                <img src= 'images/post-author-post.png' alt='comment'>
                                            </div>
                                        </div>
                                        <div class='media-object-section comment-desc'>
                                            <div class='comment-title'>
                                                <span class='name'><a href='#'>Joseph John</a> Said:</span>
                                                <span class='time float-right'><i class='fa fa-clock-o'></i>1 minute ago</span>
                                            </div>

                                            <div class='comment-text'>
                                                <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventoresunt explicabo.</p>
                                            </div>
                                            <div class='comment-btns'>
                                                <span><a href='#'><i class='fa fa-share'></i>Reply</a></span>
                                                <span><a href='#'><i class='fa fa-trash'></i>Delect</a></span>
                                                <span class='reply float-right hide-reply'></span>
                                            </div>


                                            <!--sub comment-->
                                            <div class='media-object stack-for-small reply-comment'>
                                                <div class='media-object-section comment-img text-center'>
                                                    <div class='comment-box-img'>
                                                        <img src= 'images/post-author-post.png' alt='comment'>
                                                    </div>
                                                </div>
                                                <div class='media-object-section comment-desc'>
                                                    <div class='comment-title'>
                                                        <span class='name'><a href='#'>Joseph John</a> Said:</span>
                                                        <span class='time float-right'><i class='fa fa-clock-o'></i>1 minute ago</span>
                                                    </div>
                                                    <div class='comment-text'>
                                                        <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventoresunt explicabo.</p>
                                                    </div>
                                                    <div class='comment-btns'>
                                                        <span><a href='#'><i class='fa fa-trash'></i> Delect</a></span>
                                                        <span class='reply float-right hide-reply'></span>
                                                    </div>                                                   
                                                </div>
                                            </div>



                                        </div>
                                    </div>
                             
             
             
             */




        protected void btnSkipAdd_Click(object sender, EventArgs e)
        {
            string VideoID = Request.QueryString[""].ToString();

            Response.Redirect("watch?="+VideoID+"&SK=FALSE");

        }

        private void SkipAdd(int Time,string VideoID)
        {
            pnlSkipAdd.Controls.Add(new LiteralControl(@"<script>const monthNames = ['January', 'February', 'March', 'April', 'May', 'June','July', 'August', 'September', 'October', 'November', 'December'];var d = new Date();var Min = d.getMinutes();var Sec = d.getSeconds();var Hour = d.getHours();var dates = d.getDate();var Month = d.getMonth() + 1;var Year = d.getFullYear(); Sec += "+Time+";var c = monthNames[d.getMonth()] + ' ' + dates + ', ' + Year + ' ' + Hour + ':' + Min + ':' + Sec;var countDownDate = new Date(c).getTime();var x = setInterval(function() {var now = new Date().getTime();var distance = countDownDate - now;var days = Math.floor(distance / (1000 * 60 * 60 * 24));var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));var seconds = Math.floor((distance % (1000 * 60)) / 1000);if (distance < 0){clearInterval(x);window.location.href = 'http://www.bdbayonline.com/watch?="+VideoID+"&SK=FALSE';}}, 1000);</script>"));
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            var ID = Request.QueryString[""].ToString();
            var Link = "https://www.facebook.com/sharer/sharer.php?u=http://www.bdbayonline.com/watch?="+ID;
            Response.Redirect(Link);
        }

        protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
        {
            var ID = Request.QueryString[""].ToString();
            var Link = "https://twitter.com/home?status=http://www.bdbayonline.com/watch?="+ID;
            Response.Redirect(Link);
        }
    }
}