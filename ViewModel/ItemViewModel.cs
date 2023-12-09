using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StockApp.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public int StoreId { get; set; }


        [Display(Name="Store")]
        public List<Store> Stores { get; set; } = new List<Store>();



    }
}
