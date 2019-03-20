using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
namespace Bdbay
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = @"Slow website?Lots of things can affect your site's speed and performance: image size, page length, and text compression to name a few. Our website performance tool analyzes your site to give you deep insights into the factors contributing to its performance. This helps you understand the best steps to speed up your site.";
            Response.Write(s.Replace("'",""));
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString);
        protected void Button1_Click(object sender, EventArgs e)
        {
           



        }

        private string advertisement(int word,string input, string ADD)
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
                    input = input.Insert(index, "<br/>"+ ADD + "<br/>");                    
                    //work 
                    break;
                }
            }
            return input;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
                string _Body_Style = "Code is : 5655";
                MailMessage _msg = new MailMessage();
                _msg.From = new MailAddress("info@bdbay.net");
                _msg.To.Add("adorbangalee5@gmail.com");
                _msg.Subject = "chk";
                _msg.Body = _Body_Style;
                _msg.IsBodyHtml = true;
                SmtpClient _smtp = new SmtpClient();
                _smtp.Credentials = new System.Net.NetworkCredential("info@bdbay.net", "Pi@sh885989");
                _smtp.EnableSsl = false;
                _smtp.Send(_msg);
                _msg.Dispose();
                
            
        
        }
    }
}