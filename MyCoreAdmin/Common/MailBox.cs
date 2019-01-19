using System;

namespace Common
{
    public class MailBox
    {
        public void SendMail(string toEmail, string subject, string content)
        {
            var fromEmailAddress = "trungsendmailnek@gmail.com";
            var fromEmailDisplayName = "Trung Mailer";
            var fromEmailPassword = "trungbonmat";
            var smtpHost = "smtp.gmail.com";
            var smtpPort = "587";

            bool enabledSsl = true;

            string body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Assets/admin/pages/sendmailform/authenticationform.html"));
            StringBuilder sbBody = new StringBuilder(body);
            sbBody.Replace("@ViewBag.AutenticationCode", content);
            sbBody.Replace("@ViewBag.MonthYear", System.DateTime.Now.ToShortDateString());
            MailMessage message = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmail));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = sbBody.ToString();

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(message);
        }
    }
}
