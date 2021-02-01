using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.Notifications.UserDisconnectedNotification.Handler {
	public class UserDisconnectedNotificationHandlerSocket : INotificationHandler<UserDisconnectedNotification> {
		public async Task Handle(UserDisconnectedNotification notification, CancellationToken cancellationToken) {
			await Task.CompletedTask;
		}
	}
}