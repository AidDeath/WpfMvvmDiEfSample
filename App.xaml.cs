using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfMvvmDiEfSample.Data;
using WpfMvvmDiEfSample.Services;
using WpfMvvmDiEfSample.ViewModels;

namespace WpfMvvmDiEfSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //Here we add services
            services.AddTransient<IRandomStringService, RandomStringService>();
            services.AddTransient<BandService>();

            services.AddDbContext<SampleContext>();

            //ViewModels
            //services.AddTransient<MainWindowViewModel>();


            return services.BuildServiceProvider();
        }
    }
}
