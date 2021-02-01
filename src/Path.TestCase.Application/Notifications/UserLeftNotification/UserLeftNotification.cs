using System;
using MediatR;

namespace Path.TestCase.Application.Notifications.UserLeftNotification {
	public class UserLeftNotification : INotification {
		public string ConnectionId { get; set; }
		public string RoomId { get; set; }
		public string NickName { get; set; }
	}
}