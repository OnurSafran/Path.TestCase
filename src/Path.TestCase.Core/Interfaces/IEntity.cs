using System;

namespace Path.TestCase.Core.Interfaces {
	public interface IEntity {
		Guid Id { get; set; }
		bool Deleted { get; set; }
		DateTime CreatedAt { get; set; }
	}
}