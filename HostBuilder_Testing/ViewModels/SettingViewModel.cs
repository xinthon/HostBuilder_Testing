using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBuilder_Testing.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {

        public SettingViewModel()
        {
            Task.Run(() =>
            {
                this.Title = "Setting";
            });

        }
    }
}
