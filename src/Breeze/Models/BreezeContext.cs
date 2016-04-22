using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Breeze.Models
{
    public class BreezeContext : DbContext
    {
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Breeze;integrated security = True");
        }
    }
}