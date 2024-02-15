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
                Products = dbContext.Products
            .Include(p => p.Type)
            .Include(p => p.ZoneChoiceColor)
            .ToList()
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
                    .Include(p => p.ZoneChoiceColor)
                    .Where(p => p.Name == viewModel.SelectedProductName)
                    .ToList();
            }
            viewModel.ProductTypes = dbContext.ProductTypeOptions.ToList();
            return View(viewModel);
        }

        public async Task<IActionResult> SelectedItem(string selectedProductName)
        {
            var viewModel = new ProductIndexViewModel();
            viewModel.Products = await dbContext.Products
                .Include(p => p.Type)
                .Include(p => p.ZoneChoiceColor)
                .Where(p => p.Name == selectedProductName)
                .ToListAsync();

            viewModel.ProductTypes = dbContext
                .ProductTypeOptions
                .ToList();

            viewModel.AllProducts = dbContext.Products
        .Include(p => p.Type)
        .Include(p => p.ZoneChoiceColor)
        .ToList();

            return View(viewModel);
        }
    }
}
