using System;
using System.Collections.Generic;
using MediatR;
using Path.TestCase.Application.Models.Response;

namespace Path.TestCase.Application.CQRS.Command {
	public class OnConnectCommand : IRequest<List<RoomResponse>> {
		public string ConnectionId { get; set; }
		public string NickNme { get; set; }
		public DateTime DateTime { get; set; }
	}
}