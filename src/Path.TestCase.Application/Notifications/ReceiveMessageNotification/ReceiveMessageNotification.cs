using System;
using MediatR;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.Notifications.ReceiveMessageNotification {
	public class ReceiveMessageNotification : INotification {
		public string RoomId { get; set; }
		public CacheMessage CacheMessage { get; set; }
	}
}