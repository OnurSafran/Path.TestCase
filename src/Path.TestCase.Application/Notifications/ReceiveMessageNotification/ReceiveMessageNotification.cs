using MediatR;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Application.Notifications.ReceiveMessageNotification {
	public class ReceiveMessageNotification : INotification {
		public string RoomId { get; set; }
		public string Message { get; set; }
		public User User { get; set; }
	}
}