using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Blocks.EntityFrameWork.Repo;
using Submission.Persistance.Repositories;

namespace Submission.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<SubmissionDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped(typeof(Repository<>));
            services.AddScoped(typeof(ArticleRepository));
            return services;
        }

    }
}
