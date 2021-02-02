using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Entities.Base;

namespace Path.TestCase.Core.Models.Entities {
	public class Room : Entity {
		[Required] public string RoomId { get; set; }
		[Required] public string Title { get; set; }
		public List<RoomMessage> Messages { get; set; }
	}
}