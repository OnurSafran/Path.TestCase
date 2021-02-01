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
		private readonly IHubContext<ChatHub, IChatHubClient> _portalHubContext;
		private readonly IMapper _mapper;

		public UserEnteredNotificationHandlerSocket(IHubContext<ChatHub, IChatHubClient> portalHubContext,
			IMapper mapper) {
			_portalHubContext = portalHubContext;
			_mapper = mapper;
		}

		public async Task Handle(UserEnteredNotification notification, CancellationToken cancellationToken) {
			await _portalHubContext.Clients.All.UserEntered(_mapper.Map<UserResponse>(notification));
		}
	}
}