﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.Hubs;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.Notifications.ReceiveMessageNotification.Handler {
	public class ReceiveMessageNotificationHandlerSocket : INotificationHandler<ReceiveMessageNotification> {
		private readonly IHubContext<ChatHub, IChatHubClient> _hubContext;

		public ReceiveMessageNotificationHandlerSocket(IHubContext<ChatHub, IChatHubClient> portalHubContext) {
			_hubContext = portalHubContext;
		}

		public async Task Handle(ReceiveMessageNotification notification, CancellationToken cancellationToken) {
			// Send Message To Room Group
			await _hubContext.Clients.Group(notification.RoomId)
				.ReceiveMessage(new MessageResponse() {
					Message = notification.CacheMessage.Message,
					DateTime = notification.CacheMessage.DateTime,
					SenderNickName = notification.CacheMessage.SenderNickName
				});
		}
	}
}