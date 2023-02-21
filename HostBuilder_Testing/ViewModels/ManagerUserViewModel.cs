using HostBuilder_Testing.Commands;
using HostBuilder_Testing.Helpers;
using HostBuilder_Testing.Models;
using HostBuilder_Testing.Services.Interfaces;
using HostBuilder_Testing.State.Navigators;
using HostBuilder_Testing.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HostBuilder_Testing.ViewModels
{
    public class ManagerUserViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public ManagerUserViewModel(IUserService userService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            Title = "Manage User";

            _userService = userService;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            InitailizeData();
        }


        private ObservableCollection<User> users { get; set; }
        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        private void InitailizeData()
        {
            Task.Run(() =>
            {
                try
                {
                    Users = new ObservableCollection<User>(_userService.Users().Result.ToList());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
