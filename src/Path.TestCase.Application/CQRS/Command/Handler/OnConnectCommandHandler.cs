using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Application.Notifications.UserConnectedNotification;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class OnConnectCommandHandler : IRequestHandler<OnConnectCommand, List<RoomResponse>> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;
		private readonly IMapper _mapper;

		public OnConnectCommandHandler(IMediator mediator, IChatCacheModule chatCacheModule, IMapper mapper) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
			_mapper = mapper;
		}

		public async Task<List<RoomResponse>> Handle(OnConnectCommand request, CancellationToken cancellationToken) {
			// Login
			await _chatCacheModule.SetUserAsync(
				new CacheUser() {
					ConnectionId = request.ConnectionId,
					ConnectedRoomId = null,
					DateTime = request.DateTime,
					NickName = request.NickNme
				}, cancellationToken);

			// Publish
			await _mediator.Publish(
				new UserConnectedNotification() {ConnectionId = request.ConnectionId}, cancellationToken);

			// Get Room List Then Hide Messages
			var cacheRooms = await _chatCacheModule.GetActiveRoomsAsync(cancellationToken);
			cacheRooms.ForEach(c => c.Messages = null);
			
			return _mapper.Map<List<CacheRoom>, List<RoomResponse>>(cacheRooms);
		}
	}
}