using DataAccess.Implementation;
using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Pos.BL.Implementation;
using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;

namespace DataAccess.Implementation;

public static class RegisterDataAcces
{
    public static IServiceCollection RegisterationDataAcces(this IServiceCollection services)
    {
        services.AddTransient<ISerializer<MenuModel>, JsonSerializerService<MenuModel>>();
            
            
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserRightRepository, UserRightRepository>();
    
        return services;
    }
}