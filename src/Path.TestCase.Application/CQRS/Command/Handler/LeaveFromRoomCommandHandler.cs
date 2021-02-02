using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Application.Notifications.UserLeftNotification;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class LeaveFromRoomCommandHandler : IRequestHandler<LeaveFromRoomCommand, bool> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;

		public LeaveFromRoomCommandHandler(IMediator mediator, IChatCacheModule chatCacheModule) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
		}

		public async Task<bool> Handle(LeaveFromRoomCommand request, CancellationToken cancellationToken) {
			// Get User from Cache
			CacheUser cacheUser = await _chatCacheModule.GetUserAsync(request.ConnectionId, cancellationToken);
			if (cacheUser == null)
				throw new Exception("User doesnt exist. Please login");

			// Set User's Room
			if (cacheUser.ConnectedRoomId == null)
				throw new Exception("User didnt join any room. Please join to a room");

			var userLeftNotification = new UserLeftNotification() {
				NickName = cacheUser.NickName, RoomId = cacheUser.ConnectedRoomId, ConnectionId = request.ConnectionId
			};

			cacheUser.ConnectedRoomId = null;
			await _chatCacheModule.SetUserAsync(cacheUser, cancellationToken);

			// Publish
			await _mediator.Publish(
				userLeftNotification,
				cancellationToken);

			return await Task.FromResult(true);
		}
	}
}