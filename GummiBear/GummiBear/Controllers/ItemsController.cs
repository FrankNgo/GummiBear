using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using GummiBear.Models.Repositories;

namespace GummiBear.Controllers
{
    public class ItemsController : Controller
    {
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
            List<Item> model = itemRepo.Items.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            itemRepo.Create(item);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(Items => Items.ItemId == id);
            //thisItem.Reviews = itemRepo.Reviews.Where(Reviews => Reviews.ItemId == id).ToList();
            return View(thisItem);
        }

        public IActionResult Edit(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(Items => Items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item Item)
        {
            itemRepo.Edit(Item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(Items => Items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            itemRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAll()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        public IActionResult DeleteAllItems()
        {
            itemRepo.DeleteAll();
            return RedirectToAction("Index");
        }

    }
}