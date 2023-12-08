using Microsoft.AspNetCore.Mvc;

namespace StockApp.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
