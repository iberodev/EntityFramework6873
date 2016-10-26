using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BulkDeleteCreate.SqlServer;
using BulkDeleteCreate.Repositories;
using System.Reflection;

namespace ArgumentNullSample
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //Add EF services
            services.AddDbContext<SampleContext>(options =>
            {
                options.UseSqlServer(connectionString,
                    sqlServerOptions => sqlServerOptions.MigrationsAssembly(migrationsAssembly));
            });

            //ASP.NET Core MVC
            services.AddMvc();

            services.AddTransient<SampleContextSeeder>();
            services.AddScoped<ITestRepository, TestRepository>();
        }


        public void Configure(IApplicationBuilder app, 
            ILoggerFactory loggerFactory,
            SampleContext context,
            SampleContextSeeder seeder)
        {
            loggerFactory.AddDebug(LogLevel.Debug);
            context.Database.Migrate();
            seeder.EnsureSeedData();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
