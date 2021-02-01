using MediatR;

namespace Path.TestCase.Application.CQRS.Command {
	public class SendMessageCommand : IRequest<bool> {
		public string ConnectionId { get; set; }
		public string Message { get; set; }
	}
}