using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Bdbay
{
    public partial class read : System.Web.UI.Page
    {
        SqlConnection blogcon = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString[""]!=null)
            {
                showMessege();
                string BlogId = Request.QueryString[""].ToString();
                check chk = new check();
                chk.ConfigarationName = "blogcs";
                string shortcut = " from blog_Tbl where BlogID='" + BlogId + "'";
                if (chk.int32Check("select count(*) from blog_Tbl where BlogID='"+BlogId+"'")==1)
                {
                    if (chk.stringCheck("select PublishAutho " + shortcut) == "TRUE")
                    {
                        lblTitle.Text = chk.stringCheck("select Title " + shortcut);
                        lblPostingDate.Text = chk.stringCheck("select PostingDate " + shortcut);
                        lblShortDetails.Text = chk.stringCheck("select ShortDetails " + shortcut);
                        string UserID = chk.stringCheck("select UserID " + shortcut);

                        chk.ConfigarationName = "Settings";                        
                        string fastname = chk.stringCheck("select FastName from Registation_Tbl where UserID='"+UserID+"'");
                        string lastname = chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");
                        string name = fastname + " " + lastname;
                        userName.Text = name;
                        userName.NavigateUrl = "channel?="+UserID;
                        lblwriterBy.Text = name;
                        BloggerImage.ImageUrl = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + UserID + "'");

                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = blogcon;
                        cmd.CommandText = "select * from " + BlogId;
                        blogcon.Open();
                        SqlDataReader data = cmd.ExecuteReader();
                        string Blog="";
                        while(data.Read())
                        {
                            Blog += data["Blog_Write"].ToString();
                        }
                        blogcon.Close();
                        chk.ConfigarationName = "blogcs";
                        int Word = Convert.ToInt32(txtChar.Text);
                        int count_Total_in_Blog = Blog.Length;                       
                        if (count_Total_in_Blog > Word)
                        {
                            if (chk.int32Check("select count(*) from BlogADD where BlogID='" + BlogId + "'") > 0)
                            {
                                // string FastBlog = Blog.Substring(0, Charater);
                                // string SecondBlog = Blog.Substring(Charater, count_Total_in_Blog-1);
                                // FastBlog += "<img src='" + chk.stringCheck("select top 1 AddLink from BlogADD where BlogID='" + BlogId + "' ORDER BY NEWID()") + "' /><br />";
                                Blog = advertisement(Convert.ToInt32(txtWord.Text), Blog, "<img Width='100%' Height='100' src='" + chk.stringCheck("select top 1 AddLink from BlogADD where BlogID='" + BlogId + "' ORDER BY NEWID()") + "' />");
                               // Blog = Blog.Insert(Charater, "<br/> <img Width='700' Height='100' src='" + chk.stringCheck("select top 1 AddLink from BlogADD where BlogID='" + BlogId + "' ORDER BY NEWID()") + "' /> <br/>");
                            }
                        }
                        else
                        {
                            if (chk.int32Check("select count(*) from BlogADD where BlogID='" + BlogId + "'") > 0)
                            {
                                Blog += "<br/> <img Width='100%' Height='100' src='" + chk.stringCheck("select top 1 AddLink from BlogADD where BlogID='" + BlogId + "' ORDER BY NEWID()") + "' />";
                            }

                        }
                      //  Blog += "<br/> <img Width='100%' Height='100' src='" + chk.stringCheck("select top 1 AddLink from BlogADD where BlogID='" + BlogId + "' ORDER BY NEWID()") + "' />";

                       

                        lblBlog.Text = Blog;
                        chk.ConfigarationName = "blogcs";
                        int count = chk.int32Check("select ViewBlog from blog_Tbl where BlogID='" + BlogId + "'");
                        count++;
                        cmd.CommandText = "update blog_Tbl set ViewBlog="+count+ " where BlogID='" + BlogId + "'";
                        blogcon.Open();
                        cmd.ExecuteNonQuery();
                        blogcon.Close();


                        if(Session["UserID"]!=null)
                        {
                            pnlMessege.Visible = true;
                            check settingschk = new check();
                            settingschk.ConfigarationName = "Settings";
                            ProfilePhotoCommants.ImageUrl = "Profileimage/" + settingschk.stringCheck("select Image from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                            string FastName = settingschk.stringCheck("select FastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                            string Lastname = settingschk.stringCheck("select LastName from Registation_Tbl where UserID='" + Session["UserID"].ToString() + "'");
                            lblUserIDName.Text = FastName + " " + Lastname;


                        }
                        else
                        {
                            pnlMessege.Visible = false;
                        }





                    }
                    else
                    {
                        Response.Redirect("error?=Admin Cancle This Blog.");
                    }

                }
                else
                {
                    Response.Redirect("error?=Blog Not Found");
                }


            }
            else
            {
                Response.Redirect("error?=Blog Not Found");
            }
        }


        private string advertisement(int word, string input, string ADD)
        {
            int Find_Add = word;
            int count_Char = 0;
            string pattern = " ";
            string[] words = null;
            int i = 0;
            int count = 0;
            // Console.WriteLine(input);
            words = Regex.Split(input, pattern, RegexOptions.IgnoreCase);
            for (i = words.GetLowerBound(0); i <= words.GetUpperBound(0); i++)
            {
                count_Char++;
                if (words[i].ToString() == string.Empty)
                { count = count - 1; }
                count = count + 1;
                if (count == Find_Add)
                {
                    int index = input.IndexOf(words[i]);
                    //Response.Write(words[i].ToString()+"<br/>");
                    //Response.Write(input.IndexOf(words[i].ToString()) + "<br/>");
                    input = input.Insert(index, "<br/>" + ADD + "<br/>");
                    //work 
                    break;
                }
            }
            return input;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessege.Text != "")
            {
                string UserID = Session["UserID"].ToString();
                check chk = new check();
                chk.ConfigarationName = "Settings";
                string fastName = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'");
                string lastName = chk.stringCheck("select LastName from Registation_Tbl where UserID='" + UserID + "'");



                string BlogId = Request.QueryString[""].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = blogcon;
                cmd.CommandText = "insert into BlogCommand (BlogID,UserID,UserName,Command,Authority,DateTime) values (@BlogID,@UserID,@UserName,@Command,@Authority,@DateTime)";
                cmd.Parameters.AddWithValue("@BlogID", BlogId);
                cmd.Parameters.AddWithValue("@Command", txtMessege.Text);
                cmd.Parameters.AddWithValue("@UserName", fastName + " " + lastName);
                cmd.Parameters.AddWithValue("@Authority", "TRUE");
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString("dd MMMM yy"));
                cmd.Parameters.AddWithValue("@UserID", UserID);
                blogcon.Open();
                cmd.ExecuteNonQuery();
                blogcon.Close();
                txtMessege.Text = "";
                showMessege();
            }
        }

        private void showMessege()
        {
            check chk = new check();
            chk.ConfigarationName = "Settings";
            string VideoID = Request.QueryString[""].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = blogcon;
            cmd.CommandText = "select * from BlogCommand where BlogID='" + VideoID+"'   ";
            blogcon.Open();
            SqlDataReader data = cmd.ExecuteReader();
            string Delete = ""; string Edit = "";
            while (data.Read())
            {
                string command = data["Command"].ToString();
                string Name = data["UserName"].ToString();
                string Authorise = data["Authority"].ToString();
                string Date = data["DateTime"].ToString();
                string userId = data["UserID"].ToString();
                string Image = "Profileimage/" + chk.stringCheck("select Image from Registation_Tbl where UserID='" + userId + "'");
                if (Authorise == "TRUE")
                {
                    if (Session["UserID"] != null)
                    {
                        if (Session["UserID"].ToString() == userId)
                        {
                            string BlogId = Request.QueryString[""].ToString();
                            Delete = string.Format(" <span><a href='delete?BID={0}&CMDID={1}'><i class='fa fa-trash'></i> Delete</a></span> ", data["BlogID"].ToString(), data["ID"].ToString());
                            Edit = string.Format(" <span><a href='#' onclick=\"window.open('Replay?bid={0}&bcid={1}',null,'left=200,right=550, width=500, status=no, resizable=yes, scrollbars=yes, toolbar=no, location=no, menubar=no');\" ><i class='fa fa-pencil'></i> Edit</a></span>", data["BlogID"].ToString(), data["ID"].ToString());
                        }
                    }
                    messegeshowplc.Controls.Add(new LiteralControl(@"<div class='media-object stack-for-small'><div class='media-object-section comment-img text-center'><div class='comment-box-img'><img src='" + Image + "'></div></div><div class='media-object-section comment-desc'><div class='comment-title'><span class='name'><a href = '#' > " + Name + "</a> Said:</span><span class='time float-right'><i class='fa fa-clock-o'></i>" + Date + "</span></div><div class='comment-text'><p>" + command + "</p> "+Delete + Edit+" </div></div></div>"));
                }
            }
            blogcon.Close();

        }

        protected void ImageButtonfacebook_Click(object sender, ImageClickEventArgs e)
        {
            var ID = Request.QueryString[""].ToString();
            var Link = "https://www.facebook.com/sharer/sharer.php?u=http://www.bdbay.net/Read?=" + ID;
            Response.Redirect(Link);
        }

        protected void ImageButtonTwitter_Click(object sender, ImageClickEventArgs e)
        {
            var ID = Request.QueryString[""].ToString();
            var Link = "https://twitter.com/home?status=http://www.bdbay.net/Read?=" + ID;
            Response.Redirect(Link);
        }
    }
}