using Microsoft.AspNetCore.Mvc;

namespace TestServerPlayground.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : Controller
	{
		[HttpGet]
		public string Get()
		{
			return "Hello, Testers! I am coming from WebApi.";
		}
	}
}
