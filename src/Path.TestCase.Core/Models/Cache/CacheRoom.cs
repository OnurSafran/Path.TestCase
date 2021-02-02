using System;
using System.Collections.Generic;

namespace Path.TestCase.Core.Models.Cache {
	public class CacheRoom {
		public string RoomId { get; set; }
		public string Title { get; set; }
		public List<CacheMessage> Messages { get; set; }
	}
}