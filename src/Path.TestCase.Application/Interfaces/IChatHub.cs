using System.Threading.Tasks;

namespace Path.TestCase.Application.Interfaces {
	public interface IChatHub {
		Task SendMessage(string message);

		Task EnterToRoom(string roomId);

		Task LeaveFromRoom();

		Task OnConnect(string nickName);

		Task OnDisconnect();
	}
}