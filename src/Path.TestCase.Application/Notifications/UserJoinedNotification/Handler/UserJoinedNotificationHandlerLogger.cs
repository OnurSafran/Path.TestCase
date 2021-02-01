using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.Notifications.UserJoinedNotification.Handler {
	public class UserJoinedNotificationHandlerLogger : INotificationHandler<UserJoinedNotification> {
		public async Task Handle(UserJoinedNotification notification, CancellationToken cancellationToken) {
		}
	}
}