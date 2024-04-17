using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoneDietApp.Controllers;
using NUnit.Framework;
using ZoneDietApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ZoneDietApp.Tests
{
	[TestFixture]
	public class HomeControllerTests
	{
		[Test]
		public void Index_ReturnsViewResult()
		{
			// Arrange
			var controller = new HomeController();

			// Act
			var result = controller.Index();

			// Assert
			Assert.IsInstanceOf<ViewResult>(result);
		}
	}
}
