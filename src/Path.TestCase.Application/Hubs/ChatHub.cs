using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Path.TestCase.Application.CQRS.Command;
using Path.TestCase.Application.Interfaces;
using Path.TestCase.Core.Interfaces;

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

		public async Task EnterToRoom(string roomId) {
			await _mediator.Send(new EnterToRoomCommand() {
				ConnectionId = Context.ConnectionId, RoomId = roomId, DateTime = DateTime.Now
			});
		}

		public async Task LeaveFromRoom() {
			await _mediator.Send(new LeaveRoomCommand() {ConnectionId = Context.ConnectionId, DateTime = DateTime.Now});
		}

		public async Task OnConnect(string nickName) {
			await _mediator.Send(new OnConnectCommand() {
				ConnectionId = Context.ConnectionId, NickNme = nickName, DateTime = DateTime.Now
			});
		}

		public async Task OnDisconnect() {
			await _mediator.Send(new OnDisconnectCommand() {
				ConnectionId = Context.ConnectionId, DateTime = DateTime.Now
			});
		}
	}
}