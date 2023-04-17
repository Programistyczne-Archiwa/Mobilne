using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NokiaApp
{
    public partial class MainPage : ContentPage
    {
        public bool isOn = false;
        public string theme = "old";
        public MainPage()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Time.Text = DateTime.Now.ToString("HH:mm:ss");
                Date.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
                return true;
            });

            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (isOn == false) return;
            if (Text.Text == "")
            {
                Text.Text = "Hello world!";
            }
            else
            {
                Text.Text = "";
            }
        }

        private void Num_Clicked(object sender, EventArgs e)
        {
            if (isOn == false) return;
            Button button = (Button)sender;
            if (Text.Text == "Hello world!")
            {
                Text.Text = button.Text;
            }
            else
            {
                if (Text.Text.Length == 9) return;
                Text.Text += button.Text;
            }
        }
        private void Del_Clicked(object sender, EventArgs e)
        {
            if (isOn == false) return;
            Button button = (Button)sender;
            if (Text.Text == "Hello world!")
            {
                return;
            }
            else
            {
                if (Text.Text.Length == 0) return;
                Text.Text = Text.Text.Remove(Text.Text.Length - 1, 1);
            }
        }
        private void Start_Clicked(object sender, EventArgs e)
        {
            isOn = true;
            if (theme == "old")
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ButtonStyleOn"];
                }
            }
            else
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ChildStyleOn"];
                }
            }
            Menu.IsVisible = true;
            ImageMenu.IsVisible = false;
        }
        private void Stop_Clicked(object sender, EventArgs e)
        {
            isOn = false;
            if (theme == "old")
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ButtonStyleOff"];
                }
            }
            else
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ChildStyleOff"];
                }
            }
            Menu.IsVisible = false;
            ImageMenu.IsVisible = false;
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            if (isOn == false) return;
            PhoneDialer.Open(Text.Text);
        }

        private void ImageMenu_Clicked(object sender, EventArgs e)
        {
            if (isOn == false) return;
            if (ImageMenu.IsVisible == false)
            {
                Menu.IsVisible = false;
                ImageMenu.IsVisible = true;
            }
            else
            {
                Menu.IsVisible = true;
                ImageMenu.IsVisible = false;
            }
        }

        private void Old_Clicked(object sender, EventArgs e)
        {
            theme = "old";
            FramePhone.Style = (Style)this.Resources["FramePhoneStyle"];
            FrameScreen.Style = (Style)this.Resources["FrameScreenStyle"];
            if (isOn == true)
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ButtonStyleOn"];
                }
            }
            else
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ButtonStyleOff"];
                }
            }
        }

        private void Child_Clicked(object sender, EventArgs e)
        {
            theme = "child";
            FramePhone.Style = (Style)this.Resources["ChildFramePhoneStyle"];
            FrameScreen.Style = (Style)this.Resources["ChildFrameScreenStyle"];
            if (isOn == true)
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ChildStyleOn"];
                }
            }
            else
            {
                foreach (Button button in GridButtons.Children.OfType<Button>())
                {
                    button.Style = (Style)this.Resources["ChildStyleOff"];
                }
            }
        }
    }
}
