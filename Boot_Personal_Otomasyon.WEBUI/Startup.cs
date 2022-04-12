using Boots_Personal_Otomasyon.BL.Abstract;
using Boots_Personal_Otomasyon.BL.Concrete;
using Boots_Personal_Otomasyon.DAL.Abstract;
using Boots_Personal_Otomasyon.DAL.Concrete;
using Boots_Personal_Otomasyon.DAL.Context.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boot_Personal_Otomasyon.WEBUI
{
    
    public class Startup
    {
        public Startup(IConfiguration configuration)//Bu nesne sayesinde appsettings e ulaþabiliyoruz.
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //EF Context Ekledik ve connectionstringi tanýmladýk
            services.AddDbContext<PersonalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PersonalCs")));

            //Repositoryi servislere eklememiz gerekir. IUserRepository olursa UserRepository gönderir.
            services.AddScoped<IUserRepository, UserRepository>();

            //Business user katmaný için dependency container kullanýlýr.
            services.AddScoped<IUserBusiness, UserBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                

            });

            
        }
    }
}
