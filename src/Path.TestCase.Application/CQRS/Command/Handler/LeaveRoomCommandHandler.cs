using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class LeaveRoomCommandHandler : IRequestHandler<LeaveRoomCommand, bool> {
		public async Task<bool> Handle(LeaveRoomCommand request, CancellationToken cancellationToken) {
			// Get User Info

			// await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);

			// Notification User Left

			throw new System.NotImplementedException();
		}
	}
}