using System.Windows.Input;

namespace CheckPasswordApp.ViewModels
{
    public class PassCheckViewModel : ViewModelBase
    {
        private string _complexPassword;
        private string _password;

        public PassCheckViewModel()
        {
            ResetCommand = new ResetPassword(this);
            CheckCommand = new CheckPassword(this);
            Password = "";
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

        public string ComplexPassword
        {
            get => _complexPassword;
            set
            {
                _complexPassword = value;
                OnPropertyChanged(nameof(ComplexPassword));
            }
        }

        public ICommand CheckCommand { get; }
        public ICommand ResetCommand { get; }
    }

    public class CheckPassword : CommandBase
    {
        private readonly PassCheckViewModel _passCheckViewModel;

        public CheckPassword(PassCheckViewModel passCheckViewModel)
        {
            _passCheckViewModel = passCheckViewModel;
        }

        private bool CheckNumberContains(string text)
        {
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (var i = 0; i < nums.Length; i++)
                if (text.Contains(nums[i].ToString()))
                    return true;

            return false;
        }

        public override void Execute(object parameter)
        {
            _passCheckViewModel.ComplexPassword = "Hasło jest puste";
            if (CheckNumberContains(_passCheckViewModel.Password))
            {
                if (_passCheckViewModel.Password.Length >= 7)
                    _passCheckViewModel.ComplexPassword = "Hasło jest dobre";
                else if (_passCheckViewModel.Password.Length <= 6 && _passCheckViewModel.Password.Length >= 4)
                    _passCheckViewModel.ComplexPassword = "Hasło jest średnie";
            }

            if (_passCheckViewModel.Password != "") _passCheckViewModel.ComplexPassword = "Hasło jest słabe";
        }
    }

    public class ResetPassword : CommandBase
    {
        private readonly PassCheckViewModel _passCheckViewModel;

        public ResetPassword(PassCheckViewModel passCheckViewModel)
        {
            _passCheckViewModel = passCheckViewModel;
        }

        public override void Execute(object parameter)
        {
            _passCheckViewModel.Password = "";
        }
    }
}