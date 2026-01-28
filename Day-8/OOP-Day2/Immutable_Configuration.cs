using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Day2
{
    public class AppConfig
    {
        public string AppName { get; }
        public string Version { get; }
        public string CreatedDate { get; }
        public AppConfig(string AppName, string Version, string CreatedDate) {
            this.AppName = AppName;
            this.Version = Version;
            this.CreatedDate = CreatedDate;
        }
        public void DisplayAppInfo()
        {
            Console.WriteLine($"App Name: {AppName}");
            Console.WriteLine($"Version: {Version}");
            Console.WriteLine($"Created Date: {CreatedDate}");
        }
    }
    internal class Immutable_Configuration
    {
        public static void Main()
        {
            AppConfig app1 = new AppConfig("App1", "1.0.12", "30-09-2025");
            app1.DisplayAppInfo();
            //app1.AppName = "New App"; //Does not allowed to change the value as field behave like it is read-only
        }
    }
}
