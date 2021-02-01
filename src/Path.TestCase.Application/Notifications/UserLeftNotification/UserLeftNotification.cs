using MediatR;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Application.Notifications.UserLeftNotification {
	public class UserLeftNotification : INotification {
		public string RoomId { get; set; }
		public User User { get; set; }
	}
}