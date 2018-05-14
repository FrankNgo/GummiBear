using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBear.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        StoreDbContext db = new StoreDbContext();

        public EFReviewRepository()
        {
            db = new StoreDbContext();
        }
        public EFReviewRepository(StoreDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void RemoveAll()
        {
            db.Reviews.RemoveRange(db.Reviews);
            db.SaveChanges();
        }
    }
}