using GelirGiderApp.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Service.Extension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection service)
        {
            service.AddScoped<IGelirGiderService, GelirGiderService>();
            var assembly = Assembly.GetExecutingAssembly();
            service.AddAutoMapper(assembly);
            return service;
        }
    }
}
