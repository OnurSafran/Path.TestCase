using System;
using System.ComponentModel.DataAnnotations;
using Path.TestCase.Core.Models.Entities.Base;

namespace Path.TestCase.Core.Models.Entities {
	public class RoomMessage : Entity {
		public Connection Connection { get; set; }
		public Guid ConnectionId { get; set; }
		[Required] public string Message { get; set; }
		public Room Room { get; set; }
		public Guid RoomId { get; set; }
	}
}