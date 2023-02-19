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
                services.AddTransient<HomeViewModel>();
                services.AddTransient<SettingViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());

                services.AddSingleton<ISimpleTraderViewModelFactory, SimpleTraderViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<SettingViewModel>>();
            });

            return host;
        }
    }
}
