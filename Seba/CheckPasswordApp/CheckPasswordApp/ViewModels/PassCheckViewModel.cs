using System;
using System.Windows.Input;

namespace CheckPasswordApp.ViewModels
{
    public class PassCheckViewModel : ViewModelBase
    {
        private string _complexPassword;
        private string _genPass;
        private string _password;

        public PassCheckViewModel()
        {
            ResetCommand = new ResetPassword(this);
            CheckCommand = new CheckPassword(this);
            GenPassCommand = new GenPass(this);
            Password = "";
            GenPass = "";
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

        public string GenPass
        {
            get => _genPass;
            set
            {
                _genPass = value;
                OnPropertyChanged(nameof(GenPass));
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
        public ICommand GenPassCommand { get; }
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
            _passCheckViewModel.ComplexPassword = "Hasło jest słabe";

            if (_passCheckViewModel.Password == "")
            {
                _passCheckViewModel.ComplexPassword = "Hasło jest puste";
                return;
            }

            if (CheckNumberContains(_passCheckViewModel.Password))
            {
                if (_passCheckViewModel.Password.Length >= 7)
                    _passCheckViewModel.ComplexPassword = "Hasło jest dobre";
                else if (_passCheckViewModel.Password.Length <= 6 && _passCheckViewModel.Password.Length >= 4)
                    _passCheckViewModel.ComplexPassword = "Hasło jest średnie";
            }
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

    public class GenPass : CommandBase
    {
        private readonly PassCheckViewModel _passCheckViewModel;
        private readonly Random _random;

        public GenPass(PassCheckViewModel passCheckViewModel)
        {
            _passCheckViewModel = passCheckViewModel;
            _random = new Random();
        }

        private string[] addCharsToPass(string[] genPass, string chars)
        {
            var ranNum = 0;
            for (var i = 0; i < 3; i++)
            {
                ranNum = _random.Next(12);
                if (genPass[ranNum] is null)
                    genPass[ranNum] = chars[_random.Next(chars.Length)].ToString();
                else
                    i--;
            }

            return genPass;
        }

        public override void Execute(object parameter)
        {
            var nums = "1234567890";
            var letters = "abcdefghijklmnoprstuwxyz";
            var special = "@#&%$";
            var genPass = new string[12];
            genPass = addCharsToPass(genPass, nums);
            genPass = addCharsToPass(genPass, letters);
            genPass = addCharsToPass(genPass, special);
            genPass = addCharsToPass(genPass, letters.ToUpper());
            _passCheckViewModel.GenPass = string.Join("", genPass);
        }
    }
}