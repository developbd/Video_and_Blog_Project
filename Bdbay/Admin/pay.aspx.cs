using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Bdbay.Admin
{
    public partial class pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ref"] == "NonAuthoriseBlog" || Request.QueryString["ref"] == "NonAuthoriseVideo")
            {
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
            }
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] !=null && Request.QueryString["ref"] !=null &txtBDT.Text!="")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Payment (BDT,PaymentID,VoB,Details,DateTime,Date,Time,Year,PostingDate,UserID) values(@BDT,@PaymentID,@VoB,@Details,@DateTime,@Date,@Time,@Year,@PostingDate,@UserID)";
                cmd.Parameters.AddWithValue("@BDT",txtBDT.Text);
                cmd.Parameters.AddWithValue("@PaymentID", Request.QueryString["id"].ToString());
                cmd.Parameters.AddWithValue("@VoB", Request.QueryString["ref"].ToString());
                cmd.Parameters.AddWithValue("@Details",txtDeatils.Text);
                cmd.Parameters.AddWithValue("@DateTime",DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@Date",DateTime.Now.ToString("dd"));
                cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToString("MM"));
                cmd.Parameters.AddWithValue("@Year", DateTime.Now.ToString("yy"));
                cmd.Parameters.AddWithValue("@PostingDate", DateTime.Now.ToString("dd MM yyyy"));
                cmd.Parameters.AddWithValue("@UserID", Request.QueryString["UsrID"].ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lblResult.Text = "Sucessfully Pament Add..";
                txtDeatils.Text = "";
                txtBDT.Text = "";
                GridView1.DataBind();
            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var refer = Request.QueryString["ref"].ToString();
            Response.Redirect("show?="+refer);
        }
    }
}