using System;
using MediatR;

namespace Path.TestCase.Application.CQRS.Command {
	public class OnConnectCommand : IRequest<bool> {
		public string ConnectionId { get; set; }
		public string NickNme { get; set; }
		public DateTime DateTime { get; set; }
	}
}