using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoTicket.Interface;
using DemoTicket.Models;
using DemoTicket.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoTicket
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
            //services.AddControllersWithViews();

            services.AddMvc(option => option.EnableEndpointRouting = false).AddViewLocalization()
            .AddDataAnnotationsLocalization();
            services.AddSession();
            services.AddDbContext<dbInterviewContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));

    //        services.AddDbContext<ZipcodeContext>(options =>
    //options.UseSqlServer(Configuration.GetConnectionString("ConnectionNameHere"))); 


            //services.Add(new ServiceDescriptor(typeof(IBuyerRepository), typeof(BuyerRepository), ServiceLifetime.Transient));
            //services.Add(new ServiceDescriptor(typeof(IEventRepository), typeof(EventRepository), ServiceLifetime.Transient));

            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddSingleton<IBuyerRepository, BuyerRepository>();
            //serviceCollection.AddSingleton<IEventRepository, EventRepository>();
            //Container = serviceCollection.BuildServiceProvider();


            
            services.AddTransient<IBuyerRepository, BuyerRepository>();
            services.AddTransient<IEventRepository, EventRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();
          

            app.UseRouting();

            //app.UseAuthorization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Ticket}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
