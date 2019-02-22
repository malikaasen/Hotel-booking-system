using Hotel_service.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_service.DataAccess
{
    public class ServiceOppgaveAPIClient
    {
        static HttpClient client = new HttpClient();
        
        public ServiceOppgaveAPIClient()
        {
            client.BaseAddress = new Uri("http://localhost:64418/serviceoppgaver");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<ServiceOppgave>> HentServiceOppgaverAsync()
        {
            string result = "";
            List<ServiceOppgave> serviceOppgaver;
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            serviceOppgaver = JsonConvert.DeserializeObject<List<ServiceOppgave>>(result);
            return serviceOppgaver;
        }
    }
}
