using Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EF
{
    public static class DependencyInjection
    {
        public static void ConfigureInfraestructureLayer(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<ZionDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryEF<>));
        }
    }
}
