using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.Notifications.UserConnectedNotification.Handler {
	public class UserConnectedNotificationHandlerSocket : INotificationHandler<UserConnectedNotification> {
		public async Task Handle(UserConnectedNotification notification, CancellationToken cancellationToken) {
			await Task.CompletedTask;
		}
	}
}