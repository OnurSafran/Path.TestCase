using System.Collections.Generic;
using System.Threading.Tasks;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Interfaces {
	public interface IChatHubClient {
		Task ReceiveMessage(MessageResponse messageResponse);
		Task UserJoined(UserResponse userResponse);
		Task UserLeft(UserResponse userResponse);
		Task GetRoom(RoomResponse roomResponse);
		Task GetRoomList(List<RoomResponse> roomResponses);
	}
}