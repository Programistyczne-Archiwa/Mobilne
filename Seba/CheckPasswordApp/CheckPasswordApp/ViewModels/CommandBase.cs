using System;
using System.Windows.Input;

namespace CheckPasswordApp.ViewModels
{
    public abstract class CommandBase : ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;

        protected void OnCanExecutedCommand()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}