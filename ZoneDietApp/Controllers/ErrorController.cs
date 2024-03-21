using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ZoneDietApp.Controllers
{
	public class ErrorController : Controller
	{
		[HttpGet("/error")]
		public IActionResult Error(int? statusCode = null)
		{
			if (statusCode.HasValue)
			{
				// here is the trick
				this.HttpContext.Response.StatusCode = statusCode.Value;
				switch (statusCode)
				{
					case 404:
						ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
						return View("NotFound");
				}
			}

			return View("BadRequest");
		}
	}
}
