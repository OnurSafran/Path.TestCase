using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class OnConnectCommandHandler : IRequestHandler<OnConnectCommand, bool> {
		public async Task<bool> Handle(OnConnectCommand request, CancellationToken cancellationToken) {
			throw new System.NotImplementedException();
		}
	}
}