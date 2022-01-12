using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Holiday.BL;
using Holiday.BL.Interface;
using Holiday.Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Interview_Web_API
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
            services.AddMvc();
         
            services.AddTransient<IAPICountryListService, APICountryListService>();
            //IHolidayService holidayService, IHolidayTypeService holidayTypeService
            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<IHolidayTypeService, HolidayTypeService>();
            services.AddTransient<ICountryService, CountryService>();
            



            services.AddDbContext<HolidayDBContext>(optionsBuilder =>
            {

                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1",new OpenApiInfo() { 
                Title="Holiday API",
                Version="1.1",
                Description="API Documentation"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,HolidayDBContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            db.Database.EnsureCreated();

            app.UseStaticFiles();
            app.UseRouting();

            //app.UseHttpsRedirection();
            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Holiday API");
            });
        }
    }
}
