using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Application.Notifications.UserConnectedNotification;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class OnConnectCommandHandler : IRequestHandler<OnConnectCommand, List<CacheRoom>> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;

		public OnConnectCommandHandler(IMediator mediator, IChatCacheModule chatCacheModule) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
		}

		public async Task<List<CacheRoom>> Handle(OnConnectCommand request, CancellationToken cancellationToken) {
			// Login
			await _chatCacheModule.SetUserAsync(
				new CacheUser() {
					ConnectionId = request.ConnectionId,
					ConnectedRoomId = null,
					DateTime = request.DateTime,
					NickName = request.NickName
				}, cancellationToken);

			// Publish
			await _mediator.Publish(
				new UserConnectedNotification() {ConnectionId = request.ConnectionId, NickName = request.NickName}, cancellationToken);

			// Get Room List Then Hide Messages
			List<CacheRoom> cacheRooms = await _chatCacheModule.GetActiveRoomsAsync(cancellationToken);
			cacheRooms.ForEach(c => c.Messages = new List<CacheMessage>());

			return cacheRooms;
		}
	}
}