using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ZoneDietApp.Data.DataConstants;

namespace ZoneDietApp.Data.Models
{
    public class RecipeProduct : Product
    {
        [Required]
        public int TypeQuantity { get; set; }
    }
}
