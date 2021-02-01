using Microsoft.AspNetCore.Mvc;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Api.Controllers {
	[ApiController]
	[ApiVersion("1.0")]
	[Route("Api/V{version:apiVersion}/[controller]")]
	public class RoomController {
	}
}