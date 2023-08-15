using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInfoSys.DataContext;
using CarInfoSys.Repositories;
using CarInfoSys.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarInfoSys
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMemoryCache();
            //    services.AddScoped<CarService>();
            services.AddScoped<CarRentalService,CarRentalServiceImpl>();
            services.AddScoped<CarService,CarServiceImpl>();
            services.AddScoped<CustomerService,CustomerServiceImpl>();
            services.AddScoped<DriverService,DriverServiceImpl>();
            services.AddScoped<CarRepository,CarRepositoryImpl>();
            services.AddScoped<CarRentalRepository,CarRentalRepositoryImpl>();
            services.AddScoped<DriverRepository,DriverRepositoryImpl>();
            services.AddScoped<CustomerRepository,CustomerRepositoryImpl>();



            services.AddDbContext<SysDataContext>(options =>
          options.UseNpgsql(Configuration.GetConnectionString("CarInfoDB")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
