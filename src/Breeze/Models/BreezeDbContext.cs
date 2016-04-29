
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Breeze.Models
{
    public class BreezeDbContext : IdentityDbContext<ApplicationUser>
    {


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)

        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Breeze;integrated security = True");
        }



        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
