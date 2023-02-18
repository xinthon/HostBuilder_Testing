using HostBuilder_Testing.Models;
using HostBuilder_Testing.Services;
using HostBuilder_Testing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBuilder_Testing.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public MainViewModel(IUserService userService)
        {
            _userService = userService;

            Task.Run(() =>
            {
                SingleUser = _userService.GetByUserId(new Guid("4bca57e3-b8b9-44f8-b201-29897a7bb85c")).Result;
                Users = new ObservableCollection<User>(_userService.Users().Result.ToList());
            });
        }

        private string message { get; set; } = string.Empty;
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
    }
}
