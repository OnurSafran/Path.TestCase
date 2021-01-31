namespace Path.TestCase.Core.Models {
	public class Response<T> : ResponseBase {
		public T Result { get; set; }

		public Response() {
		}

		public Response<T> SetResult(T t) {
			Result = t;

			return this;
		}
	}
}