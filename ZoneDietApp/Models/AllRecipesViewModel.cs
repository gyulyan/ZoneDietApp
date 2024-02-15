using System.ComponentModel.DataAnnotations;
using ZoneDietApp.Data;

namespace ZoneDietApp.Models
{
    public class AllRecipesViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int TotalCarbohydrat { get; set; }

        public int TotalFat { get; set; }

        public int TotalProtein { get; set; }

        public IFormFile Pfp { get; set; } = null!;
    }
}
