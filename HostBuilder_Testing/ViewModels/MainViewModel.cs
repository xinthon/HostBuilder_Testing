using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostBuilder_Testing.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string message { get; set; } = string.Empty;

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public MainViewModel()
        {

        }
    }
}
