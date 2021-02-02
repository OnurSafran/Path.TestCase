using System.Collections.Generic;
using System.Threading.Tasks;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.Interfaces {
	public interface IChatHub {
		Task SendMessage(string message);

		Task<CacheRoom> JoinToRoom(string roomId);

		Task LeaveFromRoom();

		Task<List<CacheRoom>> OnConnect(string nickName);

		Task OnDisconnect();
	}
}