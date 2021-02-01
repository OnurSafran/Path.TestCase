using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.Hubs;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Notifications.UserLeftNotification.Handler {
	public class UserLeftNotificationHandlerSocket : INotificationHandler<UserLeftNotification> {
		private readonly IHubContext<ChatHub, IChatHubClient> _portalHubContext;
		private readonly IMapper _mapper;

		public UserLeftNotificationHandlerSocket(IHubContext<ChatHub, IChatHubClient> portalHubContext,
			IMapper mapper) {
			_portalHubContext = portalHubContext;
			_mapper = mapper;
		}

		public async Task Handle(UserLeftNotification notification, CancellationToken cancellationToken) {
			await _portalHubContext.Clients.All.UserLeft(_mapper.Map<UserResponse>(notification));
		}
	}
}