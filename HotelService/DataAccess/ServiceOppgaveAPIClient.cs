using Hotel_service.Model;
using Hotel_service.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Hotel_service.DataAccess
{
    public static class ServiceOppgaveAPIClient
    {

        public static async Task  <List<ServiceOppgave>> HentServiceOppgaver()
        {
            string url = "http://localhost:64419/ServiceOppgaver";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    List<ServiceOppgave> oppgaver = JsonConvert.DeserializeObject<List<ServiceOppgave>>(data);
                    return oppgaver;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }


        }
    }
}
