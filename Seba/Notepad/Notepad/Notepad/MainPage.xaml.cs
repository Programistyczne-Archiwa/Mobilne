using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notepad
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void alert_save_file(object sender, EventArgs e)
        {
            await DisplayAlert("Zapis pliku", "Pomyślnie zapisano plik!", "Ok");
        }

        async void alert_read_file(object sender, EventArgs e)
        {
            await DisplayAlert("Odczyt pliku", "Pomyślnie odczytano plik!", "Ok");
        }

        private void btn_save_txt_to_file_Clicked(object sender, EventArgs e)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
            using (var writer = File.CreateText(filename))
            {
                writer.Write(editor_notepad.Text);
                alert_save_file(sender, e);
            }
        }

        private void btn_read_txt_from_file_Clicked(object sender, EventArgs e)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
            if(File.Exists(filename))
            {
                using (var reader = File.OpenText(filename))
                {
                    editor_notepad.Text = reader.ReadToEnd();
                    alert_read_file(sender, e);
                }
            }
        }
    }
}
