using DataAcces.Implementation;
using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pos.BL.Implementation;
using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;

var builder = new HostBuilder()
    .ConfigureServices(
        (
            hostContext,
            services
        ) =>
        {
            services.AddSingleton<IPosState, MenuState>();
            services.AddSingleton<IPosState, AuthState>();
            services.AddSingleton<IPosState, ExitState>();
            services.AddSingleton<IPosState, InitState>();
            services.AddSingleton<IPosState, ReportState>();


            services.AddSingleton<PosStateResolver>();
            services.AddTransient<IPosEngine, PosEngine>();
            services.AddSingleton<IStateManager, StateManager>();
            services.AddSingleton<IInputManager, InputManager>();
            services.AddSingleton<IOutputManager, OutputManager>();

            services.AddSingleton<IAuthenticationContext, AuthenticationContext>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserRightRepository, UserRightRepository>();
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
        Console.Write($"{message}");
    };

    inputManager.InputData = () => { return Console.ReadKey(); };

    var posEngine = services.GetRequiredService<IPosEngine>();
    posEngine.Run();
}

return 0;