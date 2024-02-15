using System.ComponentModel.DataAnnotations;
using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Models
{
    public class ProductIndexViewModel
    {
        public int SelectedTypeId { get; set; }
        public IEnumerable<ProductTypeOption> ProductTypes { get; set; } = new List<ProductTypeOption>();
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Product> AllProducts { get; set; } = new List<Product>();
        public string SelectedProductName { get; set; } = null!;
    }
}
