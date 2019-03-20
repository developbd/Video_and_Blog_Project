using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Bdbay
{
    public partial class Registation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void btnREG_Click(object sender, EventArgs e)
        {
            check _CHK_ = new check();
            _CHK_.ConfigarationName = "Settings";
            lblResult.Text = "";
            int err = 0;
            if (string.IsNullOrEmpty(txtFastName.Text))
            {
                err++;
                lblResult.Text += "[Fast Name Requied]<br/>";
            }
            if(string.IsNullOrEmpty(txtLastName.Text))
            {
                err++;
                lblResult.Text += "[Last Name Requied]<br/>";
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                err++;
                lblResult.Text += "[Email Requied]<br/>";
            }
            else
            {
                if (_CHK_.int32Check("select count(*) from Registation_Tbl where Email='" + txtEmail.Text + "'") == 1)
                {
                    err++;
                    lblResult.Text += "[Email is Already Available]<br/>";
                }
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                err++;
                lblResult.Text += "[Password Requied]<br/>";
            }
            if(ddlCountry.SelectedValue=="0")
            {
                err++;
                lblResult.Text += "[Country Requied]<br/>";
            }
            if (ddlGender.SelectedValue == "0")
            {
                err++;
                lblResult.Text += "[Gender Requied]<br/>";
            }
            if (err == 0)
            {
                try
                {
                    check chk = new check();
                    chk.ConfigarationName = "Settings";
                    RandomNumber RAN = new RandomNumber();
                    RAN.HowMuchNumber = 10;
                    string UserID = RAN.RandomStringNumber("UserID");
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"insert into Registation_Tbl (UserID,FastName,LastName,Email,Password,Gender,Country,Authority,Image,CoverPhoto,JoinDate,date,month,year,Datetime,Phone,Website,Address,Description,uploadAuthority,TotalView,TotalVideos,writeAuthority)
                        values(@UserID,@FastName,@LastName,@Email,@Password,@Gender,@Country,@Authority,@Image,@CoverPhoto,@JoinDate,@date,@month,@year,@Datetime,@Phone,@Website,@Address,@Description,@uploadAuthority,@TotalView,@TotalVideos,@writeAuthority)";
                    cmd.Parameters.AddWithValue("@UserID",UserID);
                    cmd.Parameters.AddWithValue("@FastName",txtFastName.Text);
                    cmd.Parameters.AddWithValue("@LastName",txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Email",txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Password",txtPassword.Text);
                    cmd.Parameters.AddWithValue("@Gender",ddlGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Authority", "TRUE"); 
                    cmd.Parameters.AddWithValue("@JoinDate", DateTime.Now.ToString("dd MMMM yy"));
                    cmd.Parameters.AddWithValue("@date", Convert.ToInt32(DateTime.Now.ToString("dd")));
                    cmd.Parameters.AddWithValue("@month", Convert.ToInt32(DateTime.Now.ToString("MM")));
                    cmd.Parameters.AddWithValue("@year", Convert.ToInt32(DateTime.Now.ToString("yyyy")));
                    cmd.Parameters.AddWithValue("@Datetime", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Phone", "No Pnone Number Available");
                    cmd.Parameters.AddWithValue("@Website", "No WebSite Available");
                    cmd.Parameters.AddWithValue("@Address", "Address Not Available");
                    cmd.Parameters.AddWithValue("@Description", "No Description"); 
                    cmd.Parameters.AddWithValue("@uploadAuthority", chk.stringCheck("select Authorise from settings where Name='All_video_Auth'"));
                    if (ddlGender.SelectedValue == "Male")
                    {
                        cmd.Parameters.AddWithValue("@Image", "male.png");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Image", "female.png");
                    }
                    cmd.Parameters.AddWithValue("@CoverPhoto", "cover.jpg");
                    cmd.Parameters.AddWithValue("@TotalView",Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@TotalVideos", Convert.ToInt32(0));
                    cmd.Parameters.AddWithValue("@writeAuthority", chk.stringCheck("select Authorise from settings where Name='All_Blog_Auth'"));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    txtEmail.Text = "";
                    txtFastName.Text = "";
                    txtLastName.Text = "";
                    txtPassword.Text = "";
                    ddlCountry.SelectedValue = "0";
                    ddlGender.SelectedValue = "0";

                    Session["UserID"] = UserID;
                    Session["UserFastName"] = txtFastName.Text;
                    Session["UserLastName"] = txtLastName.Text;
                    Response.Redirect("~/Default");

                   // lblResult.Text = "Insert";

                }
                catch (Exception error)
                {
                    lblResult.Text = "Error: "+error.Message;
                }
            }

        }
    }
}