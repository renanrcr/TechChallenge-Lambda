using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TechChallenge.Api.Configuration;

namespace TechChallenge.Api;

/// <summary>
/// The Main function can be used to run the ASP.NET Core application locally using the Kestrel webserver.
/// https://aws.amazon.com/pt/blogs/modernizing-with-aws/how-to-load-net-configuration-from-aws-secrets-manager/
/// </summary>
public class LocalEntryPoint
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((_, configurationBuilder) =>
                {
                    configurationBuilder.AddAmazonSecretsManager("us-east-1", "dev-techchallenge-terraform-terraform");
                });

                webBuilder.UseStartup<Startup>();
            });
}