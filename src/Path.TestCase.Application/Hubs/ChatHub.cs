using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.CQRS.Command;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.Hubs {
	public class ChatHub : Hub<IChatHubClient>, IChatHub {
		private readonly IMediator _mediator;

		public ChatHub(IMediator mediator) {
			_mediator = mediator;
		}

		public async Task SendMessage(string message) {
			await _mediator.Send(new SendMessageCommand() {
				ConnectionId = Context.ConnectionId, Message = message, DateTime = DateTime.Now
			});
		}

		public async Task<CacheRoom> JoinToRoom(string roomId) {
			return await _mediator.Send(new JoinToRoomCommand() {
				ConnectionId = Context.ConnectionId, RoomId = roomId, DateTime = DateTime.Now
			});
		}

		public async Task LeaveFromRoom() {
			await _mediator.Send(new LeaveFromRoomCommand() {
				ConnectionId = Context.ConnectionId, DateTime = DateTime.Now
			});
		}

		public async Task<List<CacheRoom>> OnConnect(string nickName) {
			return await _mediator.Send(new OnConnectCommand() {
				ConnectionId = Context.ConnectionId, NickName = nickName, DateTime = DateTime.Now
			});
		}

		public async Task OnDisconnect() {
			await _mediator.Send(new OnDisconnectCommand() {
				ConnectionId = Context.ConnectionId, DateTime = DateTime.Now
			});
		}
	}
}