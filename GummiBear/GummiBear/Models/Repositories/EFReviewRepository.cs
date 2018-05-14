using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GummiBear.Models.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        StoreDbContext db;
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

        public IQueryable<Item> Items
        { get { return db.Items; } }

        public Review Create(Review Review)
        {
            db.Reviews.Add(Review);
            db.SaveChanges();
            return Review;
        }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Delete(int id)
        {
            Review thisReview = db.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            db.Reviews.Remove(thisReview);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Reviews;");
        }

    }
}