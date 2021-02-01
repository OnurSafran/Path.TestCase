using MediatR;

namespace Path.TestCase.Application.Notifications.UserDisconnectedNotification {
	public class UserDisconnectedNotification : INotification {
		public string ConnectionId { get; set; }
	}
}