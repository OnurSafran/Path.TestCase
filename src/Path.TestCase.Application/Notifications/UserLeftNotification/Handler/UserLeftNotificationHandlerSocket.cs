using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.Hubs;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Notifications.UserLeftNotification.Handler {
	public class UserLeftNotificationHandlerSocket : INotificationHandler<UserLeftNotification> {
		private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;

		public UserLeftNotificationHandlerSocket(IHubContext<ChatHub, IChatHubClient> portalHubContext) {
			_hubContext = portalHubContext;
		}

		public async Task Handle(UserLeftNotification notification, CancellationToken cancellationToken) {
			// Remove From Room Group
			await _hubContext.Groups.RemoveFromGroupAsync(notification.ConnectionId, notification.RoomId,
				cancellationToken);

			// Send Notification to All
			await _hubContext.Clients.Group(notification.RoomId)
				.UserLeft(new UserResponse() {Nickname = notification.NickName});
		}
	}
}