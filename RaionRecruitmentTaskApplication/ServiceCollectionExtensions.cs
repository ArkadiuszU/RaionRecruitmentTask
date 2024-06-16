
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace RaionRecruitmentTaskApplication
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services) {

         
            var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
            services.AddAutoMapper(applicationAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

            services.AddValidatorsFromAssembly(applicationAssembly)
           .AddFluentValidationAutoValidation();
        }
    }
}
