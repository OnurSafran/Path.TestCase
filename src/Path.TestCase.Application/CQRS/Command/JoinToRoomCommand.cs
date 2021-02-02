using System;
using MediatR;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command {
	public class JoinToRoomCommand : IRequest<CacheRoom> {
		public string ConnectionId { get; set; }
		public string RoomId { get; set; }
		public DateTime DateTime { get; set; }
	}
}