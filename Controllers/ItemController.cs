using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace StockApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get : All Items
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _context.Items
                .Include(i => i.Store) 
                .ToListAsync();

            var itemViewModels = items.Select(i => new ItemViewModel
            {
                Id = i.ItemId,
                Name = i.Name,
                StoreId = i.StoreId,
                Stores = _context.Stores.ToList() 
            });

            return View(itemViewModels);
        }

        // Get : Create Form
        [HttpGet]
        public IActionResult Create()
        {
            var model = new ItemViewModel
            {
                Stores = _context.Stores.ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = new Item
                {
                    Name = model.Name,
                    StoreId = model.StoreId
                };

                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            model.Stores = _context.Stores.ToList();
            return View(model);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            var model = new ItemViewModel
            {
                Id = item.ItemId,
                Name = item.Name,
                StoreId = item.StoreId,
                Stores = await _context.Stores.ToListAsync()
            };

            return View(model);
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ItemViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var item = new Item
                {
                    ItemId = model.Id,
                    Name = model.Name,
                    StoreId = model.StoreId
                };

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index)); 
            }

            model.Stores = await _context.Stores.ToListAsync();
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var item = await _context.Items.FindAsync(id);

            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();

            return Ok();
        }





    }
}
