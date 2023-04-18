using System.Windows;
using System.Windows.Controls;

namespace CheckPasswordApp.Views
{
    /// <summary>
    ///     Logika interakcji dla klasy PassCheckView.xaml
    /// </summary>
    public partial class PassCheckView : UserControl
    {
        public PassCheckView()
        {
            InitializeComponent();
        }

        private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null) ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
        }

        private void ShowPasswordCharsCheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            PasswordHidden.Visibility = Visibility.Collapsed;
            PasswordVisible.Visibility = Visibility.Visible;

            PasswordVisible.Focus();
        }

        private void ShowPasswordCharsCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            PasswordHidden.Password = ((dynamic)DataContext).Password;
            PasswordHidden.Visibility = Visibility.Visible;
            PasswordVisible.Visibility = Visibility.Collapsed;

            PasswordHidden.Focus();
        }
    }
}