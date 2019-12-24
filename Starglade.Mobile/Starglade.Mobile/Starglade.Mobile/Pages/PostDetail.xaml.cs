using Starglade.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Starglade.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetail : ContentPage
    {
        private readonly Post post;

        public PostDetail(Post post)
        {
            InitializeComponent();
            this.post = post;
        }
    }
}