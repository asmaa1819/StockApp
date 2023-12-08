using System.ComponentModel.DataAnnotations;

namespace StockApp.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }=string.Empty;
        public List<Item> Items { get; set; } = new List<Item>();

    }
}
