using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GummiBear.Models
{
    public class EFItemRepository : IItemRepository
    {

        StoreDbContext db = new StoreDbContext();

        public EFItemRepository()
        {
            db = new StoreDbContext();
        }

        public EFItemRepository(StoreDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Item> Items { get { return db.Items; } }

        public Item Save(Item Item)
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

        public void Remove(Item Item)
        {
            db.Items.Remove(Item);
            db.SaveChanges();
        }

        public IQueryable<Review> Reviews { get { return db.Reviews; } }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public void RemoveAll()
        {
            db.Items.RemoveRange(db.Items);
            db.SaveChanges();
        }
    }
}