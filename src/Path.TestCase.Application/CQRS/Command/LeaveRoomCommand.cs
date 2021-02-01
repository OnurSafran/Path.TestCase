using System;
using MediatR;

namespace Path.TestCase.Application.CQRS.Command {
	public class LeaveRoomCommand : IRequest<bool> {
		public string ConnectionId { get; set; }
		public DateTime DateTime { get; set; }
	}
}