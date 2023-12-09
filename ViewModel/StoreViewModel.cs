using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StockApp.ViewModel
{
    public class StoreViewModel
    {
        public int StoreId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
