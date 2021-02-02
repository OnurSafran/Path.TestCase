using System.Collections.Generic;

namespace Path.TestCase.Application.Models.Response {
	public class RoomResponse {
		public string RoomId { get; set; }
		public string Title { get; set; }
		public List<MessageResponse> Messages { get; set; }
	}
}