﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HostBuilder_Testing.Commands
{
    public class DelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object> _action;

        public DelayCommand(Action<object> action)
        {
            _action = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}
