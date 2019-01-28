using System;
using System.Diagnostics;
using System.IO;
using Utility;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filepath = Directory.GetCurrentDirectory();
            var file = Path.Combine(filepath, "oauthconfig.json");
            AppSettings.ReadConfigurationSettings(file);

            var name = "Shannon Whalen";
            var email = "swhalen@jsheld.com";
            var body = "Email Body";
            var subject = "Email Subject";

            SMTPMail.SendMail(body, subject, name, email, name, email);

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Please type any key:");
                Console.Read();
            }
        }
    }
}