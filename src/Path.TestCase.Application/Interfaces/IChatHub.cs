using System.Collections.Generic;
using System.Threading.Tasks;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Interfaces {
	public interface IChatHub {
		Task SendMessage(string message);

		Task<RoomResponse> JoinToRoom(string roomId);

		Task LeaveFromRoom();

		Task<List<RoomResponse>> OnConnect(string nickName);

		Task OnDisconnect();
	}
}