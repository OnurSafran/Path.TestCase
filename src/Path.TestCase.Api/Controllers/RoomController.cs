using Microsoft.AspNetCore.Mvc;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Api.Controllers {
	[ApiController]
	[ApiVersion("1.0")]
	[Route("Api/V{version:apiVersion}/[controller]")]
	public class RoomController {
		[HttpGet]
		public RoomResponse[] GetRoomList() {
			return new RoomResponse[] {
				new RoomResponse() {
					MessageResponses = new MessageResponse[] { },
					RoomId = "1",
					RoomTitle = "Room1",
					UserResponses = new UserResponse[] { }
				},
				new RoomResponse() {
					MessageResponses = new MessageResponse[] { },
					RoomId = "2",
					RoomTitle = "Room2",
					UserResponses = new UserResponse[] { }
				}
			};
		}

		[HttpGet("{roomId}")]
		public RoomResponse GetRoom(string roomId) {
			return null;
		}
	}
}