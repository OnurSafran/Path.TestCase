using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.Hubs;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Notifications.UserJoinedNotification.Handler {
	public class UserJoinedNotificationHandlerSocket : INotificationHandler<UserJoinedNotification> {
		private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;
		private readonly IMapper _mapper;

		public UserJoinedNotificationHandlerSocket(IHubContext<ChatHub, IChatHubClient> portalHubContext,
			IMapper mapper) {
			_hubContext = portalHubContext;
			_mapper = mapper;
		}

		public async Task Handle(UserJoinedNotification notification, CancellationToken cancellationToken) {
			// Add To Room Group
			await _hubContext.Groups.AddToGroupAsync(notification.ConnectionId, notification.RoomId, cancellationToken);

			// Send Notification to All
			await _hubContext.Clients.Group(notification.RoomId).UserJoined(_mapper.Map<UserResponse>(notification));
		}
	}
}