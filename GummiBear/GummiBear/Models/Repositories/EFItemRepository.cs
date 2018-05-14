using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBear.Models.Repositories;
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

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Item Create(Item Item)
        {
            db.Items.Add(Item);
            db.SaveChanges();
            return Item;
        }

        public Item Edit(Item Item)
        {
            db.Entry(Item).State = EntityState.Modified;
            db.SaveChanges();
            return Item;
        }

        public void Delete(int id)
        {
            var thisItem = db.Items.FirstOrDefault(Items => Items.ItemId == id);
            db.Items.Remove(thisItem);
            db.SaveChanges();
        }


        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Items;");
        }
    }
}