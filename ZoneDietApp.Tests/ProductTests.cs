using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Tests
{
	[TestFixture]
	public class ProductTests
	{
		[Test]
		public void Product_SetAndGetProperties()
		{
			// Arrange
			var product = new Product();

			// Act
			product.Name = "Test Product";
			product.TypeId = 1;

			// Assert
			Assert.AreEqual("Test Product", product.Name);
			Assert.AreEqual(1, product.TypeId);
		}
	}
}