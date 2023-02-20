using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBuilder_Testing.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        private string title { get; set; } = string.Empty;
        public string Title
        {
            get=> title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public SettingViewModel()
        {
            this.Title = "Home";
        }
    }
}
