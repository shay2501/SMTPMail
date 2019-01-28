using System.IO;
using Microsoft.Extensions.Configuration;

/*
 * Requires nuget packages:
 * Microsoft.Extenstions.Configuration.Binder
 * Microsoft.Extenstions.Configuration.FileExtensions
 * Microsoft.Extenstions.Configuration.Json
 */

namespace Utility
{
    public static class AppSettings
    {
        //Configuration File Settings
        // =========================================================================================================
        public static string serverName;

        public static int serverPort;

        public static string username;

        public static string password;

        //Methods
        // =========================================================================================================
        public static void ReadConfigurationSettings(string filename)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(filename);

            var config = builder.Build();

            serverName = config.GetSection("smtpServer").Get<string>();
            serverPort = config.GetSection("smtpPort").Get<int>();
            username = config.GetSection("username").Get<string>();
            password = config.GetSection("password").Get<string>();
        }
    }
}