using HotelManagementSystem.Interfaces;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.Security;
using HotelManagementSystem.ViewModels;
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
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRoomRepository, RoomRepository>();
            services.AddSingleton<Hashing>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<HeaderViewModel>();
            services.AddSingleton<BaseViewModel>();
            services.AddSingleton<ReceptionistNavbarViewModel>();
            services.AddSingleton<AdminNavbarViewModel>();
            services.AddSingleton<RoomViewModel>();
        }
    }

}
