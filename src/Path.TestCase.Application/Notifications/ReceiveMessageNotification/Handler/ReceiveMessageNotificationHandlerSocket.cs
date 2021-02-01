using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.Hubs;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Notifications.ReceiveMessageNotification.Handler {
	public class ReceiveMessageNotificationHandlerSocket : INotificationHandler<ReceiveMessageNotification> {
		private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;
		private readonly IMapper _mapper;

		public ReceiveMessageNotificationHandlerSocket(IHubContext<ChatHub, IChatHubClient> portalHubContext,
			IMapper mapper) {
			_hubContext = portalHubContext;
			_mapper = mapper;
		}

		public async Task Handle(ReceiveMessageNotification notification, CancellationToken cancellationToken) {
			await _hubContext.Clients.Group(notification.RoomId).ReceiveMessage(_mapper.Map<MessageResponse>(notification));
		}
	}
}