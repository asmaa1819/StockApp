using System.ComponentModel.DataAnnotations;

namespace StockApp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }


    }
}
