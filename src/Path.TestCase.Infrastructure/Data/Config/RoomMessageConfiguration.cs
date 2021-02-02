using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Infrastructure.Data.Config {
	public class RoomMessageConfiguration : IEntityTypeConfiguration<RoomMessage> {
		public void Configure(EntityTypeBuilder<RoomMessage> builder) {
		}
	}
}