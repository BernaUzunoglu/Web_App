using ItServiceApp.Data;
using ItServiceApp.Extensions;
using ItServiceApp.InjectOrnek;
using ItServiceApp.MapperProfiles;
using ItServiceApp.Models.Identity;
using ItServiceApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ItServiceApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //apsetting.json üzerindeki ayarlarýn konfigürasyonlarýn yapýldýðý kýsým.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            //IoC Container
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            services.AddIdentity<ApplicationUser, AplicationRole>(options=>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(1);
                options.Lockout.AllowedForNewUsers = false;

                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = "qwertyuopasdfghjklizxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM123456789-.+@";
            })
                .AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                //Cokkie Settings
                options.ExpireTimeSpan=TimeSpan.FromMinutes(5);

                options.LoginPath="/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;    

            });

            services.AddApplicationServices(this.Configuration);
            services.AddControllersWithViews();
            //services.AddTransient<EmailSender>();// Bu þekilde yapýlýnca loose coupling olmuyor
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseStaticFiles();//www klasörü içerisindeki yapýlarý kullanmamýzý saðlayan komut css-js vs.
            app.UseHttpsRedirection();//Uygulamamýz http de çalýþþsýn
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("Admin", "Admin", "Admin/{controller=Manage}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(//Controller için default path verme iþlemi
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");// varsayýlan bir rooting oluþturduk.
            });
        }
    }
}
