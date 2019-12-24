using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Starglade.Mobile
{
    public class StargladeHttpClientHandler: HttpClientHandler
    {
        public StargladeHttpClientHandler()
        {
            this.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssPolicyError) =>
             {
                 return true;
             };
        }

    }
}
