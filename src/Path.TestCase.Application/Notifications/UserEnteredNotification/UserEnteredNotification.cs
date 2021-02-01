using MediatR;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Application.Notifications.UserEnteredNotification {
	public class UserEnteredNotification : INotification {
		public string RoomId { get; set; }
		public User User { get; set; }
	}
}