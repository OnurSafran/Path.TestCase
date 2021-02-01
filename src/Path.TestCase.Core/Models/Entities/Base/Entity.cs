using System;
using System.ComponentModel.DataAnnotations;
using Path.TestCase.Core.Interfaces;

namespace Path.TestCase.Core.Models.Entities.Base {
	public class Entity : IEntity {
		[Key] public Guid Id { get; set; }
	}
}