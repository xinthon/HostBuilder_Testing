using HostBuilder_Testing.Commands;
using HostBuilder_Testing.Helpers;
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
        private readonly INavigator _navigator;
        private readonly IViewModelFactory _viewModelFactory;
       
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(IViewModelFactory viewModelFactory, INavigator navigator)
        {
            
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;

            _navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }

        private void Navigator_StateChanged(ViewModelBase view)
        {
            CurrentViewModel = view;
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;
            base.Dispose();
        }
    }
}
 