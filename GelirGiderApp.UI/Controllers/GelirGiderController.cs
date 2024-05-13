using GelirGiderApp.UI.Clients;
using GelirGiderApp.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GelirGiderApp.UI.Controllers
{
    public class GelirGiderController : Controller
    {
        private readonly IGelirGiderClient _client;
        Dictionary<int,string> urunList = null;
        Dictionary<int, string> kategoriList = null;
        Dictionary<int, string> turList = null;
        Dictionary<int, string> donemList = null;

        public GelirGiderController(IGelirGiderClient client)
        
        {
            urunList = new Dictionary<int, string>()
            {
                {0,"Tüm ürünler"},
                {1, "Hesap" },
                {2, "Kart" }
            };
            kategoriList = new Dictionary<int, string>()
            {
                {0,"Tüm kategoriler"},
                {1, "Kira" },
                {2, "Bağış" },
                {3, "Vergi" },
                {4, "Aidat" },
                {5, "Diğer" }
            };
           turList = new Dictionary<int, string>()
            {
                {1, "Gelir" },
                {2, "Gider" }
            };
            donemList = new Dictionary<int, string>()
            {
                {0,"Tüm dönemler"},
                {7, "Haftalık" },
                {30, "1 Aylık" },
                {90, "3 Aylık" },

            };

            _client = client;
        }
        [HttpGet()]
        public async Task<IActionResult> GelirGiderIslemleri()
        {
            var result = new List<GelirGiderVM>();

            result = await _client.GetAll();
            
            
            if (result!=null)
            {
                var resultWithNames=GetNames(result);
                return View(resultWithNames);
            }
            else
            {
                return View();
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            Init();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(GelirGiderVM entity)
        {
            Random randomId = new Random();
            entity.GelirGiderID = randomId.Next(100);
            if (ModelState.IsValid)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var result = await _client.AddGelirGider(request, entity);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GelirGiderIslemleri");
                  
                }
                else
                {
                   
                    return RedirectToAction("Error", "Home");
                }

            }
            else
            {
                return View(entity);
            }
         
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Init();

            GelirGiderVM gelirGider = new GelirGiderVM();

            var result = await _client.GetById(id);

            if (result!=null)
            {
                //string data = result.Content.ReadAsStringAsync().Result;
                //building = JsonConvert.DeserializeObject<BuildingVM>(data);
                return View(result);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Update(GelirGiderVM model)
        {

            if (ModelState.IsValid)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var result = await _client.UpdateGelirGider(request, model);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GelirGiderIslemleri");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }


            }
            else
            {

                return View(model);
            }


        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var building = await  _client.GetById(id);
            if (building != null)
            {
                HttpRequestMessage request = new HttpRequestMessage();
                var result =await   _client.DeleteGelirGider(id);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GelirGiderIslemleri");

                }
                else
                {
                    return RedirectToAction("Error", "Home");
                     
                }

            }
            else
            {

                return RedirectToAction("GelirGiderIslemleri");
            }
        }

        public ActionResult Tablolar()
        {
            Init();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Load(GelirGiderVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _client.SumGelirGider(model.DonemID, model.UrunID, model.KategoriID);
                return Json(result);
            }
            else
                return RedirectToAction("Tablolar");

        }

        public void Init()
        {
            ViewBag.UrunList = urunList;
            ViewBag.KategoriList = kategoriList;
            ViewBag.TurList = turList;
            ViewBag.DonemList = donemList;
        }

        public List<GelirGiderVM> GetNames(List<GelirGiderVM> model)
        {
            string urunName = "";
            string kategoriName = "";
            string turName = "";
            foreach (var item in model)
            {
                urunList.TryGetValue(item.UrunID, out urunName);
                item.UrunAd = urunName;
                kategoriList.TryGetValue(item.KategoriID, out kategoriName);
                item.KategoriAd = kategoriName;
                turList.TryGetValue(item.TurID, out turName);
                item.TurAd = turName;
            }

            return model;
            
        }



        
    }
}
