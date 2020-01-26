using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ADMPro
{
    public class EmailLogic
    {
        public void SendEmail(string Subject, string Body, string ToEmailID, string CCEmailIDs)
        {
            // Send to Client
            AlternateView avClient = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");

            MailMessage mailMessageC = new MailMessage();
            mailMessageC.From = new MailAddress("noreplay@riya.travel", "Riya The Travel Expert!");
            mailMessageC.To.Add(ToEmailID);
            mailMessageC.CC.Add(CCEmailIDs);

            mailMessageC.Subject = Subject;
            mailMessageC.IsBodyHtml = true;
            mailMessageC.Body = Body;
            mailMessageC.AlternateViews.Add(avClient);
            SmtpClient smtpC = new SmtpClient();
            smtpC.Credentials = new System.Net.NetworkCredential("ca.maildirect@ca.riya.travel.com", "R!ya@7398");
            smtpC.Port = 2700;
            smtpC.Host = "ac.maildirect.co.in";
            smtpC.Send(mailMessageC);
        }
    }
}