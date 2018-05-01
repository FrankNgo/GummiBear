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

            return View(db.Reviews.Include(reviews => reviews.Item).ToList());
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
    }
}