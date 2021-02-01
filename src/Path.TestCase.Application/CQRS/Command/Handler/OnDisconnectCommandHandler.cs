using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Application.Notifications.UserDisconnectedNotification;
using Path.TestCase.Core.Interfaces;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class OnDisconnectCommandHandler : IRequestHandler<OnDisconnectCommand, bool> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;

		public OnDisconnectCommandHandler(IMediator mediator, IChatCacheModule chatCacheModule) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
		}

		public async Task<bool> Handle(OnDisconnectCommand request, CancellationToken cancellationToken) {
			// Get User from Cache
			if (!await _chatCacheModule.ExistsUser(request.ConnectionId, cancellationToken))
				throw new Exception("User doesnt exist");

			// Logout
			await _chatCacheModule.RemoveUserAsync(request.ConnectionId, cancellationToken);

			// Publish
			await _mediator.Publish(
				new UserDisconnectedNotification() {ConnectionId = request.ConnectionId}, cancellationToken);

			return await Task.FromResult(true);
		}
	}
}