using Microsoft.AspNetCore.Mvc;

namespace Path.TestCase.Api.Controllers {
	[ApiController]
	[ApiVersion("1.0")]
	[Route("Api/V{version:apiVersion}/[controller]")]
	public class RoomController {
	}
}