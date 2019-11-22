using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Altkom._20_22._11.CSharp.Services
{
    public class CustomHttpClient
    {
        public HttpClient Client { get; }
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
    };

    public CustomHttpClient()
        {
            Client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:58842"),
                //Timeout = TimeSpan.FromSeconds(100)
            };

            Client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            //Client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("gzip"));
            Client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue("CustomClient", "1.0")));
        }

        public async Task<T> Get<T>(string requestUri)
        {
            try
            {
                var response = await Client.GetAsync(requestUri);
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                return default(T);
            }
        }

        public async Task<T> Post<T>(string requestUri, T model)
        {
            try
            {
                var httpContent = StringContent(model);
                var response = await Client.PostAsync(requestUri, httpContent);
                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch
            {
                return default(T);
            }
        }
        private StringContent StringContent<T>(T model)
        {
            return new StringContent(JsonConvert.SerializeObject(model, Formatting.None, _jsonSerializerSettings),
                Encoding.UTF8, "application/json");
        }

        public async Task<bool> Put<T>(string requestUri, T model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var httpContent = new StringContent(json);
                var response = await Client.PutAsync(requestUri, httpContent);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete<T>(string requestUri)
        {
            try
            {
                var response = await Client.DeleteAsync(requestUri);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
