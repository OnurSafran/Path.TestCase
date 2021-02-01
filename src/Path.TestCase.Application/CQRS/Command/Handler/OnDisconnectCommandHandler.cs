using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class OnDisconnectCommandHandler : IRequestHandler<OnDisconnectCommand, bool> {
		public async Task<bool> Handle(OnDisconnectCommand request, CancellationToken cancellationToken) {
			throw new System.NotImplementedException();
		}
	}
}