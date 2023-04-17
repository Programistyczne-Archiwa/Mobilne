namespace CheckPasswordApp.ViewModels
{
    public class PassCheckViewModel : ViewModelBase
    {
        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}