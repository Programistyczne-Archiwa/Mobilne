using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Essentials;

namespace fileAccess
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            
        }
       
        private void button_Clicked(object sender, EventArgs e)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "temp.txt");
            using (var writer = File.CreateText(filename))
            {
                writer.Write(t1.Text);
            }
            button.Text = "Zapisano!";


        }

        private void button_Clicked_1(object sender, EventArgs e)
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "temp.txt");
            using (var reader = File.OpenText(filename))
            {
                textbox.Text = reader.ReadToEnd();
            }

            button.Text = "Zapisz";
        }

        async void aaaaa_Clicked(object sender, EventArgs e)
        {
            
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick an Image",

            });
            if(pickResult != null)
            {
                var stream = await pickResult.OpenReadAsync();
                
                if(resultImage.Source == null)
                {
                    resultImage.Source = ImageSource.FromStream(() => stream);
                }else if(resultImage1.Source == null)
                {

                    resultImage1.Source = ImageSource.FromStream(() => stream);
                }
                else if (resultImage2.Source == null)
                {

                    resultImage2.Source = ImageSource.FromStream(() => stream);
                }
                else if (resultImage3.Source == null)
                {

                    resultImage3.Source = ImageSource.FromStream(() => stream);
                }
                else if (resultImage4.Source == null)
                {

                    resultImage4.Source = ImageSource.FromStream(() => stream);
                }
                else if (resultImage5.Source == null)
                {

                    resultImage5.Source = ImageSource.FromStream(() => stream);
                }
            
            }
        }
    }
}
