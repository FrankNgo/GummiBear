using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GummiBear.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummibear;uid=root;pwd=root;");
        }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}