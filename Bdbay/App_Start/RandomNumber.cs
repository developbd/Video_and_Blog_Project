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
using System.Text;

namespace Bdbay
{
    public class RandomNumber
    {
        private int CountData = 10;
        public int HowMuchNumber
        {
            get { return CountData; }
            set { CountData = value; }
        }
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private string _RandomString(string Details)
        {
            string input = "01234567890ABCDEFGIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < CountData; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            return check(builder.ToString(), Details);
        }
        private string check(string randomnumber, string Details)
        {
            check chk = new check();
            chk.ConfigarationName = "Settings";
            if (chk.int32Check("select count(*) from Random where RandomString='" + randomnumber + "'") == 0)
            {
                return InsertDatabase(randomnumber, Details);
            }
            else
            {
                return _RandomString(Details);
            }
        }
        private string InsertDatabase(string randomnumber, string Details)
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Settings"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Random (RandomString,Details) values(@RandomString,@Details)";
                cmd.Parameters.AddWithValue("@RandomString", randomnumber);
                cmd.Parameters.AddWithValue("@Details", Details);
                cmd.ExecuteNonQuery().ToString();
                cn.Close();
                return randomnumber;
            }
        }
        public string RandomStringNumber(string Details)
        {
            return _RandomString(Details);
        }
    
}
}