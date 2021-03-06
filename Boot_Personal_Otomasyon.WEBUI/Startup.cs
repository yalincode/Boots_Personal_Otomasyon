using AutoMapper;
using Boots_Personal_Otomasyon.BL.Abstract;
using Boots_Personal_Otomasyon.BL.Concrete;
using Boots_Personal_Otomasyon.DAL.Abstract;
using Boots_Personal_Otomasyon.DAL.Concrete;
using Boots_Personal_Otomasyon.DAL.Context.EF;
using Boots_Personal_Otomasyon.WEBUI.AutoMapper;
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
using System.Reflection;
using System.Threading.Tasks;
using MVCGrid;
using MVCGrid.NetCore;

namespace Boot_Personal_Otomasyon.WEBUI
{
    
    public class Startup
    {
        public Startup(IConfiguration configuration)//Bu nesne sayesinde appsettings e ula?abiliyoruz.
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAutoMapper(cfg=>cfg.AddProfile<GeneralProfile>(),typeof(Startup));
            //var mapperConfig = new MapperConfiguration(mc => mc.AddProfile<GeneralProfile>());
            //IMapper mapper=mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(GeneralProfile));


            services.AddControllersWithViews();

            //EF Context Ekledik ve connectionstringi tan?mlad?k
            services.AddDbContext<PersonalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PersonalCs")));

            //Repositoryi servislere eklememiz gerekir. IUserRepository olursa UserRepository g?nderir.
            services.AddScoped<IUserRepository, UserRepository>();

            //Business user katman? i?in dependency container kullan?l?r.
            services.AddScoped<IUserBusiness, UserBusiness>();
            //Personal i?lemleri
            services.AddScoped<IPersonalBusiness, PersonalBusiness>();
            services.AddScoped<IPersonalRepository,PersonalRepository>();

            services.AddMvcGrid();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IPersonalBusiness personalBusiness,IMapper mapper)
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

            app.RegisterMVCGrid("PersonalListGrid", Boots_Personal_Otomasyon.WEBUI.Grid.PersonalListGrid.PersonalListGridCustumize(app));
            //Grid i?erisine database entegre ?ekilde ?al??mas? i?in yap?ld?.
            //Ekrana buradan bas?lacak.
            app.UseMvcGrid();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                

            });

            
        }
    }
}
