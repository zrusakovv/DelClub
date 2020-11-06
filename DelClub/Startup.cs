using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DelClub.Models;
using DelClub.Models.Data;
using DelClub.Models.EFData;
using DelClub.Models.Interface;
using DelClub.Models.Sessioïs;
using DelClub.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DelClub
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:DelClub:ConnectionString"]));

            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddTransient<IRestaurantRepository, EFRestaurantRepository>();
            services.AddTransient<IFoodRepository, EFFoodRepository>();
            services.AddTransient<IBurgerKingRepository, EFBurgerKingRepository>();
            services.AddTransient<IDominoPizzaRepository, EFDominoPizzaRepository>();
            services.AddTransient<IKfcRepository, EFKfcRepository>();
            services.AddTransient<IMyBoxRepository, EFMyBoxRepository>();
            services.AddTransient<ISushiBoxRepository, EFSushiBoxRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();

            services.AddScoped(sp => SessioïCart.GetCart(sp));
            services.AddScoped(sp => SessionBurgerKing.GetCart(sp));
            services.AddScoped(sp => SessionDominoPizza.GetCart(sp));
            services.AddScoped(sp => SessionKfc.GetCart(sp));
            services.AddScoped(sp => SessionMyBox.GetCart(sp));
            services.AddScoped(sp => SessionSushiBox.GetCart(sp));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();
            services.AddSession();
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            

            DataRestaurant.EnsurePopulated(app);
        }
    }
}
