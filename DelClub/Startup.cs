using DelClub.Models;
using DelClub.Models.Data;
using DelClub.Models.EFData;
using DelClub.Models.Interface;
using DelClub.Models.Sessioпs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:DelClubIdentity:ConnectionString"]));

            services.AddIdentity<User, IdentityRole>(opt=>
            {
                opt.User.RequireUniqueEmail = true; // уникальный email
                opt.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
                opt.Password.RequiredLength = 5; // минимальная длина
                opt.Password.RequireNonAlphanumeric = false; // требуются ли не алфавитно-цифровые символы
                opt.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opt.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opt.Password.RequireDigit = false; // требуются ли цифры
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>();


            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            services.AddTransient<IRestaurantRepository, EFRestaurantRepository>();
            services.AddTransient<IMakdonaldsRepository, EFMakdonaldsRepository>();
            services.AddTransient<IBurgerKingRepository, EFBurgerKingRepository>();
            services.AddTransient<IDominoPizzaRepository, EFDominoPizzaRepository>();
            services.AddTransient<IKfcRepository, EFKfcRepository>();
            services.AddTransient<IMyBoxRepository, EFMyBoxRepository>();
            services.AddTransient<ISushiBoxRepository, EFSushiBoxRepository>();


            services.AddScoped(sp => SessioпMakdonalds.GetCart(sp));
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

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();
            

            DataRestaurant.EnsurePopulated(app);

        }
    }
}
