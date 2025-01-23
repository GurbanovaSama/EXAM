using ExamCode.DAL.Models;
using ExamCode.DAL.Repository.Abstractions;
using ExamCode.DAL.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ExamCode.DAL
{
    public static  class ConfigurationServices
    {
        public static void AddDALService(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Plan>, Repository<Plan>>();
            services.AddScoped<IRepository<Member>, Repository<Member>>();
        }
    }
}
