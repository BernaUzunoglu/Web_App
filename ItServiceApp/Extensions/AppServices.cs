using System;
using ItServiceApp.InjectOrnek;
using ItServiceApp.MapperProfiles;
using ItServiceApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ItServiceApp.Extensions
{
    public static class AppServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            ///Mapper işlemi => tipler arası casting işlemini hızlandırır. As ile model dönüşümününü otomatik yapar
            services.AddAutoMapper(options =>
            {
                //Mapper ile eşlenecek modellerin Profileri eklenmek zorundadır.
                options.AddProfile(typeof(AccountProfile));
                options.AddProfile(typeof(PaymentProfile));
            });
            //services.AddScoped<IMyDependency,MyDependency>();
            services.AddScoped<IMyDependency, NewMyDependency>();// Loose coupling - Solid o- polimorhism
            services.AddTransient<IEmailSender, EmailSender>();// Transient ihtiyaç duydukça
            services.AddScoped<IPaymentService, IyzicoPaymentService>();
            


            return services;
        }
    }
}