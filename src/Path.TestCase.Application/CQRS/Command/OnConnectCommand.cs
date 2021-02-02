using System;
using System.Collections.Generic;
using MediatR;
using Path.TestCase.Application.Models.Response;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Application.CQRS.Command {
	public class OnConnectCommand : IRequest<List<CacheRoom>> {
		public string ConnectionId { get; set; }
		public string NickName { get; set; }
		public DateTime DateTime { get; set; }
	}
}