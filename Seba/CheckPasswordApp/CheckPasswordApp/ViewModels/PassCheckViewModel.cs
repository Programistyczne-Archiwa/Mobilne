using System.Diagnostics;
using System.Windows.Input;

namespace CheckPasswordApp.ViewModels
{
    public class PassCheckViewModel : ViewModelBase
    {
        private string _password;

        public PassCheckViewModel()
        {
            CheckCommand = new CheckPasswordCommand();
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand CheckCommand { get; }
    }

    public class CheckPasswordCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            Trace.WriteLine("Clicked");
        }
    }
}