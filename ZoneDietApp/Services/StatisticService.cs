using Microsoft.EntityFrameworkCore;
using ZoneDietApp.Contracts;
using ZoneDietApp.Data.Common;
using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Services
{
	public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;

        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<StatisticServiceModel> TotalAsync()
        {
            int totalRecipes = await repository.AllReadOnly<Recipe>()
                .CountAsync();

            int totalProducts = await repository.AllReadOnly<Product>()
                .CountAsync();

            return new StatisticServiceModel()
            {
                TotalRecipes = totalRecipes,
                TotalProducts = totalProducts
            };
        }
    }
}
