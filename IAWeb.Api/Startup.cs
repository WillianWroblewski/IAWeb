using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IAWeb.Infra.Contexts;
using IAWeb.Infra.Transactions;
using IAWeb.Domain.Repositories;
using IAWeb.Infra.Repositories;
using IAWeb.Domain.Commands.Handlers;
using IAWeb.Shared;
using Microsoft.Extensions.Configuration;

namespace IAWeb.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();

            services.AddScoped<IAWebDataContext, IAWebDataContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });
            app.UseMvc();

            Runtime.ConnectionString = Configuration.GetConnectionString("CnnStr");
        }
    }
}
