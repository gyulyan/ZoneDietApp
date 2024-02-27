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

            result.Carbohydrat = 900/double.Parse(model.Carbohydrat) - double.Parse(model.Fibеrs);
            result.Fat = 150/double.Parse(model.Fat);
            result.Protein = 700/double.Parse(model.Protein);
            result.Weight = double.Parse(model.Weight);

            return View("Result", result);
        }
    }
}
