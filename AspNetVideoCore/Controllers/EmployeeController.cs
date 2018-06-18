using Microsoft.AspNetCore.Mvc;

namespace AspNetVideoCore.Controllers
{
	[Route("company/[controller]/[action]")]
	public class EmployeeController : Controller
	{
		public string Index()
		{
			return "Hello from Employee";
		}

		public ContentResult Name()
		{
			return Content("Some dude");
		}

		public string Country()
		{
			return "Some country";
		}
	}
}
