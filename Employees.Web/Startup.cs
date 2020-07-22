using Domain.Repositories;
using Domain.Services;
using Employees.Application.Queries;
using Employees.Infraestructure.Config;
using Infraestucture.HttpClients;
using Infraestucture.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employees.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
   
            services.AddHttpClient();
            services.AddHttpClient<EmployeeHttpClient>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<EmployeeService>();
            services.AddTransient<EmployeesQueries>();
            services.Configure<EmployeeClientConfig>(Configuration.GetSection("EmployeeApi"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
