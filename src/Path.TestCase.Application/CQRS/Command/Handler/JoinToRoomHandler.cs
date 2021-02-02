using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Application.Notifications.UserJoinedNotification;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command.Handler {
	public class JoinToRoomHandler : IRequestHandler<JoinToRoomCommand, RoomResponse> {
		private readonly IMediator _mediator;
		private readonly IChatCacheModule _chatCacheModule;
		private readonly IMapper _mapper;

		public JoinToRoomHandler(IMediator mediator, IChatCacheModule chatCacheModule, IMapper mapper) {
			_mediator = mediator;
			_chatCacheModule = chatCacheModule;
			_mapper = mapper;
		}

		public async Task<RoomResponse> Handle(JoinToRoomCommand request, CancellationToken cancellationToken) {
			// Get User from Cache
			CacheUser cacheUser = await _chatCacheModule.GetUserAsync(request.ConnectionId, cancellationToken);
			if (cacheUser == null)
				throw new Exception("User doesnt exist. Please login");

			// Leave From Previous Room
			if (cacheUser.ConnectedRoomId != null)
				await _mediator.Send(
					new LeaveRoomCommand() {ConnectionId = request.ConnectionId, DateTime = request.DateTime},
					cancellationToken);

			// Update User's Room
			cacheUser.ConnectedRoomId = request.RoomId;
			await _chatCacheModule.SetUserAsync(cacheUser, cancellationToken);

			// Publish
			await _mediator.Publish(
				new UserJoinedNotification() {
					NickName = cacheUser.NickName,
					RoomId = cacheUser.ConnectedRoomId,
					ConnectionId = request.ConnectionId
				}
				, cancellationToken);

			// Get Room
			var cacheRoom = await _chatCacheModule.GetRoomAsync(request.RoomId, cancellationToken);
			
			return _mapper.Map<RoomResponse>(cacheRoom);
		}
	}
}