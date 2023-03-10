using HostBuilder_Testing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBuilder_Testing.State.Navigators
{


    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action<ViewModelBase> StateChanged;
    }
}
