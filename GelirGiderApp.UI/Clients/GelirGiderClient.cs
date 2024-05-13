using GelirGiderApp.UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GelirGiderApp.UI.Clients
{
    public class GelirGiderClient : IGelirGiderClient
    {
        public HttpClient _client { get; }
        public GelirGiderClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "GelirGiderClient");
            _client = client;
        }
        public async Task<HttpResponseMessage> AddGelirGider(HttpRequestMessage request, GelirGiderVM model)
        {
            request.RequestUri = new Uri(_client.BaseAddress + "api/GelirGider/addGelirGider");
            request.Method = HttpMethod.Post;
            request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await _client.SendAsync(request);
        }


        public async Task<HttpResponseMessage> DeleteGelirGider(int id)
        {
            return await _client.DeleteAsync("api/GelirGider/deleteGelirGider/" + id);
        }

        public async Task<List<GelirGiderVM>> GetAll()
        {           
            List<GelirGiderVM> list = new List<GelirGiderVM>();
            var result= await _client.GetAsync("api/GelirGider/getAll");
            string data = result.Content.ReadAsStringAsync().Result;
            list = JsonConvert.DeserializeObject<List<GelirGiderVM>>(data);
            return list;
        }

        public async Task<GelirGiderVM> GetById(int id)
        {
            GelirGiderVM gelirGider = new GelirGiderVM();
            var result = await _client.GetAsync("api/GelirGider/gelirGiderDetail/" + id);
            string data = result.Content.ReadAsStringAsync().Result;
            gelirGider = JsonConvert.DeserializeObject<GelirGiderVM>(data);
            return gelirGider;
            
        }

        public async Task<HttpResponseMessage> UpdateGelirGider(HttpRequestMessage request, GelirGiderVM model)
        {
            request.RequestUri = new Uri(_client.BaseAddress + "api/GelirGider/updateGelirGider");
            var gelirGiderModel = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            return await _client.PutAsync(request.RequestUri, gelirGiderModel);
        }

        public async Task<GelirGiderVM> SumGelirGider(int donem, int? urun, int? kategori)
        {
            GelirGiderVM gelirGider = new GelirGiderVM();
            var result = await _client.GetAsync("api/GelirGider/sumGelirGider/"+donem+"/"+urun+"/"+kategori);
            string data = result.Content.ReadAsStringAsync().Result;
            gelirGider = JsonConvert.DeserializeObject<GelirGiderVM>(data);
            return gelirGider;
        }
    }
}
