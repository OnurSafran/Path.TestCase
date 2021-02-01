using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Application.Notifications.UserConnectedNotification;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class OnConnectCommandHandler : IRequestHandler<OnConnectCommand, bool> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;

		public OnConnectCommandHandler(IMediator mediator, IChatCacheModule chatCacheModule) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
		}

		public async Task<bool> Handle(OnConnectCommand request, CancellationToken cancellationToken) {
			// Login
			await _chatCacheModule.SetUserAsync(
				new CacheUser() {
					ConnectionId = request.ConnectionId,
					ConnectedRoomId = null,
					DateTime = request.DateTime,
					NickName = request.NickNme
				}, cancellationToken);

			// Publish
			await _mediator.Publish(
				new UserConnectedNotification() {ConnectionId = request.ConnectionId}, cancellationToken);

			return await Task.FromResult(true);
		}
	}
}