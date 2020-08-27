//-----------------------------------------------------------------------
// <copyright file="SendEmailMain.cs" company="BridgeLabz">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Mail;

namespace BookSwagon.Email
{
    /// <summary>
    /// create Send Email main class
    /// </summary>
    class SendEmailMain
    {
        /// <summary>
        /// create object of Credentials class
        /// </summary>
       public static Credentials credentials = new Credentials();

        /// <summary>
        /// create Send Email method
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="contentBody"></param>
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
