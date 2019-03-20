using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bdbay
{
    public partial class search : System.Web.UI.Page
    {
        SqlConnection Videocon = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection Blogcon = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        SqlConnection Setingscon = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString[""]!=null)
            {
                check chk = new check();
                chk.ConfigarationName = "Settings";

                string Scarch_Show = "";

                string Scarch = Request.QueryString[""].ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Videocon;
                cmd.CommandText = string.Format("select * from video where publishAuth='TRUE' and Title like '%{0}%'  ", Scarch);
                Videocon.Open();
                SqlDataReader data = cmd.ExecuteReader();
                while(data.Read())
                {
                    string Title = data["Title"].ToString();
                    string Image = data["ThambailLink"].ToString();
                    string UserID = data["UserID"].ToString();
                    string VideoID = data["Video_ID"].ToString();
                    string Like = data["VideoLike"].ToString();
                    string postingDate = data["postingDate"].ToString();
                    string View = data["VideoView"].ToString();
                    string FastName = chk.stringCheck("select FastName from Registation_Tbl where UserID='"+ UserID + "'");

                    Scarch_Show += string.Format(@"

                                          <div class='item large-4 medium-6 columns grid-default end'>
                                                  <div class='post thumb-border'>
                                                      <div class='post-thumb'>
                                                          <img src='{0}' alt='new video'>
                                                          <a href='watch?={7}' class='hover-posts'>
                                                              <span><i class='fa fa-play'></i>Watch Video</span>
                                                          </a>
                                                          <div class='video-stats clearfix'>
                                                              <div class='thumb-stats pull-left'>
                                                                  <i class='fa fa-thumbs-up'></i>
                                                                  <span>{1}</span>
                                                              </div>
                                                          </div>
                                                      </div>
                                                      <div class='post-des'>
                                                          <h6><a href='watch?={2}'>{3}</a></h6>
                                                          <div class='post-stats clearfix'>
                                                              <p class='pull-left'>
                                                                  <i class='fa fa-user'></i>
                                                                  <span><a >{4}</a></span>
                                                              </p>
                                                              <p class='pull-left'>
                                                                  <i class='fa fa-clock-o'></i>
                                                                  <span>{5}</span>
                                                              </p>
                                                              <p class='pull-left'>
                                                                  <i class='fa fa-eye'></i>
                                                                  <span>{6}</span>
                                                        </p>
                                                    </div>                                                         
                                                </div>
                                            </div>
                                        </div>                    

                    ", Image,Like,VideoID,Title, FastName,postingDate,View,VideoID);
                }


                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = Setingscon;
                cmd2.CommandText = string.Format("select * from Registation_Tbl where FastName like '%{0}%' or LastName like '%{1}%' ", Scarch, Scarch);
                Setingscon.Open();
                SqlDataReader setDate = cmd2.ExecuteReader();
                while(setDate.Read())
                {
                    string FastName = setDate["FastName"].ToString();
                    string LastName = setDate["LastName"].ToString();
                    string Image = "Profileimage/" + setDate["Image"].ToString();
                    string UserID = setDate["UserID"].ToString();
                    //string Like = data["VideoLike"].ToString();
                    //string postingDate = data["postingDate"].ToString();
                    //string View = data["VideoView"].ToString();

                    Scarch_Show += string.Format(@"

                                          <div class='item large-4 medium-6 columns grid-default end'>
                                                  <div class='post thumb-border'>
                                                      <div class='post-thumb'>
                                                          <img src='{0}' alt='new video'>
                                                          <a href='channel?={3}' class='hover-posts'>
                                                              <span><i class='fa fa-play'></i>View Channel</span>
                                                          </a>                                                          
                                                      </div>
                                                      <div class='post-des'>
                                                          <h6><a href='channel?={1}'>{2}</a></h6>
                                                                                                                 
                                                </div>
                                            </div>
                                        </div>                    

                    ", Image,UserID,FastName+LastName,UserID);



                }
                Setingscon.Close();

                SqlCommand cmd3 = new SqlCommand();
                cmd3.Connection = Blogcon;
                cmd3.CommandText = string.Format("select * from blog_Tbl where PublishAutho='TRUE' and Title like '%{0}%'  ", Scarch);
                Blogcon.Open();
                SqlDataReader blData = cmd3.ExecuteReader();
                while(blData.Read())
                {
                    string Title = blData["Title"].ToString();
                    string Image = blData["LinkThumbnail"].ToString();
                    string UserID = blData["UserID"].ToString();
                    string BlogID = blData["BlogID"].ToString();
                   // string Like = blData["VideoLike"].ToString();
                    string postingDate = blData["PostingDate"].ToString();
                   // string View = blData["VideoView"].ToString();
                    string FastName = chk.stringCheck("select FastName from Registation_Tbl where UserID='" + UserID + "'");

                    Scarch_Show += string.Format(@"

                                          <div class='item large-4 medium-6 columns grid-default end'>
                                                  <div class='post thumb-border'>
                                                      <div class='post-thumb'>
                                                          <img src='{0}' alt='new video'>
                                                          <a href='Read?={1}' class='hover-posts'>
                                                              <span><i class='fa fa-book'></i>Read</span>
                                                          </a>
                                                      </div>
                                                      <div class='post-des'>
                                                          <h6><a href='Read?={2}'>{3}</a></h6>
                                                          <div class='post-stats clearfix'>
                                                              <p class='pull-left'>
                                                                  <i class='fa fa-user'></i>
                                                                  <span><a >{4}</a></span>
                                                              </p>
                                                              <p class='pull-left'>
                                                                  <i class='fa fa-clock-o'></i>
                                                                  <span>{5}</span>
                                                              </p>
                                                              
                                                    </div>                                                         
                                                </div>
                                            </div>
                                        </div>                    

                    ", Image,BlogID,BlogID,Title,FastName,postingDate);


                }
                Blogcon.Close();






                pnlShowScarch.Controls.Add(new LiteralControl(Scarch_Show));


            }
            else
            {
                Response.Redirect("Error?=Empty Scarch..");
            }


        }
    }
}


/* 

 <div class='item large-4 medium-6 columns grid-default end'>
                              <div class='post thumb-border'>
                                  <div class='post-thumb'>
                                      <img src='images/video-thumbnail/12.jpg' alt='new video'>
                                      <a href='watch' class='hover-posts'>
                                          <span><i class='fa fa-play'></i>Watch Video</span>
                                      </a>
                                      <div class='video-stats clearfix'>
                                          <div class='thumb-stats pull-left'>
                                              <i class='fa fa-thumbs-up'></i>
                                              <span>506</span>
                                          </div>

                                      </div>
                                  </div>
                                  <div class='post-des'>
                                      <h6><a href='watch'>There are many variations of passage.</a></h6>
                                      <div class='post-stats clearfix'>
                                          <p class='pull-left'>
                                              <i class='fa fa-user'></i>
                                              <span><a href='#'>admin</a></span>
                                          </p>
                                          <p class='pull-left'>
                                              <i class='fa fa-clock-o'></i>
                                              <span>5 January 16</span>
                                          </p>
                                          <p class='pull-left'>
                                              <i class='fa fa-eye'></i>
                                              <span>1,862K</span>
                                          </p>
                                      </div>                                                           

                                  </div>
                              </div>
                          </div>
*/
