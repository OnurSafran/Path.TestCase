using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Core.Interfaces.Repository;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Application.Notifications.UserConnectedNotification.Handler {
	public class UserConnectedNotificationHandlerLogger : INotificationHandler<UserConnectedNotification> {
		private readonly IConnectionRepository _connectionRepository;

		public UserConnectedNotificationHandlerLogger(IConnectionRepository connectionRepository) {
			_connectionRepository = connectionRepository;
		}

		public async Task Handle(UserConnectedNotification notification, CancellationToken cancellationToken) {
			await _connectionRepository.CreateAsync(new Connection() {
				Id = Guid.NewGuid(), ConnectionId = notification.ConnectionId, Nickname = notification.NickName
			});
		}
	}
}