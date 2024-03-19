using System.ComponentModel.DataAnnotations;
using static ZoneDietApp.Data.DataConstants;

namespace ZoneDietApp.Models
{
    public class BlockCalculatorViewModel
    {
        [Range(typeof(decimal),
           NutrientMinimumValue,
           NutrientMaximumValue,
           ConvertValueInInvariantCulture = true,
           ErrorMessage = "Fat must be a positive number and less than {2}")]
        [Display(Name = "Fat Per Product")]
        public decimal Fat { get; set; }

        [Range(typeof(decimal),
           NutrientMinimumValue,
           NutrientMaximumValue,
           ConvertValueInInvariantCulture = true,
           ErrorMessage = "Carbohydrat must be a positive number and less than {2}")]
        [Display(Name = "Carbohydrat Per Product")]
        public decimal Carbohydrat { get; set; }

        [Range(typeof(decimal),
          NutrientMinimumValue,
          NutrientMaximumValue,
          ConvertValueInInvariantCulture = true,
          ErrorMessage = "Fibеrs must be a positive number and less than {2}")]
        [Display(Name = "Fibеrs Per Product")]
        public decimal Fibеrs { get; set; }

        [Range(typeof(decimal),
           NutrientMinimumValue,
           NutrientMaximumValue,
           ConvertValueInInvariantCulture = true,
           ErrorMessage = "Protein must be a positive number and less than {2}")]
        [Display(Name = "Protein Per Product")]
        public decimal Protein { get; set; }

        [Range(typeof(decimal),
           WeightMinimumValue,
           WeightMaximumValue,
           ConvertValueInInvariantCulture = true,
           ErrorMessage = "Weight must be a positive number and less than {2}")]
        [Display(Name = "Weight Per Product")]
        public decimal Weight { get; set; }

    }
}
