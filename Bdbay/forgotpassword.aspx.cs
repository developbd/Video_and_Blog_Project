﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace Bdbay
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool _Mail(string Email, string Messege)
        {
            try
            {

                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.Port = 80;
                client.Host = txtSecureServer.Text;
                client.Timeout = 1000000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;

                client.Credentials = new System.Net.NetworkCredential("support@moniritvillage.com", "Monir@1981");
                objeto_mail.From = new MailAddress("support@moniritvillage.com");
                objeto_mail.To.Add(new MailAddress(Email));
                objeto_mail.Subject = "BDBAY ONLINE";
                objeto_mail.Body = Messege;
                client.Send(objeto_mail);

                //string _Body_Style = @"Password: " + Code;
                //MailMessage _msg = new MailMessage();
                //_msg.From = new MailAddress("support@bdhomeland.com");
                //_msg.To.Add(Email);
                //_msg.Subject = "Forgot Password";
                //_msg.Body = _Body_Style;
                //_msg.IsBodyHtml = true;
                //SmtpClient _smtp = new SmtpClient();
                //_smtp.Credentials = new System.Net.NetworkCredential("support@bdhomeland.com", "Monir@1981");
                //_smtp.EnableSsl = false;
                //_smtp.Send(_msg);
                //_msg.Dispose();
                return true;
            }
            catch (Exception)
            { return false; }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            check chk = new check();
            chk.ConfigarationName = "Settings";
            string Email = txtEmail.Text;
            if(chk.int32Check("select count(*) from Registation_Tbl where Email='"+Email+"' ")==1)
            {
                string Password = chk.stringCheck("select Password from Registation_Tbl where Email='" + Email + "' ");
                if (_Mail(Email, "Password: " + Password))
                {
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "Your Password is Send Your Email.";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Server Error Try Again/ Contact Us.";
                }
            }
            else
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Email Not Found.";
            }
        }

    }
}