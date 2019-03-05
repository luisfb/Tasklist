using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tasklist.App.Services;
using Tasklist.Domain.Interfaces;
using Tasklist.Infra;
using Tasklist.Infra.Repositories;

namespace Tasklist.API
{
    public class IoCConfig
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddScoped<DbContext, EntityFrameworkContext>();            
        }
    }
}
