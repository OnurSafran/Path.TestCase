using System;
using MediatR;

namespace Path.TestCase.Application.CQRS.Command {
	public class EnterToRoomCommand : IRequest<bool> {
		public string ConnectionId { get; set; }
		public string RoomId { get; set; }
		public DateTime DateTime { get; set; }
	}
}