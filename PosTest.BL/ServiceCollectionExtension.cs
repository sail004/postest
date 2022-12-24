using Microsoft.Extensions.DependencyInjection;
using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterBL(this IServiceCollection services)
    {
        services.AddSingleton<IPosState, MenuState>();
        services.AddSingleton<IPosState, AuthState>();
        services.AddSingleton<IPosState, OneTimeAuthState>();
        services.AddSingleton<IPosState, ExitState>();
        services.AddSingleton<IPosState, InitState>();
        services.AddSingleton<IPosState, ReportState>();

        services.AddSingleton<PosStateResolver>();
        services.AddTransient<IPosEngine, PosEngine>();
        services.AddSingleton<IStateManager, StateManager>();
        services.AddSingleton<IInputManager, InputManager>();
        services.AddSingleton<IOutputManager, OutputManager>();
        
        services.AddSingleton<IAuthenticationContext, AuthenticationContext>();
        return services;
    }
}