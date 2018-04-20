using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBear.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBear.Controllers
{
    public class ItemsController : Controller
    {
        private StoreDbContext db = new StoreDbContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Item> model = db.Items.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
    }
}
