using GelirGiderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Data.Repositories
{
    public interface IGelirGiderRepository
    {
        Task<IEnumerable<GelirGider>> GetAll();
        Task<GelirGider> GetById(int id);
        Task<int> Add(GelirGider entity);
        Task<int> Update(GelirGider entity);
        Task<int> Delete(int id);
        Task<GelirGider> Sum(int donem, int urun, int kategori);

    }
}
