namespace CheckPasswordApp.ViewModels
{
    public class MainViewModel
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new PassCheckViewModel();
        }
    }
}