using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestServerPlayground.Services;

namespace TestServerPlayground.Controllers
{
	[Route("api/[controller]")]
	public class SleeperController : Controller
	{
		[HttpGet("{username}")]
		public async Task<IActionResult> Get([FromServices] ISleeperApiClient client, string username)
		{
			return Ok(await client.GetUserAsync(username));
		}
	}
}
