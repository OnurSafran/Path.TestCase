using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.Hubs;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Notifications.UserEnteredNotification.Handler {
	public class UserEnteredNotificationHandlerSocket : INotificationHandler<UserEnteredNotification> {
		private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;
		private readonly IMapper _mapper;

		public UserEnteredNotificationHandlerSocket(IHubContext<ChatHub, IChatHubClient> portalHubContext,
			IMapper mapper) {
			_hubContext = portalHubContext;
			_mapper = mapper;
		}

		public async Task Handle(UserEnteredNotification notification, CancellationToken cancellationToken) {
			await _hubContext.Clients.Group(notification.RoomId).UserEntered(_mapper.Map<UserResponse>(notification));
		}
	}
}