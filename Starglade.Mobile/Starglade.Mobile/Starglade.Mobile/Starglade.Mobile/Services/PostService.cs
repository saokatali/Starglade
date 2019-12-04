using Starglade.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Starglade.Mobile.Extension;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;

namespace Starglade.Mobile.Services
{
    public class PostService
    {

        private readonly HttpClient httpClient;

        public PostService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Post>> GetAllAsync()
        {          
            return await httpClient.GetAllAsync<Post>("/Post");           
        }
    }
}
