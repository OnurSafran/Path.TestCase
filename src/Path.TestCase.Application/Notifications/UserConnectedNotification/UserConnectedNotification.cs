using MediatR;

namespace Path.TestCase.Application.Notifications.UserConnectedNotification {
	public class UserConnectedNotification : INotification {
		public string ConnectionId { get; set; }
	}
}