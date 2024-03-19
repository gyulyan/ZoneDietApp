using Microsoft.AspNetCore.Mvc;
using ZoneDietApp.Data.Models;
using ZoneDietApp.Models;

namespace ZoneDietApp.Controllers
{
    public class BlockCalculatorController : Controller
    {
        public IActionResult Index()
        {
            var model = new BlockCalculatorViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(BlockCalculatorViewModel model)
        {
            var result = new BlockCalculatorResult();

            double maxResult = Math.Max(Math.Max(double.Parse(model.Carbohydrat), double.Parse(model.Fat)), double.Parse(model.Protein));

            if (maxResult == double.Parse(model.Carbohydrat))
            {
                result.Carbohydrat = 900 / (double.Parse(model.Carbohydrat) - double.Parse(model.Fibеrs));
                result.MaxResultType = "Carbohydrat";
            }
            else if (maxResult == result.Fat)
            {
                result.Fat = 150 / double.Parse(model.Fat);
                result.MaxResultType = "Fat";
            }
            else
            {
                result.Protein = 700 / double.Parse(model.Protein);
                result.MaxResultType = "Protein";
            }

            result.Weight = double.Parse(model.Weight);
            result.MaxResult = maxResult;

            return View("Result", result);
        }
    }
}
