namespace ZoneDietApp.Data.Models
{
    public class BlockCalculatorResult
    {
        public double Fat { get; set; } 
        public double Carbohydrat { get; set; } 
        public double Fibеrs { get; set; } 
        public double Protein { get; set; }
        public double Weight { get; set; }
        public double MaxResult { get; set; }
        public string MaxResultType { get; set; } = string.Empty;
    }
}
