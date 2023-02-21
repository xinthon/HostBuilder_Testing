using HostBuilder_Testing.State.Navigators;
using HostBuilder_Testing.ViewModels;
using HostBuilder_Testing.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBuilder_Testing.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                /// home
                services.AddTransient<HomeViewModel>();
                /// manage user
                services.AddTransient<ManagerUserViewModel>();
                services.AddTransient<CreateUserViewModel>();
                /// setting
                services.AddTransient<SettingViewModel>();
                /// main 
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<CreateViewModel<ManagerUserViewModel>>(services => () => services.GetRequiredService<ManagerUserViewModel>());
                services.AddSingleton<CreateViewModel<CreateUserViewModel>>(services => () => services.GetRequiredService<CreateUserViewModel>());
                services.AddSingleton<CreateViewModel<SettingViewModel>>(services => () => services.GetRequiredService<SettingViewModel>());

                services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<CreateUserViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<ManagerUserViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<SettingViewModel>>();
            });

            return host;
        }
    }
}
