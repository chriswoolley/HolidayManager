using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolidayWeb.Core;
using HolidayWeb.Models;
using HolidayWeb.Models.Interface;
using HolidayWeb.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace HolidayWeb
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                           .SetBasePath(hostingEnvironment.ContentRootPath)
                           .AddJsonFile("appsettings.json")
                           .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));


            

            services.AddTransient<IDepartment, DepartmentRepository>();
            services.AddTransient<IEvent, EventRepository>();
            services.AddTransient<IEventType, EventTypeRepository>();
            services.AddTransient<IState, StateRepository>();
            services.AddTransient<IHolidayEntitlement, HolidayEntitlementRepository>();
            services.AddTransient<IAppointment, AppointmentRepository>();
            services.AddSingleton<IRuntime, RunTime>();
            services.AddTransient<IHolidayCalc, HolidayCalc>();
            services.AddTransient<ISystemHoliday, SystemHolidayRepository> ();
            services.AddTransient<ISystemSetting, SystemSettingRepository>();


            services.AddIdentity<HolidayUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;

            })
                .AddUserManager<ApplicationUserManager>() //new line
                .AddEntityFrameworkStores<AppDbContext>();



            services
                .AddMemoryCache()
                .AddSession(s => {
                    s.Cookie.Name = "DevExtreme.NETCore.Demos";
                });

    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });



        }
    }
}
