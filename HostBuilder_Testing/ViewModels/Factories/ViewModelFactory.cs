using HostBuilder_Testing.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostBuilder_Testing.Helpers;

namespace HostBuilder_Testing.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<ManagerUserViewModel> _createManagerUserViewModel;
        private readonly CreateViewModel<CreateUserViewModel> _createCreateUserViewModel;
        private readonly CreateViewModel<SettingViewModel> _createSettingViewModel;

        public ViewModelFactory(
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<ManagerUserViewModel> createManagerUserViewModel,
             CreateViewModel<CreateUserViewModel> createCreateUserViewModel,
            CreateViewModel<SettingViewModel> createSettingViewMode
            )
        {
            _createHomeViewModel = createHomeViewModel;
            _createManagerUserViewModel = createManagerUserViewModel;
            _createCreateUserViewModel = createCreateUserViewModel;
            _createSettingViewModel = createSettingViewMode;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();

                case ViewType.ManageUser:
                    return _createManagerUserViewModel();
                case ViewType.ManageUser_CreateUser:

                    return _createCreateUserViewModel();

                case ViewType.Setting:
                    return _createSettingViewModel();

                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
