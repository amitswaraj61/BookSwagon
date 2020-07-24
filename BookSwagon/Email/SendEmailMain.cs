using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookSwagon.Email
{
    class SendEmailMain
    {
      public static Credentials credentials = new Credentials();
        public static void SendEmail(String Subject, String contentBody)
        {
            MailMessage mail = new MailMessage();
            String fromEmail = credentials.email;
            String password = credentials.sendPassword;
            String ToEmail = credentials.recEmail;
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(ToEmail);
            mail.Subject = Subject.Replace('\r', ' ').Replace('\n', ' ');
            mail.Body = contentBody;
            mail.Priority = MailPriority.High;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(@"C:\Users\Kis\source\repos\BookSwagon\BookSwagon\Report\index.html"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmail, password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
