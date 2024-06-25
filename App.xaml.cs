using HotelManagementSystem.Interfaces;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.Security;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace HotelManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<Hashing>();
            base.OnStartup(e);
        }
    }

}
