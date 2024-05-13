using GelirGiderApp.Data.Context;
using GelirGiderApp.Data.DataSeed;
using GelirGiderApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Data.Extensions
{
    public static class DataExtension
    {
        public static IServiceCollection AddDataExtension(this IServiceCollection service)
        {
            service.AddDbContext<GelirGiderContext>(g => g.UseInMemoryDatabase("GelirGiderDB"));
            service.AddScoped<IGelirGiderRepository, GelirGiderRepository>();
            return service;
        }
    }
}
