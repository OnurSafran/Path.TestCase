using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Application.Notifications.ReceiveMessageNotification;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class SendMessageHandler : IRequestHandler<SendMessageCommand, bool> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;

		public SendMessageHandler(IMediator mediator, IChatCacheModule chatCacheModule) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
		}

		public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken) {
			// Get User from Cache
			CacheUser cacheUser = await _chatCacheModule.GetUserAsync(request.ConnectionId, cancellationToken);
			if (cacheUser == null)
				throw new Exception("User doesnt exist. Please login");

			// Get User's Room from Cache
			if (cacheUser.ConnectedRoomId == null)
				throw new Exception("User didnt join any room. Please join to a room");
			CacheRoom cacheRoom = await _chatCacheModule.GetRoomAsync(cacheUser.ConnectedRoomId, cancellationToken);

			// Set Room Message
			CacheMessage cacheMessage = new CacheMessage() {
				Message = request.Message, DateTime = request.DateTime, SenderNickName = cacheUser.NickName
			};
			cacheRoom.Messages.Add(cacheMessage);
			await _chatCacheModule.SetRoomAsync(cacheRoom, cancellationToken);

			// Publish
			await _mediator.Publish(
				new ReceiveMessageNotification() {
					RoomId = cacheUser.ConnectedRoomId, ConnectionId = request.ConnectionId, CacheMessage = cacheMessage
				},
				cancellationToken);

			return await Task.FromResult(true);
		}
	}
}