using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DateTimeProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            DateTime date = new DateTime();
            string minute_bin, hours_bin;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                BoxView[] boxViews = grid.Children.OfType<BoxView>().ToArray(); 
                date = DateTime.Now;
                minute_bin = Convert.ToString(date.Minute, 2);
                hours_bin = Convert.ToString(date.Hour, 2);
                while (minute_bin.Length < 6)
                    minute_bin = "0" + minute_bin;
                while (hours_bin.Length < 4)
                    hours_bin = "0" + hours_bin;
                for(int i = 0; i < 4; i++)
                {
                    BoxView boxView = boxViews[i] as BoxView;
                    if (hours_bin[i] == '1')
                    {
                        boxView.BackgroundColor = Color.Red;
                    }
                    else
                    {
                        boxView.BackgroundColor = Color.White;
                    }
                }
                for(int i = 0; i < 6; i++)
                {
                    BoxView boxView = boxViews[i + 4] as BoxView;
                    if (minute_bin[i] == '1')
                    {
                        boxView.BackgroundColor = Color.Red;
                    }
                    else
                    {
                        boxView.BackgroundColor = Color.White;
                    }
                }
                
                return true;
            });

            InitializeComponent();
        }
    }

}
