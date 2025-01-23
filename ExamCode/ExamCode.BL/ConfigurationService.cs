using ExamCode.BL.Services.Abstractions;
using ExamCode.BL.Services.Implementations;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExamCode.BL
{
    public static class ConfigurationService
    {
        public static void AddBLService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());      
            services.AddFluentValidationAutoValidation();   
            services.AddFluentValidationClientsideAdapters();   


            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IMemberService, MemberService>();
        }
    }
}
