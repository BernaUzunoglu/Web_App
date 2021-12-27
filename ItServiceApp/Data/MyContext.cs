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
    }
}
