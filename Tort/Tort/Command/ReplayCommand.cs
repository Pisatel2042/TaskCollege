using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tort.Command
{
    internal class ReplayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> _Execute { get; set; }
        private Predicate<object> _CanExecute { get; set; }


        public ReplayCommand(Action<object> Execute, Predicate<object> CanExecute)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}