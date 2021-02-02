using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Infrastructure.Data.Config {
	public class RoomConfiguration : IEntityTypeConfiguration<Room> {
		public void Configure(EntityTypeBuilder<Room> builder) {
			builder
				.HasMany(c => c.Messages)
				.WithOne(ci => ci.Room)
				.HasForeignKey(c => c.RoomId);
		}
	}
}