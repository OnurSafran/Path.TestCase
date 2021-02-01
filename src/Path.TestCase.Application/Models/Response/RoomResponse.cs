namespace Path.TestCase.Application.Models.Response {
	public class RoomResponse {
		public string RoomId { get; set; }
		public string RoomTitle { get; set; }
		public MessageResponse[] MessageResponses { get; set; }
	}
}