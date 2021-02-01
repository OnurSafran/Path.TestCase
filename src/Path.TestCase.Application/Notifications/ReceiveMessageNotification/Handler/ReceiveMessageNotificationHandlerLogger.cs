using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.Notifications.ReceiveMessageNotification.Handler {
	public class ReceiveMessageNotificationHandlerLogger : INotificationHandler<ReceiveMessageNotification> {
		public async Task Handle(ReceiveMessageNotification notification, CancellationToken cancellationToken) {
		}
	}
}