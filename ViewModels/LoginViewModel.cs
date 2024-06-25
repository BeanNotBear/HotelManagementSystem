using HotelManagementSystem.Data;
using HotelManagementSystem.Interfaces;
using HotelManagementSystem.Models;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagementSystem.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private IUserRepository _userRepository;
        private HotelManagementDbContext _context;
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoginSuccessful;
        public bool IsLoginSuccessful
        {
            get { return _isLoginSuccessful; }
            set
            {
                _isLoginSuccessful = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _context = new HotelManagementDbContext();
            _userRepository = new UserRepository(_context);
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { OnLogIn(p); });
        }

        private async void OnLogIn(Window p)
        {
            if (p == null)
            {
                return;
            }

            try
            {
                var user = await _userRepository.findUserByEmailAndPassword(_email, _password);
                if (user != null)
                {
                    IsLoginSuccessful = true;
                    p.Close();
                }
                else
                {
                    throw new Exception("Error at login");
                }
            }
            catch (Exception ex)
            {
                IsLoginSuccessful = false;
                MessageBox.Show("Email or password is not correct!", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
