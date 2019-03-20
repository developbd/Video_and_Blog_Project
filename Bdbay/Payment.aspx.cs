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
    public partial class Payment : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] !=null)
            {
                check chk = new check();
                chk.ConfigarationName = "Settings";
                var userID = Session["UserID"].ToString();
                int BDT = 0;
                string show = chk.stringCheck("select sum(BDT) from Payment where UserID='" + Session["UserID"].ToString() + "'");

                if (show == "" || show == string.Empty || show == " ")
                {
                    lblBDT.Text = BDT.ToString();
                }
                else
                {
                    lblBDT.Text = show;
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Payment where UserID='" + userID + "'";
                con.Open();
                SqlDataReader data = cmd.ExecuteReader();


                while(data.Read())
                {
                    string ID = data["PaymentID"].ToString();
                    string Link = "";
                    if(ID.Substring(0,1)=="V")
                    {
                        Link = "watch"; 
                    }
                    else
                    {
                        Link = "Read";
                    }
                    showPament.Controls.Add(new LiteralControl(string.Format(@"<div style='padding:20px; border:1px solid #808080;'>
                                      <div style='padding-left:20px;'>Payment ID: <a>{0}</a></div>
                                      <div style='padding-left:20px;'>Video/Blog: <a herf='{5}'>{1}</a></div>
                                      <div style='padding-left:20px;'>Details: <a>{2}</a></div>
                                      <div style='padding-left:20px;'>Date: <a>{3}</a></div>
                                      <div style='padding-left:20px;'>BDT: <a>{4}</a></div>
                                      <div style='padding-left:20px;'><aherf='{7}'>{6}</a></div>
                                  </div><br/>", data["ID"], data["VoB"], data["Details"], data["PostingDate"], data["BDT"],Link+"?="+data["PaymentID"],"http://bdbay.net/"+Link+"?="+ data["PaymentID"], Link + "?=" + data["PaymentID"])));
                }
                con.Close();

                                 

            }

        }
    }
}