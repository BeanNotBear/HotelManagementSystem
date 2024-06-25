using HotelManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded { get; set; }
        public ICommand LoadedWindowCommand { get; }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>(p => { return true; }, p => { LoadWindow(p); });
        }

        private void LoadWindow(Window p)
        {
            IsLoaded = true;
            if (p == null)
                return;
            p.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            if (loginWindow.DataContext == null)
                return;
            var loginVM = loginWindow.DataContext as LoginViewModel;

            if (loginVM.IsLoginSuccessful)
            {
                p.Show();
            }
            else
            {
                p.Close();
            }
        }
    }
}
