﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Starglade.Mobile
{
    public class StargladeHttpClient:HttpClient
    {
        public StargladeHttpClient()
        {
            var app = Application.Current as App;
            BaseAddress = new Uri(app.Settings.ApiUrl);
        }
    }
}
