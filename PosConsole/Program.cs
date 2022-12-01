
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = new HostBuilder()
            .ConfigureServices(
                (
                    hostContext,
                    services
                ) =>
                {
                  //  services.AddHttpClient();
                  
                }
            ).UseConsoleLifetime();
        var host = builder.Build();

        using var serviceScope = host.Services.CreateScope();
        {
            var services = serviceScope.ServiceProvider;
            Console.WriteLine("staring postest v1.0");
        }

        return 0;
    