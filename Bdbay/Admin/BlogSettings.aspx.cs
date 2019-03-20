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
    public partial class BlogSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridView1.Visible = false;
            }
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        SqlConnection conv = new SqlConnection(ConfigurationManager.ConnectionStrings["video"].ConnectionString);
        SqlConnection conb = new SqlConnection(ConfigurationManager.ConnectionStrings["blogcs"].ConnectionString);
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCategory.Text!="")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into Blog_Catagory_Tbl(Catagoris,value) values(@Catagoris,@value)";
                cmd.Parameters.AddWithValue("@Catagoris",txtCategory.Text);
                cmd.Parameters.AddWithValue("@value",txtValue.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                txtValue.Text = "";
                txtCategory.Text = "";
                lblResult.Text = "Sucessfully Add Category.";
                GridView1.DataBind();
            }
            else
            {
                lblResult.Text = "Please Add Category.";
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckBox1.Checked==true)
            {
                GridView1.Visible = true;
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        protected void chkADON_CheckedChanged(object sender, EventArgs e)
        {
            if(chkADON.Checked==true)
            {
                chkADOFF.Checked = false;
            }
        }

        protected void chkADOFF_CheckedChanged(object sender, EventArgs e)
        {
            if(chkADOFF.Checked==true)
            {
                chkADON.Checked = false;
            }
        }

        protected void chkPUBON_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPUBON.Checked==true)
            {
                chkPUBOFF.Checked = false;
            }
        }

        protected void chkPUBOFF_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPUBOFF.Checked==true)
            {
                chkPUBON.Checked = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if(chkADOFF.Checked==true)
            {
                cmd.Connection = conb;
                cmd.CommandText = "update blog_Tbl set Advetise='FALSE'";
                conb.Open();
                cmd.ExecuteNonQuery();
                conb.Close();
            }
            if(chkADON.Checked==true)
            {
                cmd.Connection = conb;
                cmd.CommandText = "update blog_Tbl set Advetise='TRUE'";
                conb.Open();
                cmd.ExecuteNonQuery();
                conb.Close();
            }
            if(chkPUBON.Checked==true)
            {
                cmd.Connection = conb;
                cmd.CommandText = "update blog_Tbl set PublishAutho='TRUE'";
                conb.Open();
                cmd.ExecuteNonQuery();
                conb.Close();
            }
            if(chkPUBOFF.Checked==false)
            {
                cmd.Connection = conb;
                cmd.CommandText = "update blog_Tbl set PublishAutho='FALSE'";
                conb.Open();
                cmd.ExecuteNonQuery();
                conb.Close();
            }



            
        }
    }
}