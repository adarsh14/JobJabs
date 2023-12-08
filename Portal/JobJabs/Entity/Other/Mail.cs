using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;




namespace JobJabs.Entity
{
    public class MailMsg
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Subject { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Body { get; set; }
    }

    public class JBMailMessage
    {
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string EmailToCC { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int MailId { get; set; }
        public Dictionary<string, byte[]> EmailAttachments { get; set; }
        public List<string> fileNames = new List<string>();
        public string ReferenceId { get; set; }
        public string LastName { get; set; }
        public string Zipcode { get; set; }
    }

    public class MailXML
    {
        public string MailId { get; set; }
        public string MailType { get; set; }
        public int DaysLeft { get; set; }
        public int RecipientType { get; set; } //if 1 then Mail will go to all Director+Manger+Adjuster, 2 then Manger+Adjuster, 3 then only Adjuster.
        public string Subject { get; set; }
        public string Body { get; set; }
        public string IsHtml { get; set; }
        public string Desc { get; set; }
    }

}
