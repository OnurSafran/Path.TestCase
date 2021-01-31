namespace Path.TestCase.Core.Models {
	public class ResponseBase {
		public string Version { get; set; } = "";
		public int Status { get; set; } = 200;
		public string Message { get; set; } = "";

		public ResponseBase() {
		}

		public ResponseBase SetVersion(string version) {
			Version = version;

			return this;
		}

		public ResponseBase SetStatus(int status) {
			Status = status;

			return this;
		}

		public ResponseBase SetMessage(string message) {
			Message = message;

			return this;
		}
	}
}