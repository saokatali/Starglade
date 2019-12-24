using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.Json;
using System.Reflection;
using System.IO;
using Starglade.Mobile.Pages;

namespace Starglade.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            LoadAppSettings();
            Container.RegisterServices();
            MainPage = new NavigationPage(new MainPage());
        }

        public AppSettings Settings { get; private set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void LoadAppSettings()
        {
#if RELEASE
            var appSettingsStream = Assembly.GetAssembly(typeof(AppSettings)).GetManifestResourceStream("Starglade.Mobile.appsettings.release.json");
   
#else
            var appSettingsStream = Assembly.GetAssembly(typeof(AppSettings)).GetManifestResourceStream("Starglade.Mobile.appsettings.debug.json");
#endif
            using (var reader = new StreamReader(appSettingsStream))
            {
                string settings = reader.ReadToEnd();
                Settings = JsonSerializer.Deserialize<AppSettings>(settings, new JsonSerializerOptions { PropertyNameCaseInsensitive=true});
                
            }




        }
    }
}
