using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class EnterToRoomHandler : IRequestHandler<EnterToRoomCommand, bool> {
		public async Task<bool> Handle(EnterToRoomCommand request, CancellationToken cancellationToken) {
			// await LeaveFromRoom(connectionId); mediatR

			// await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

			// Notification User Entered
			throw new System.NotImplementedException();
		}
	}
}