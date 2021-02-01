using MediatR;

namespace Path.TestCase.Application.CQRS.Command {
	public class OnDisconnectCommand : IRequest<bool> {
		public string ConnectionId { get; set; }
	}
}