using MediatR;

namespace Path.TestCase.Application.Notifications.UserJoinedNotification {
	public class UserJoinedNotification : INotification {
		public string ConnectionId { get; set; }
		public string RoomId { get; set; }
		public string NickName { get; set; }
	}
}