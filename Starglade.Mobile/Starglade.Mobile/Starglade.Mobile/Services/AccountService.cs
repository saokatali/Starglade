using Starglade.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Starglade.Mobile.Extension;

namespace Starglade.Mobile.Services
{
    public class AccountService
    {
        private readonly HttpClient httpClient;

        public AccountService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<User> Sigin(Signin signin)
        {
            return await httpClient.PostDataAsync<Signin, User>("/Auth", signin);

        }
    }
}
