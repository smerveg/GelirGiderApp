using AutoMapper;
using GelirGiderApp.Data.DTO;
using GelirGiderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Service.Mapping
{
    public class GelirGiderProfile:Profile
    {
        public GelirGiderProfile()
        {
            CreateMap<GelirGider, GelirGiderDTO>().ReverseMap();
        }
    }
}
