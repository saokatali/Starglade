using Starglade.Mobile.Models;
using Starglade.Mobile.Services;
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
    public partial class Blogs : ContentPage
    {
        private readonly PostService postService;

        public Blogs()
        {
            InitializeComponent();
            this.postService = Container.Services.GetService<PostService>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var posts = await postService.GetAllAsync();
            BindingContext = posts;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var post = e.CurrentSelection.SingleOrDefault() as Post;
            Navigation.PushAsync(new PostDetail(post));
        }
    }
}