using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesctopClient
{
    public class Command : ICommand     
    {
        private readonly Action _action;
        private Func<object, bool> _canExecute;

        public Command(Action action, Func<object, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public Command(Action action) : this(action, (x) => true){ }


        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }

    public class Command<T> : ICommand
    {
        private readonly Action<T> _action;
        private Func<T, bool> _canExecute;

        public Command(Action<T> action, Func<T, bool> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public Command(Action<T> action) : this(action, (x) => true) { }


        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    }
}
