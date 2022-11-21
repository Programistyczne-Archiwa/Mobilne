using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void btn_save_txt_to_file_Clicked(object sender, EventArgs e)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
            Trace.WriteLine(filename);
            if (File.Exists(filename))
            {
                File.WriteAllText(filename, editor_notepad.Text);
                Trace.WriteLine(File.ReadAllText(filename));
            }
        }

        private void btn_read_txt_from_file_Clicked(object sender, EventArgs e)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
            Trace.WriteLine(filename);
            if (File.Exists(filename))
            {
                Trace.WriteLine(File.ReadAllText(filename));
                editor_notepad.Text = File.ReadAllText(filename);
            }
        }
    }
}
