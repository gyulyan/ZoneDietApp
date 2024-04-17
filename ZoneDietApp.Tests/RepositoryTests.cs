using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneDietApp.Data.Models;
using ZoneDietApp.Data;
using ZoneDietApp.Data.Common;

namespace ZoneDietApp.Tests
{
	public class RepositoryTests
	{
		[Test]
		public async Task All_ReturnsCorrectItems()
		{
			// Arrange
			var options = new DbContextOptionsBuilder<ZoneDbContext>()
					.UseSqlServer("Server=C-6LZCHR2\\SQLEXPRESS;Database=ZoneDietApp;Trusted_Connection=True;MultipleActiveResultSets=true")
				.Options;

			var dbContext = new ZoneDbContext(options);
			dbContext.Products.AddRange(new List<Product>
			{
				new Product { Name = "Product 1" },
				new Product { Name = "Product 2" },
				new Product { Name = "Product 3" },
			});
			await dbContext.SaveChangesAsync();

			var repository = new Repository(dbContext);

			// Act
			var result = repository.All<Product>();

			// Assert
			Assert.AreEqual(3, await result.CountAsync());
		}
	}
}
