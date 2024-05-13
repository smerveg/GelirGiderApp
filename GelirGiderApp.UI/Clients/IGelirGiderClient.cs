using GelirGiderApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GelirGiderApp.UI.Clients
{
    public interface IGelirGiderClient
    {
        Task<List<GelirGiderVM>> GetAll();
        //Task<List<GelirGiderVM>> GetAllByFilter(int? tur,int? kategori, int? urun);
        Task<GelirGiderVM> GetById(int id);
        Task<HttpResponseMessage> AddGelirGider(HttpRequestMessage request, GelirGiderVM model);
        Task<HttpResponseMessage> UpdateGelirGider(HttpRequestMessage request, GelirGiderVM model);
        Task<HttpResponseMessage> DeleteGelirGider(int id);
        Task<GelirGiderVM> SumGelirGider(int donem, int? urun, int? kategori);

    }
}
