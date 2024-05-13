using GelirGiderApp.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Service.Services
{
    public interface IGelirGiderService
    {
        Task<IEnumerable<GelirGiderDTO>> GetAll();
        Task<GelirGiderDTO> GetById(int id);
        Task<bool> Add(GelirGiderDTO entity);
        Task<bool> Update(GelirGiderDTO entity);
        Task<bool> Delete(int id);
        Task<GelirGiderDTO> Sum(int donem, int urun, int kategori);
    }
}
