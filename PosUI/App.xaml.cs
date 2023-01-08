using System.Windows;
using DataAccess.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pos.BL.Implementation;
using PosUI.Interfaces;

namespace PosUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = new HostBuilder()
                .ConfigureServices(
                    (
                        hostContext,
                        services
                    ) =>
                    {
                        services.RegisterBL();
                        services.RegisterDataAccess();
                        services.AddSingleton<ISetViewModel, MenuForm>();
                        services.AddSingleton<ISetViewModel, AuthForm>();
                        services.AddSingleton<ISetViewModel, SplashForm>();
                        services.AddSingleton<ISetViewModel, OneTimeAuthForm>();
                        services.AddSingleton<UIManager>();
                    }
                ).Build();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var uIManager = host.Services.GetService<UIManager>();
            uIManager?.Run();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}