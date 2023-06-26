using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiniProject.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.DAL.Extensions
{
    public static class DALRegistrator
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<MiniProjectContext>(options => options.UseSqlServer("name=ConnectionStrings:MiniProject"));

            return services;
        }
    }
}
