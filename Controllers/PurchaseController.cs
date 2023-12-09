//using Microsoft.AspNetCore.Mvc;

//namespace StockApp.Controllers
//{
//    public class PurchaseController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public PurchaseController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            var items = _context.Items.ToList();
//            var stores = _context.Stores.ToList();
//            var itemViewModel = new ItemViewModel
//            {
               
//                Stores = stores
//            };

//            return View(itemViewModel);
//        }

//        [HttpPost]
//        public IActionResult PurchaseItem(int itemId, int storeId, int quantityToPurchase)
//        {
//            var item = _context.Items.Find(itemId);
//            var store = _context.Stores.Find(storeId);

//            if (item == null || store == null)
//            {
//                return BadRequest("Invalid item or store.");
//            }

//            if (item.Quantity < quantityToPurchase)
//            {
//                return BadRequest("Not enough quantity in the store.");
//            }

//            item.Quantity -= quantityToPurchase;
//            store.Items.Add(new PurchaseViewModel
//            {
//                Store = store,
//                Item = item,
//                QuantityToPurchase = quantityToPurchase
//            });

//            _context.SaveChanges();

//            // Return the updated total quantity for the specific item and store
//            var totalQuantity = store.Items.Where(i => i.Item.Id == itemId).Sum(i => i.QuantityToPurchase);
//            return Json(new { TotalQuantity = totalQuantity });
//        }
//    }
//}
