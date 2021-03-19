using System;
using System.Windows.Input;

namespace DesktopClient
{
    public class DelegateCommand<T> : ICommand
    {
        readonly Action<T> _targetExecuteAction;
        readonly Func<T, bool> _targetCanExecute;

        public DelegateCommand(Action<T> executeAction)
        {
            _targetExecuteAction = executeAction;
        }

        public DelegateCommand(Action<T> executeAction, Func<T, bool> canExecute)
        {
            _targetExecuteAction = executeAction;
            _targetCanExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecute != null)
            {
                T param = (T)parameter;
                return _targetCanExecute(param);
            }
            if (_targetExecuteAction != null)
            {
                return true;
            }
            return false;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            _targetExecuteAction?.Invoke((T)parameter);
        }
        #endregion
    }

    public class DelegateCommand : ICommand
    {
        readonly Action _targetExecuteAction;
        readonly Func<bool> _targetCanExecute;

        public DelegateCommand(Action executeAction)
        {
            _targetExecuteAction = executeAction;
        }

        public DelegateCommand(Action executeAction, Func<bool> canExecute)
        {
            _targetExecuteAction = executeAction;
            _targetCanExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecute != null)
            {
                return _targetCanExecute();
            }
            return _targetExecuteAction != null;
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            _targetExecuteAction?.Invoke();
        }
        #endregion
    }
}
