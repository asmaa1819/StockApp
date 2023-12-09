
namespace StockApp.Controllers
{

    public class StoreController : Controller
    {
        private readonly ApplicationDbContext _context;
       

        public StoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GETAll: Store 
        public IActionResult Index()
        {
            var model = _context.Stores
                .Select(s => new StoreViewModel
                {
                    StoreId = s.StoreId,
                    Name = s.Name,
                    Items = s.Items.ToList()
                })
                .ToList();

            return View(model);
        }



        // GET: Store/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var store = new Store
                {
                    Name = model.Name
                };

                _context.Stores.Add(store);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }




        // GET: Store/Edit/ID
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null)
            {
                return NotFound();
            }

            var storeViewModel = new StoreViewModel
            {
                StoreId = store.StoreId,
                Name = store.Name,
                Items = store.Items.ToList()
            };

            return View(storeViewModel);
        }

        // POST: Store/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StoreViewModel model)
        {
            if (id != model.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var store = new Store
                    {
                        StoreId = model.StoreId,
                        Name = model.Name
                    };

                    _context.Stores.Update(store);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreExists(model.StoreId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var store = await _context.Stores.FindAsync(id);

            if (store == null)
                return NotFound();

            _context.Stores.Remove(store);
            _context.SaveChanges();

            return Ok();
        }

        public bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.StoreId == id);
        }
    }
}
