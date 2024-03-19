using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoneDietApp.Data.Models
{
    public class BlockCalculatorResult
    {
        [Comment("Fat blocks")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fat { get; set; }

        [Comment("Carbohydrat blocks")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Carbohydrat { get; set; }

        [Comment("Fibеrs blocks")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fibеrs { get; set; }

        [Comment("Protein blocks")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Protein { get; set; }

        [Comment("Weight of the product")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }

        [Comment("MaxResult between the nutrients")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MaxResult { get; set; }

        [Comment("MaxResult Type")]
        public string MaxResultType { get; set; } = string.Empty;
    }
}
