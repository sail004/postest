using System.Windows;
using DataAccess.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pos.BL.Implementation;


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
                        services.AddSingleton<MenuForm>();
                        services.AddSingleton<AuthForm>();
                        services.AddSingleton<SplashForm>();
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