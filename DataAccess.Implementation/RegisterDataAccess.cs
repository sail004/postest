using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Pos.BL.Implementation;
using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.Receipt;

namespace DataAccess.Implementation;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterDataAccess(this IServiceCollection services)
    {
        services.AddTransient<ISerializer<MenuModel>, JsonSerializerService<MenuModel>>();
        services.AddTransient<ISerializer<List<ReceiptSpecRecord>>, JsonSerializerService<List<ReceiptSpecRecord>>>();


        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IUserRightRepository, UserRightRepository>();
    
        return services;
    }
}