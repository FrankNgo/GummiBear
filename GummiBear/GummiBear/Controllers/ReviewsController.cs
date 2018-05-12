using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GummiBear.Models;


namespace GummiBear.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly StoreDbContext _context;

        private IReviewRepository ReviewRepo;

        public ReviewsController(StoreDbContext context)
        {
            _context = context;
        }

        public ReviewsController(IReviewRepository ReviewRepo)
        {
            this.ReviewRepo = ReviewRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reviews.ToListAsync());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ReviewId,Author,Content,Rating,ItemId")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(review);
        }


    }
}