using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _06_10_mobilne
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        static int i = 0;
        private void Button_Clicked(object sender, EventArgs e)
        {
            
            i++;
            labelus.Text = $"{i} polubień";
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            i--;
            if(i<0)
            {
                i = 0;
            }
            else{
                labelus.Text = $"{i} polubień";
            }

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}
