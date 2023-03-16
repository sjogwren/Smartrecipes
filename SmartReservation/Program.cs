using DbUp;
using DbUp.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace SmartReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString =
args.FirstOrDefault()
?? "Server=DESKTOP-EERLAR5\\SQLEXPRESS;Database=dbRecipe;User Id=zain;Password=Djdjegdo786;";
            EnsureDatabase.For.SqlDatabase(connectionString);
            var upgrader =
                    DeployChanges.To
                                 .SqlDatabase(connectionString)
                                 .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly(),
                                                                       f => !f.Contains(".AlwaysRun."))
                                 .LogToConsole()
                                 .LogScriptOutput()
                                 .WithTransaction()
                                 .Build();
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("21122173@dut4life.ac.za"),
                    Subject = "Application.WebApi DB update failed",
                    Body = $"Error Message:  {result.Error.Message}",
                    IsBodyHtml = true
                };
                mailMessage.To.Add("zainolnabi88@gmail.com");
                SmtpClient smtp = new SmtpClient()
                {
                    Host = "pod51014.outlook.com",
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("21122173@dut4life.ac.za", "Dut920924"),
                    EnableSsl = true
                };
                smtp.Send(mailMessage);
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
