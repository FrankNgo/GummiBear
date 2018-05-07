using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GummiBear.Controllers
{
    public class ReviewsController : Controller
    {
        private IItemRepository ItemRepo;
        private IReviewRepository ReviewRepo;
        private IReviewRepository @object;

        public ReviewsController(IItemRepository pRepo = null, IReviewRepository rRepo = null)
        {
            ItemRepo = pRepo ?? new EFItemRepository();
            ReviewRepo = rRepo ?? new EFReviewRepository();
        }

        public ReviewsController(IReviewRepository @object)
        {
            this.@object = @object;
        }

        public IActionResult Index(int id)
        {
            List<Review> model = ReviewRepo.Reviews.Where(r => r.ItemId == id).Include(r => r.Item).ToList();
            Item Item = ItemRepo.Items.Include(p => p.Reviews).FirstOrDefault(p => p.ItemId == id);
            ViewBag.Item = Item;
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
          
            ReviewRepo.Save(review);
            return RedirectToAction("Index", new { id = review.ItemId });

        }

        public object Create()
        {
            throw new NotImplementedException();
        }
    }
}