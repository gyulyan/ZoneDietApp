using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZoneDietApp.Data;
using ZoneDietApp.Models;

namespace ZoneDietApp.Controllers
{
	public class ProductController : Controller
	{
        private readonly ZoneDbContext dbContext;

        public ProductController(ZoneDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var viewModel = new ProductIndexViewModel
            {
                Products = dbContext.Products.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(ProductIndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Products = dbContext.Products
                    .Include(p => p.Type)
                    .Where(p => p.TypeId == viewModel.SelectedTypeId)
                    .ToList();
            }
            viewModel.ProductTypes = dbContext.ProductTypeOptions.ToList();
            return View(viewModel);
        }
    }
}
