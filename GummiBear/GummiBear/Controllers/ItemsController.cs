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
    public class ItemsController : Controller
    {
        private StoreDbContext db = new StoreDbContext();

        private IItemRepository itemRepo;

        public ItemsController(IItemRepository repo = null)
        {
            if (repo == null)
            {
                this.itemRepo = new EFItemRepository();
            }
            else
            {
                this.itemRepo = repo;
            }
        }


         
        public IActionResult Index()
        {
       
            //return View(db.Items.Include(items => items.Reviews).ToList());

            return View(itemRepo.Items.ToList());
        }

        public IActionResult Details(int id)
        {
           
            //var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            //return View(thisItem);

            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            //db.Items.Add(item);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            itemRepo.Save(item);   // Updated
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            //var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            //ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name");
            //return View(thisItem);

            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            //db.Entry(item).State = EntityState.Modified;
            //db.SaveChanges();
            //return RedirectToAction("Index");

            itemRepo.Edit(item);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            //var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            //return View(thisItem);

            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            //var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            //db.Items.Remove(thisItem);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            itemRepo.Remove(thisItem);   // Updated!
            // Removed db.SaveChanges() call
            return RedirectToAction("Index");
        }



    }
}