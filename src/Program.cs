using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CBMscGAuth
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IBaseAsyncProducer, BaseAsyncProducer>();
                    services.AddHostedService<LoginService>();
                    services.AddHostedService<LogoutService>();
                    services.Configure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);
                });
            Console.WriteLine($"info: Service    : {Tools.GetAppSettingsValueString("ServiceConf", "Name")} v.{Tools.GetVersionString()}");
            Console.WriteLine($"info: Exchange   : {Tools.GetAppSettingsValueString("Rabbit", "Exchange")}");
            Console.WriteLine($"info: ---------------------------------------------");

            return host;
        }
    }
}