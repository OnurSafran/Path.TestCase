using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Application.Notifications.ReceiveMessageNotification;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class SendMessageHandler : IRequestHandler<SendMessageCommand, bool> {
		private readonly IMediator _mediator;

		public SendMessageHandler(IMediator mediator) {
			_mediator = mediator;
		}

		public async Task<bool> Handle(SendMessageCommand request, CancellationToken cancellationToken) {
			// If User exists. Redis. Get User Room, Get User Nickname
			// Error kullanıcı odada değil

			// Redis Insert

			// Publish Notification --> hub
			// Publish Notification --> db log

			// Send Notification
			await _mediator.Publish(
				new ReceiveMessageNotification() {Message = request.Message, User = null, RoomId = ""},
				cancellationToken);

			return await Task.FromResult(true);
		}
	}
}