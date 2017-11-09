namespace BlogSystem.Data.Services.Implementation
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using System.Web.Configuration;
    using Microsoft.AspNet.Identity;

    public static class EmailService
    {
        private static readonly string GmailPassword = WebConfigurationManager.AppSettings["GmailPasswordKey"];
        private static readonly string GmailUserName = WebConfigurationManager.AppSettings["GmailUserNameKey"];
        private static readonly string GmailHost = WebConfigurationManager.AppSettings["GmailHostKey"];
        private static readonly int GmailPort = int.Parse(WebConfigurationManager.AppSettings["GmailPortKey"]);
        private static readonly bool IsGmailSsl = bool.Parse(WebConfigurationManager.AppSettings["GmailSslKey"]);

        public static async Task SendEmail(IdentityMessage message)
        {
            var smtp = new SmtpClient
            {
                Host = GmailHost,
                Port = GmailPort,
                EnableSsl = IsGmailSsl,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(GmailUserName, GmailPassword)
            };

            var messageToSend = new MailMessage(GmailUserName, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };

             await smtp.SendMailAsync(messageToSend);
        }
    }
}
