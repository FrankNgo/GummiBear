using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace GummiBear.Controllers
{
    public class ReviewsController : Controller
    {
        private StoreDbContext db = new StoreDbContext();
        public IActionResult Index()
        {
            //List<Review> model = db.Reviews.ToList();
            //return View(model);
            return View(db.Reviews.Include(reviews => reviews.Item).ToList());
        }

        public IActionResult Details(int id)
        {
            //Review thisReview = db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            var thisReview = db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name");
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisReview = db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            db.Reviews.Remove(thisReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Item()
        {
            return View("../Items/Index");
        }
    }
}