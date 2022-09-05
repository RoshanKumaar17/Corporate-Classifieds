using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PointsMicroservice.Models
{
    public class Helper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://offermicroservice.azurewebsites.net/");
            return client;
        }
    }
}
