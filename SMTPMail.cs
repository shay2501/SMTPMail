using System;
using MailKit.Net.Smtp;
using MimeKit;

/*
 * Requires nuget packages:
 * Mailkit
 */

namespace Utility
{
    internal class SMTPMail
    {
        public static void SendMail(string body, string subject, string toname, string toaddress, string fromname, string fromaddress)
        {
            var message = new MimeMessage();

            message.To.Add(new MailboxAddress(toname, toaddress));
            message.From.Add(new MailboxAddress(fromname, fromaddress));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                //using the office 365 smtp server
                try
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    //office 365 smart mail relay
                    //client.Connect(server == null ? "jsheld-com.mail.protection.outlook.com" : server, 25, false);

                    client.Connect(AppSettings.serverName, AppSettings.serverPort, false);
                    client.Authenticate(AppSettings.username,
                        AppSettings.password); //credentials need to be same as from address when sending
                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}