using AutoMapper;
using GelirGiderApp.Data.DTO;
using GelirGiderApp.Data.Entities;
using GelirGiderApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Service.Services
{
    public class GelirGiderService : IGelirGiderService
    {
        private readonly IGelirGiderRepository _repository;
        private readonly IMapper _mapper;

        public GelirGiderService(IGelirGiderRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Add(GelirGiderDTO entity)
        {
            var mappedEntity= _mapper.Map<GelirGiderDTO, GelirGider>(entity);
            mappedEntity.KategoriID = entity.KategoriID;
            mappedEntity.UrunID = entity.UrunID;
            var result=await _repository.Add(mappedEntity);
            return result > 0 ? true : false;

                
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return result >0 ? true : false;

        }

        public async Task<IEnumerable<GelirGiderDTO>> GetAll()
        {
             var list = await _repository.GetAll();
            return _mapper.Map<IEnumerable<GelirGiderDTO>>(list);


        }


        public async Task<GelirGiderDTO> GetById(int id)
        {
            var result = await _repository.GetById(id);
            var mappedResult= _mapper.Map<GelirGider, GelirGiderDTO>(result);
            return mappedResult;

        }

        public async Task<GelirGiderDTO> Sum(int donem, int urun, int kategori)
        {
            var result= await _repository.Sum(donem, urun, kategori);
            var mappedResult = _mapper.Map<GelirGider, GelirGiderDTO>(result);
            return mappedResult;
        }

        public async Task<bool> Update(GelirGiderDTO entity)
        {
            var mappedEntity = _mapper.Map<GelirGiderDTO, GelirGider>(entity);
            mappedEntity.KategoriID = entity.KategoriID;
            mappedEntity.UrunID = entity.UrunID;
            var result = await _repository.Update(mappedEntity);
            return result >0 ? true : false;
        }
    }
}
