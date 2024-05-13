using GelirGiderApp.Data.DTO;
using GelirGiderApp.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelirGiderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GelirGiderController : ControllerBase
    {
        private readonly IGelirGiderService _service;

        public GelirGiderController(IGelirGiderService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<GelirGiderDTO>>> GetAll()
        {
            var result = await _service.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            else
                return Ok(result);

        }

        //[HttpGet]
        //[Route("getByFilter/{tur?}/{urun?}/{kategori?}")]
        //public async Task<ActionResult<IEnumerable<GelirGiderDTO>>> GetByFilter(int? tur=null,int? urun=null,int? kategori=null)
        //{
        //    if (tur==0 && urun==0 && kategori==0)
        //    {
        //        tur = null;
        //        urun = null;
        //        kategori = null;
        //    }
        //    var result= await _service.GetAllByFilter(tur, urun, kategori);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //        return Ok(result);
           
        //}
        [HttpGet("gelirGiderDetail/{id}")]
        public async Task<ActionResult<GelirGiderDTO>> GetById(int id)
        {
            var result= await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
                return Ok(result);
        }
        [HttpPost]
        [Route("addGelirGider")]
        public async Task<ActionResult> Add(GelirGiderDTO entity)
        {
            if (entity != null)
            {
                var result = await _service.Add(entity);
                if (result)
                {
                    return Ok();
                }                
            }          
                return BadRequest();
        }
        [HttpPut]
        [Route("updateGelirGider")]
        public async Task<ActionResult> Update(GelirGiderDTO entity)
        {
            if (entity != null)
            {
                var result = await _service.Update(entity);
                if (result)
                {
                    return Ok();
                }
            }
                return BadRequest();
        }
        [HttpDelete("deleteGelirGider/{id}")]
        //[Route("update")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("sumGelirGider/{donem}/{urun}/{kategori}")]
        public async Task<ActionResult<GelirGiderDTO>> Sum(int donem , int urun , int kategori)
        {
            var result = await _service.Sum(donem, urun, kategori);
            if (result == null)
            {
                return NotFound();
            }
            else
                return Ok(result);

        }
    }
}
