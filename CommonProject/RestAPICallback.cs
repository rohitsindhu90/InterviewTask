using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Holiday.Common
{
    public static class RestAPICallback
    {
        public static async Task<T> Get<T>(string endpoint)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(endpoint))
                {
                    using (HttpContent content = response.Content)
                    {
                     var obj=await content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(obj);
                    }
                }
            }
        }
    }
}
