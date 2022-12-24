using DataAccess.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pos.BL.Implementation;
using Pos.BL.Interfaces;

var builder = new HostBuilder()
    .ConfigureServices(
        (
            hostContext,
            services
        ) =>
        {
            services.RegisterBL();
            services.RegisterDataAccess();
        }
    ).UseConsoleLifetime();

var host = builder.Build();

using var serviceScope = host.Services.CreateScope();
{
    var services = serviceScope.ServiceProvider;
    Console.WriteLine("Staring postest v1.0");

    var outputManager = services.GetRequiredService<IOutputManager>();
    var inputManager = services.GetRequiredService<IInputManager>();


    outputManager.NotifyAction = message =>
    {
        Console.Clear();
        Console.Write($" Active state:{message.PosStateEnum}, Data:{message.JsonData}");
    };

    inputManager.InputData = () => { return Console.ReadKey(); };

    var posEngine = services.GetRequiredService<IPosEngine>();
    posEngine.Run();
}

return 0;