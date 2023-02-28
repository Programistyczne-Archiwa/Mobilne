using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace nokiaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            Device.StartTimer(new TimeSpan(0, 0, 0), () =>
            {
                Godzina.Text = DateTime.Now.ToString("HH:mm");
                Data.Text = DateTime.Now.ToString("yyyy'-'MM'-'dd");
                return true;
            });

            
        }

        private void Start(object sender, EventArgs e)
        {
            world.IsVisible = true;
            dateTime.IsVisible = false;
            icons.IsVisible = false;
        }
        private void Stop(object sender, EventArgs e)
        {
            world.IsVisible=false;
            dateTime.IsVisible = true;
            icons.IsVisible = false;
        }

        private void Menu(object sender, EventArgs e)
        {
            world.IsVisible = false;
            dateTime.IsVisible = false;
            icons.IsVisible = true;
        }
    }
}
