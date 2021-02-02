using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Path.TestCase.Core.Interfaces.Repository;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Application.Notifications.ReceiveMessageNotification.Handler {
	public class ReceiveMessageNotificationHandlerLogger : INotificationHandler<ReceiveMessageNotification> {
		private readonly IRoomRepository _roomRepository;
		private readonly IRoomMessageRepository _roomMessageRepository;
		private readonly IConnectionRepository _connectionRepository;

		public ReceiveMessageNotificationHandlerLogger(IRoomMessageRepository roomMessageRepository,
			IConnectionRepository connectionRepository, IRoomRepository roomRepository) {
			_roomMessageRepository = roomMessageRepository;
			_connectionRepository = connectionRepository;
			_roomRepository = roomRepository;
		}

		public async Task Handle(ReceiveMessageNotification notification, CancellationToken cancellationToken) {
			var room = await _roomRepository.FirstOrDefaultAsync(r => r.RoomId == notification.RoomId);

			var connection =
				await _connectionRepository.FirstOrDefaultAsync(r => r.ConnectionId == notification.ConnectionId);

			await _roomMessageRepository.CreateAsync(new RoomMessage() {
				Id = Guid.NewGuid(),
				Message = notification.CacheMessage.Message,
				RoomId = room.Id,
				ConnectionId = connection.Id
			});
		}
	}
}