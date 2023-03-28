using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace nokiaApp
{
    public partial class MainPage : ContentPage
    {
        public bool a = true;
        public MainPage()
        {
            InitializeComponent();


            Device.StartTimer(new TimeSpan(0, 0, 0, 1), () =>
            {
                a = !a;
                if (a)
                {
                    Godzina.Text = DateTime.Now.ToString("HH:mm");
                }
                else
                {
                    Godzina.Text = DateTime.Now.ToString("HH mm");
                }

                Data.Text = DateTime.Now.ToString("yyyy'-'MM'-'dd");
                return true;
            });

            
        }


        private void Enable()
        {
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;
            button5.IsEnabled = true;
            button6.IsEnabled = true;
            button7.IsEnabled = true;
            button8.IsEnabled = true;
            button9.IsEnabled = true;
            button0.IsEnabled = true;
            clear.IsEnabled = true;
          //  call.IsEnabled = true;
        }
        private void Disable()
        {
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;
            button5.IsEnabled = false;
            button6.IsEnabled = false;
            button7.IsEnabled = false;
            button8.IsEnabled = false;
            button9.IsEnabled = false;
            button0.IsEnabled = false;
            clear.IsEnabled = false;
           // call.IsEnabled = false;
        }
        private void Start(object sender, EventArgs e)
        {
            world.IsVisible = true;
            dateTime.IsVisible = false;
            icons.IsVisible = false;
            Enable();
        }
        private void Stop(object sender, EventArgs e)
        {
            world.IsVisible=false;
            dateTime.IsVisible = true;
            icons.IsVisible = false;
            Disable();
        }

        private void Menu(object sender, EventArgs e)
        {
            world.IsVisible = false;
            dateTime.IsVisible = false;
            icons.IsVisible = true;
            Disable();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (numer.Text.Length == 8)
                {
                    call.IsEnabled = true;
                }
                else
                {
                    call.IsEnabled = false;

                }

            }
            catch (System.NullReferenceException) { }



            string a = (sender as Button).Text;
            switch (a)
            {
                case "1":
                    numer.Text += a;
                    break;
                case "2":
                    numer.Text += a;
                    break;
                case "3":
                    numer.Text += a;
                    break;
                case "4":
                    numer.Text += a;
                    break;
                case "5":
                    numer.Text += a;
                    break;
                case "6":
                    numer.Text += a;
                    break;
                case "7":
                    numer.Text += a;
                    break;
                case "8":
                    numer.Text += a;
                    break;
                case "9":
                    numer.Text += a;
                    break;
                case "0":
                    numer.Text += a;
                    break;
                case "Wyczyść":
                    string b = numer.Text;
                    string str = b.Remove(b.Length - 1);
                    numer.Text = str;
                    break;
                case "Zadzwoń":
                    try
                    {


                        PhoneDialer.Open(numer.Text);

                    }
                    catch (ArgumentNullException anEx)
                    {
                        // Number was null or white space
                    }
                    catch (Exception ex)
                    {
                        // Other error has occurred.
                    }
                    break;
            }
                


        }
    }
}
