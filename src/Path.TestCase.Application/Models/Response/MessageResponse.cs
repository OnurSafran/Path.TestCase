using System;

namespace Path.TestCase.Application.Models.Response {
	public class MessageResponse {
		public string SenderNickName { get; set; }
		public string Message { get; set; }
		public DateTime DateTime { get; set; }
	}
}