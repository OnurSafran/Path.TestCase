using System;
using MediatR;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.CQRS.Command {
	public class JoinToRoomCommand : IRequest<RoomResponse> {
		public string ConnectionId { get; set; }
		public string RoomId { get; set; }
		public DateTime DateTime { get; set; }
	}
}