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
    public class ItemsController : Controller
    {
        private IItemRepository ItemRepository;

        public ItemsController(IItemRepository repository = null)
        {
            if (repository == null)
            {
                this.ItemRepository = new EFItemRepository();
            }
            else
            {
                this.ItemRepository = repository;
            }
        }

        public ViewResult Index()
        {
            return View(ItemRepository.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            Item thisItem = ItemRepository.Items.Include(items => items.Reviews).FirstOrDefault(p => p.ItemId == id);
            return View(thisItem);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            ItemRepository.Save(item);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            Item thisItem = ItemRepository.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            ItemRepository.Edit(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Item thisItem = ItemRepository.Items.FirstOrDefault(items => items.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Item thisItem = ItemRepository.Items.FirstOrDefault(items => items.ItemId == id);
            ItemRepository.Remove(thisItem);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAll()
        {
            return View();
        }
        [HttpPost, ActionName("DeleteAll")]
        public IActionResult DeleteAllConfirmed()
        {
            ItemRepository.RemoveAll();
            return View("Index");
        }
    }
}