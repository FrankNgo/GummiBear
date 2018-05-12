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

        private readonly StoreDbContext _context;

        public ItemsController(StoreDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(m => m.ItemId == id);
            return View(item);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ItemId,Name,Cost,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(m => m.ItemId == id);
            return View(item);
        }

        [HttpPost]  
        public async Task<IActionResult> Edit(int id, [Bind("GummiId,Name,Cost,Description")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                        throw;
                   
                }
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int? id)
        {    
            var item = await _context.Items.SingleOrDefaultAsync(m => m.ItemId == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.SingleOrDefaultAsync(m => m.ItemId == id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAll(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult DeleteAll()
        {
            List<Item> allItems = itemRepo.Items.ToList();
            foreach (var item in allItems)
            {
                itemRepo.Remove(item);
            }
            return RedirectToAction("Index");
        }

    }
}