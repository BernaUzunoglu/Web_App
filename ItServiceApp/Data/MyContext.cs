using ItServiceApp.Models.Entities;
using ItServiceApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItServiceApp.Data
{
    public class MyContext:IdentityDbContext<ApplicationUser,AplicationRole,string>//varsayılan ıd tipi string guid
    {

        public MyContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Deneme> Denemeler { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Subscription>Subscriptions { get; set; }
        public DbSet<SubscriptionType>SubscriptionTypes { get; set; }

        



    }
}
