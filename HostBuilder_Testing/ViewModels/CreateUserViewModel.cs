using HostBuilder_Testing.Commands;
using HostBuilder_Testing.Helpers;
using HostBuilder_Testing.Models;
using HostBuilder_Testing.Services.Interfaces;
using HostBuilder_Testing.State.Navigators;
using HostBuilder_Testing.ViewModels.Factories;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HostBuilder_Testing.ViewModels
{
    public class CreateUserViewModel : ViewModelBase
    {
        private readonly IUserService _userService;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;

        public ICommand UpdateCurrentViewModelCommand { get; }
        public ICommand SaveCommand { get; }

        public CreateUserViewModel(IUserService userService, INavigator navigator, IViewModelFactory viewModelFactory)
        {
            Title = "Create User";

            _userService = userService;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
            SaveCommand = new DelayCommand(SaveUser);
        }

        private User user { get; set; } = new() { UserId = Guid.NewGuid() };
        public User User
        {
            get { return user; }
            set { 
                user = value; 
                OnPropertyChanged("User");
            }
        }

        private void SaveUser(object? param)
        {
            try
            {
                if (user == null)
                {
                   throw new ArgumentNullException(nameof(user));
                }

                _userService.Create(User);

                UpdateCurrentViewModelCommand.Execute(ViewType.ManageUser);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
