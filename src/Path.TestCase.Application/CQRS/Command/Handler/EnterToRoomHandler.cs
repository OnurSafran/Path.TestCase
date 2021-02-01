using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Application.Notifications.UserJoinedNotification;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class EnterToRoomHandler : IRequestHandler<EnterToRoomCommand, bool> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;

		public EnterToRoomHandler(IMediator mediator, IChatCacheModule chatCacheModule) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
		}

		public async Task<bool> Handle(EnterToRoomCommand request, CancellationToken cancellationToken) {
			// Get User from Cache
			CacheUser cacheUser = await _chatCacheModule.GetUserAsync(request.ConnectionId, cancellationToken);
			if (cacheUser == null)
				throw new Exception("User doesnt exist. Please login");

			// Leave From Previous Room
			if (cacheUser.ConnectedRoomId != null)
				await _mediator.Send(
					new LeaveRoomCommand() {ConnectionId = request.ConnectionId, DateTime = request.DateTime},
					cancellationToken);

			// Update User's Room
			cacheUser.ConnectedRoomId = request.RoomId;
			await _chatCacheModule.SetUserAsync(cacheUser, cancellationToken);

			// Publish
			await _mediator.Publish(
				new UserJoinedNotification() {
					NickName = cacheUser.NickName,
					RoomId = cacheUser.ConnectedRoomId,
					ConnectionId = request.ConnectionId
				}
				, cancellationToken);

			// Notification User Entered
			return await Task.FromResult(true);
		}
	}
}