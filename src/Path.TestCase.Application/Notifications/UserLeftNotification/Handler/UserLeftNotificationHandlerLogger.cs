using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.Notifications.UserLeftNotification.Handler {
	public class UserLeftNotificationHandlerLogger : INotificationHandler<UserLeftNotification> {
		public async Task Handle(UserLeftNotification notification, CancellationToken cancellationToken) {
		}
	}
}