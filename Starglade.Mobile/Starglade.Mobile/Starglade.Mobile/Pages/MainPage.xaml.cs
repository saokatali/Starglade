using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Starglade.Mobile.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void Login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private void Blogs(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Blogs());
        }

        private void About(object sender, EventArgs e)
        {
            Navigation.PushAsync(new About());
        }
    }
}
