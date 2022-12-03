
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
                    services.AddTransient<IPosEngine, PosEngine>();
                    services.AddSingleton<IStateManager, StateManager>();
                    services.AddSingleton<IInputManager, InputManager>();
                }
            ).UseConsoleLifetime();

var host = builder.Build();

using var serviceScope = host.Services.CreateScope();
{
    var services = serviceScope.ServiceProvider;
    Console.WriteLine("Staring postest v1.0");

    var stateManager = services.GetRequiredService<IStateManager>();
    var inputManager = services.GetRequiredService<IInputManager>();
    stateManager.NotifyAction = (message) => { Console.WriteLine($"{message}"); };

    inputManager.InputData = () => { return Console.ReadKey().KeyChar; };

    var posEngine = services.GetRequiredService<IPosEngine>();
    posEngine.Run();
}

return 0;
