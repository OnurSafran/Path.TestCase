using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Entities.Base;

namespace Path.TestCase.Core.Models.Entities {
	public class Connection : Entity {
		[Required] public string ConnectionId { get; set; }
		[Required] public string Nickname { get; set; }
		public List<RoomMessage> Messages { get; set; }
	}
}