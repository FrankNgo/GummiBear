using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GummiBear.Models;

namespace GummiBear.Models
{
    class TestDbContext : StoreDbContext
    {
        public override DbSet<Item> Items { get; set; }
        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummibear_test;uid=root;pwd=root;");
        }
    }
}