using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GummiBear.Models
{
    public class EFItemRepository : IItemRepository
    {
        StoreDbContext db;
        public EFItemRepository()
        {
            db = new StoreDbContext();
        }
        public EFItemRepository(StoreDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Item> Items
        { get { return db.Items; } }

        public Item Save(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return item;
        }

        public Item Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public void Remove(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
        }

        public void RemoveAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Items;");
        }
    }
}