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
        private IReviewRepository reviewRepository;

        public ReviewsController(IReviewRepository repository = null)
        {
            if (repository == null)
            {
                this.reviewRepository = new EFReviewRepository();
            }
            else
            {
                this.reviewRepository = repository;
            }
        }

        public ViewResult Index()
        {
            return View(reviewRepository.Reviews.ToList());
        }

        public IActionResult Create(int id)
        {
            ViewBag.ItemId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepository.Save(review);
            return RedirectToAction("Details", "Items", new { id = review.ItemId });
        }

        public IActionResult Delete(int id)
        {
            Review thisReview = reviewRepository.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Review thisReview = reviewRepository.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            reviewRepository.Remove(thisReview);
            return RedirectToAction("Details", "Items", new { id = thisReview.ItemId });
        }
    }
}