using Microsoft.Extensions.DependencyInjection;
using MiniProject.BLL.Interfaces;
using MiniProject.BLL.Services;
using MiniProject.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.BLL.Extensions
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ISocialAccountsService, SocialAccountsService>();
            services.AddScoped<ISocialSkillsService, SocialSkillsService>();

            return services;
        }
    }
}
