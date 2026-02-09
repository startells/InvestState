using InvestInfo.Interface;
using InvestInfo.Services;
using InvestInfo.ViewModels;
using InvestInfo.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace InvestInfo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            Services = ConfigureServices();
            this.InitializeComponent();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<InvestDbContext>(options =>
                options.UseSqlite("Data Source=invest.db"),
                ServiceLifetime.Transient);

            // Services
            services.AddSingleton<IOperationService, OperationService>();

            // ViewModels
            services.AddTransient<OperationsViewModel>();

            // Views
            services.AddTransient<MainWindow>();
            services.AddTransient<OperationsView>();
            services.AddTransient<HomeView>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        public IServiceProvider Services { get; }
        public new static App Current => (App)Application.Current;
    }
}
