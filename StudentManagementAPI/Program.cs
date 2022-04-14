using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //Host.CreateDefaultBuilder(args)
        //.ConfigureWebHostDefaults(webBuilder =>
        //webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
        //{
        //    config.AddAzureKeyVault("https://ysustudents.vault.azure.net/", "https://ysustudents.vault.azure.net/keys/KeyVaultCertificate/65472a9add304413975db4c6e1c4bb54", "https://ysustudents.vault.azure.net/secrets/KeyVaultCertificate/65472a9add304413975db4c6e1c4bb54");
        //})
        //.UseStartup<Startup>());

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });


    }
}
