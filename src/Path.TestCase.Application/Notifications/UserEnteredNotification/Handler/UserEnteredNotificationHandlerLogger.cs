using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.Notifications.UserEnteredNotification.Handler {
	public class UserEnteredNotificationHandlerLogger : INotificationHandler<UserEnteredNotification> {
		public async Task Handle(UserEnteredNotification notification, CancellationToken cancellationToken) {
		}
	}
}