namespace BlogSystem.Data.Services.Implementation
{
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using System.Web.Configuration;
    using Contracts;
    using Microsoft.AspNet.Identity;

    public class EmailService : ISendProvider
    {
        private static readonly string GmailPassword = WebConfigurationManager.AppSettings["GmailPasswordKey"];
        private static readonly string GmailUserName = WebConfigurationManager.AppSettings["GmailUserNameKey"];
        private static readonly string GmailHost = WebConfigurationManager.AppSettings["GmailHostKey"];
        private static readonly int GmailPort = int.Parse(WebConfigurationManager.AppSettings["GmailPortKey"]);
        private static readonly bool IsGmailSsh = bool.Parse(WebConfigurationManager.AppSettings["GmailSslKey"]);

        public async Task SendAsync(IdentityMessage message)
        {
            var smtp = new SmtpClient
            {
                Host = GmailHost,
                Port = GmailPort,
                EnableSsl = IsGmailSsh,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(GmailUserName, GmailPassword)
            };

            using (var messageToSend = new MailMessage(GmailUserName, message.Destination))
            {
                messageToSend.Subject = message.Subject;
                messageToSend.Body = message.Body;
                messageToSend.IsBodyHtml = true;

                await smtp.SendMailAsync(messageToSend);
            }
        }
    }
}
