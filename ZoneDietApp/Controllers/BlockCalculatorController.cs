﻿using Microsoft.AspNetCore.Mvc;
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
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = new BlockCalculatorResult();

            decimal maxResult = Math.Max(Math.Max(model.Carbohydrat, model.Fat), model.Protein);

            if (maxResult == model.Carbohydrat && model.Carbohydrat != 0)
            {
                result.Carbohydrat = 900 / (model.Carbohydrat - model.Fibеrs);
                result.MaxResultType = "Carbohydrat";
            }
            else if (maxResult == result.Fat && model.Fat != 0)
			{
                result.Fat = 150 / model.Fat;
                result.MaxResultType = "Fat";
            }
			else if (maxResult == model.Protein && model.Protein != 0)
			{
				result.Protein = 700 / model.Protein;
				result.MaxResultType = "Protein";
			}
			else
			{
				ModelState.AddModelError("", "Please enter valid values for Carbohydrat, Fat, and Protein.");
				return View(model);
			}

			result.Weight = model.Weight;
            result.MaxResult = maxResult;

            return View("Result", result);
        }
    }
}
