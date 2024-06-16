using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RaionRecruitmentTaskDomain.Repositories;
using RaionRecruitmentTaskInfrastructure.Repositories;
using RaionRecruitmentTaskInfrastructure.Seeders;

namespace RaionRecruitmentTaskInfrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            var configurationString = configuration.GetConnectionString("RaionRecruitmentTask");
            services.AddDbContext<RaionRecruitmentTaskDbContext>(options => options.UseSqlServer(configurationString));

            services.AddScoped<IRaionRecruitmentTaskSeeder, RaionRecruitmentTaskSeeder>();
            services.AddScoped<IBalanceRepository, BalanceRepository>();

        }
    }
}
