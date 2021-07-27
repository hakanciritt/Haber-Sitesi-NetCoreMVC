using HaberSitesiASP.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;

namespace HaberSitesiASP.Helpers
{
    public class MailSender
    {

        public static async void SmtpMailSendAsync(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("email", "password");
                await client.SendAsync(message);
            }
        }
        public static MimeMessage Mail(Mail mail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Haberler", "email"));
            message.To.Add(new MailboxAddress(mail.UserName, mail.Email));
            message.Subject = mail.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<span>{mail.Message}</span>",
            };
            return message;
        }
    }
}
