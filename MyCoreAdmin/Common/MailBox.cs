using System;
using System.Net;
using System.Net.Mail;

namespace Common
{
    public class MailBox
    {
        public void SendMail(string toEmail, string subject,string body)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("trungsendmailnek@gmail.com", "trungbonmat");
            client.Port = 587;
            client.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("trungsendmailnek@gmail.com");
            mailMessage.To.Add(toEmail);
            mailMessage.Body =body;
            mailMessage.Subject = subject;
            client.Send(mailMessage);
        }
    }
}
