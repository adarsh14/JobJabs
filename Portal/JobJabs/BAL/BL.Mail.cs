using JobJabs.BAL;
using JobJabs.DAL;
using JobJabs.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Net.Mail;


namespace JobJabs.BAL
{
    public class BL_Mail
    {
        public static bool Send_Mail(MailMessage mailMessage)
        {
            //var message = new MimeMessage();
            //message.From.Add(new MailboxAddress(mailMessage.From.DisplayName, mailMessage.From.Address));
            //message.To.Add(new MailboxAddress(mailMessage.To.ToString()));
            //message.Subject = mailMessage.Subject;
            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = mailMessage.Body;
            //message.Body = bodyBuilder.ToMessageBody();

            //using (var client = new MailKit.Net.Smtp.SmtpClient())
            //{
            //    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //    client.Connect("mail.JobJabs.com", 587, false);
            //    //client.Authenticate("ashwith@JobJabs.com", "jobjabs123");
            //    client.Send(message);
            //    client.Disconnect(true);
            //}
            SmtpClient client = new SmtpClient();
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High; // enumeration
            client.Send(mailMessage);
            return true;
        }
    }
}
  
