using HostBuilder_Testing.Commands;
using HostBuilder_Testing.Models;
using HostBuilder_Testing.Services;
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
    public class MainViewModel : ViewModelBase
    {

        /// <summary>
        /// Fields
        /// </summary>
        private readonly IUserService _userService;
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;


        /// <summary>
        /// Properties
        /// </summary>
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="navigator"></param>
        public MainViewModel(IUserService userService, IViewModelFactory viewModelFactory, INavigator navigator)
        {
            _userService = userService;
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            Task.Run(() =>
            {
                SingleUser = _userService.GetByUserId(new Guid("4bca57e3-b8b9-44f8-b201-29897a7bb85c")).Result;
                Users = new ObservableCollection<User>(_userService.Users().Result.ToList());
            });


            _navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }


        private string message { get; set; } = "This is message from view model";
        private User user { get; set; }
        private ObservableCollection<User> users { get; set; }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public User SingleUser
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged("SingleUser");
            }
        }

        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;

            base.Dispose();
        }
    }
}
 