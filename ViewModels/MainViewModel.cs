using HotelManagementSystem.Data;
using HotelManagementSystem.Dto;
using HotelManagementSystem.Interfaces;
using HotelManagementSystem.Repositories;
using HotelManagementSystem.UserControls;
using HotelManagementSystem.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
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
        public ICommand ToggleNavbarCommand { get; }
        public ICommand HeaderCommand { get; }
        public HeaderViewModel HeaderViewModel { get; }
        private IRoomRepository _roomRepository;
        private HotelManagementDbContext _context;

        private string _title = "Dashboard";
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private BaseViewModel _currentNavbarViewModel;

        public BaseViewModel CurrentNavbarViewModel
        {
            get => _currentNavbarViewModel;
            set
            {
                _currentNavbarViewModel = value;
                OnPropertyChanged(nameof(CurrentNavbarViewModel));
            }
        }

        private bool _isNavbarVisible;
        public bool IsNavbarVisible
        {
            get => _isNavbarVisible;
            set
            {
                _isNavbarVisible = value;
                OnPropertyChanged(nameof(IsNavbarVisible));
            }
        }

        private List<RoomListDTO> _rooms;
        public List<RoomListDTO> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged(nameof(Rooms));
            }
        }

        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>(p => { return true; }, p => { LoadWindow(p); });
            ToggleNavbarCommand = new RelayCommand<Window>(p => { return true; }, p => { ToggleNavbar(p); });
            HeaderCommand = new RelayCommand<string>(p => { return true; }, p => { LoadTextHeader(p); });
            _context = new HotelManagementDbContext();
            _roomRepository = new RoomRepository(_context);
        }

        private void LoadWindow(Window p)
        {
            IsLoaded = true;
            if (p == null)
                return;
            p.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            HeaderUC headerUC = new HeaderUC();

            if (loginWindow.DataContext == null)
                return;
            var loginVM = loginWindow.DataContext as LoginViewModel;
            var headerVM = headerUC.DataContext as HeaderViewModel;

            if (loginVM.IsLoginSuccessful)
            {
                var user = loginVM.authenticatedUser;
                if (user.RoleId == 1)
                {
                    CurrentNavbarViewModel = new AdminNavbarViewModel();
                }
                else if (user.RoleId == 2)
                {
                    CurrentNavbarViewModel = new ReceptionistNavbarViewModel();
                }
                p.Show();
            }
            else
            {
                p.Close();
            }
        }

        private void ToggleNavbar(Window p)
        {
            IsNavbarVisible = !IsNavbarVisible;
            LoginWindow loginWindow = new LoginWindow();
            var loginVM = loginWindow.DataContext as LoginViewModel;
            if (!IsNavbarVisible)
            {
                var user = loginVM.authenticatedUser;
                if (user.RoleId == 1)
                {
                    CurrentNavbarViewModel = new AdminNavbarViewModel();
                }
                else if (user.RoleId == 2)
                {
                    CurrentNavbarViewModel = new ReceptionistNavbarViewModel();
                }
            }
            else
            {
                if (Title.Equals("Manage Room"))
                {
                    CurrentNavbarViewModel = new RoomFilterViewModel();
                }
                
            }
        }

        private void LoadTextHeader(string p)
        {
            if (p == null)
            {
                return;
            }
            Title = p;
            if (p.Equals("Manage Room"))
            {
                Rooms = _roomRepository.GetAll();
            }
        }
    }
}
