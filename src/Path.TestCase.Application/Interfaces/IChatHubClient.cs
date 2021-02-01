using System.Threading.Tasks;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Interfaces {
	public interface IChatHubClient {
		Task ReceiveMessage(MessageResponse messageResponse);
		Task UserEntered(UserResponse userResponse);
		Task UserLeft(UserResponse userResponse);
	}
}