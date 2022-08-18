using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WpfMvvmDiEfSample.Data;
using WpfMvvmDiEfSample.Models;
using WpfMvvmDiEfSample.Services;
using WpfMvvmDiEfSample.Views;

namespace WpfMvvmDiEfSample
{
    /// <summary>
    /// Configured DI with IHost. HostedServices - works.
    /// In app.xaml we have : Startup="OnStartup"
    /// </summary>
    public partial class App : Application
    {
        public readonly IHost AppHost;
        public new static App Current => (App)Application.Current;

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
           .ConfigureServices(ConfigureServices)
           .Build();

        }

        //Configuring services with IHost 
        private static void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<MainWindow>();

            //Here we add services
            services.AddTransient<IRandomStringService, RandomStringService>();
            services.AddTransient<BandService>();

            //Here we add database context
            services.AddDbContext<SampleContext>();

            //Add hosted setvice and variable provider
            services.AddSingleton<BackgroundValuesProvider>();
            services.AddHostedService<BackgroundHostedService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            AppHost.Start();
            var mainWindow = AppHost.Services.GetService<MainWindow>();
            mainWindow?.Show();
        }

    }


    /// <summary>
    /// Configured DI without IHost. HostedServices - NOT works, other services - works.
    /// In app.xaml we have : StartupUri="Views/MainWindow.xaml"
    /// </summary>
    //public partial class App : Application
    //{
    //    public new static App Current => (App)Application.Current;
    //    public IServiceProvider Services { get; }

    //    public App()
    //    {
    //        Services = ConfigureServices();
    //        this.InitializeComponent();
    //    }


    //    private static IServiceProvider ConfigureServices()
    //    {
    //        var services = new ServiceCollection();

    //        //Here we add services
    //        services.AddTransient<IRandomStringService, RandomStringService>();
    //        services.AddTransient<BandService>();

    //        //Here we add database context
    //        services.AddDbContext<SampleContext>();

    //        return services.BuildServiceProvider();
    //    }
    //}

}
