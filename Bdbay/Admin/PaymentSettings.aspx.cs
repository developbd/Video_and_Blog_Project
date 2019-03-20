using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Bdbay.Admin
{
    public partial class PaymentSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void btnVideo_Click(object sender, EventArgs e)
        {
            bool ON_OFF=true;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Auto_Payment_Settings where VoB='VIDEO'";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while(data.Read())
            {
                int count = Convert.ToInt32(data["LastTarget"]);
                if(count==-1)
                {
                    ON_OFF = false;
                    break;
                }
            }
            con.Close();

            if (ON_OFF == true)
            {
                if (txtVideoTarget1st.Text != "" && txtVideoTarget2nd.Text != "" && txtVideoTargetAmount.Text != "")
                {
                    SqlCommand Insert = new SqlCommand();
                    Insert.Connection = con;
                    Insert.CommandText = "insert into Auto_Payment_Settings (VoB,FirstTarget,LastTarget,Amount,DateTime) values(@VoB,@FirstTarget,@LastTarget,@Amount,@DateTime)";
                    Insert.Parameters.AddWithValue("@VoB","VIDEO");
                    Insert.Parameters.AddWithValue("@FirstTarget", txtVideoTarget1st.Text);
                    Insert.Parameters.AddWithValue("@LastTarget", txtVideoTarget2nd.Text);
                    Insert.Parameters.AddWithValue("@Amount", txtVideoTargetAmount.Text);
                    Insert.Parameters.AddWithValue("@DateTime",DateTime.Now.ToString());
                    con.Open();
                    Insert.ExecuteNonQuery();
                    con.Close();
                    txtVideoTarget1st.Text = "";
                    txtVideoTarget2nd.Text = "";
                    txtVideoTargetAmount.Text = "";
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Sucessfully Insert.";
                    GridView1.DataBind();

                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Do Not Empty Video Payment Box's..";
                }
            }
            else
            {
                txtVideoTarget1st.Text = "";
                txtVideoTarget2nd.Text = "";
                txtVideoTargetAmount.Text = "";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "You Cannot Insert.. Because Video Infinity Number is Insert...";
            }
        }

        protected void btnBlog_Click(object sender, EventArgs e)
        {
            bool ON_OFF = true;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Auto_Payment_Settings where VoB='BLOG'";
            con.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                int count = Convert.ToInt32(data["LastTarget"]);
                if (count == -1)
                {
                    ON_OFF = false;
                    break;
                }
            }
            con.Close();

            if (ON_OFF == true)
            {
                if (txtBlogTarget1st.Text != "" && txtBlogTarget2nd.Text != "" && txtBlogTargetAmount.Text != "")
                {
                    SqlCommand Insert = new SqlCommand();
                    Insert.Connection = con;
                    Insert.CommandText = "insert into Auto_Payment_Settings (VoB,FirstTarget,LastTarget,Amount,DateTime) values(@VoB,@FirstTarget,@LastTarget,@Amount,@DateTime)";
                    Insert.Parameters.AddWithValue("@VoB", "BLOG");
                    Insert.Parameters.AddWithValue("@FirstTarget", txtBlogTarget1st.Text);
                    Insert.Parameters.AddWithValue("@LastTarget", txtBlogTarget2nd.Text);
                    Insert.Parameters.AddWithValue("@Amount", txtBlogTargetAmount.Text);
                    Insert.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                    con.Open();
                    Insert.ExecuteNonQuery();
                    con.Close();
                    txtBlogTarget1st.Text = "";
                    txtBlogTarget2nd.Text = "";
                    txtBlogTargetAmount.Text = "";
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Sucessfully Insert.";
                    GridView2.DataBind();
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Do Not Empty Blog Payment Box's..";
                }
            }
            else
            {
                txtBlogTarget1st.Text = "";
                txtBlogTarget2nd.Text = "";
                txtBlogTargetAmount.Text = "";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "You Cannot Insert.. Because Blog Infinity Number is Insert...";
            }
        }
    }
}