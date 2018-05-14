using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;
using Microsoft.EntityFrameworkCore;
using GummiBear.Models.Repositories;
using System;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBear.Controllers
{
    public class ReviewsController : Controller
    {
        private IItemRepository ItemRepo;
        private IReviewRepository ReviewRepo;

        public ReviewsController(IItemRepository pRepo = null, IReviewRepository rRepo = null)
        {
            ItemRepo = pRepo ?? new EFItemRepository();
            ReviewRepo = rRepo ?? new EFReviewRepository();
        }

        public IActionResult Index(int id)
        {
            List<Review> model = ReviewRepo.Reviews.Where(r => r.ItemId == id).Include(r => r.Item).ToList();
            Item product = ItemRepo.Items.Include(p => p.Reviews).FirstOrDefault(p => p.ItemId == id);
            ViewBag.Item = product;
            return View(model);
        }

        public IActionResult Create(int id)
        {
            ViewBag.Item = ItemRepo.Items.FirstOrDefault(p => p.ItemId == id);
            return View(new Review() { ItemId = id });
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
           
                ReviewRepo.Create(review);
                return RedirectToAction("Index", new { id = review.ItemId });
        }

        //no views for details
        public IActionResult Details(int id)
        {
            var thisReview = ReviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }

        //no views for edit
        public IActionResult Edit(int id)
        {
            var thisReview = ReviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            ReviewRepo.Edit(review);
            return RedirectToAction("Index");
        }

        //no views for delete
        public IActionResult Delete(int id)
        {
            var thisReview = ReviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ReviewRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}