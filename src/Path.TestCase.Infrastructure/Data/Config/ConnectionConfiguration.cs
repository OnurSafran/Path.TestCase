using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Path.TestCase.Core.Models.Entities;

namespace Path.TestCase.Infrastructure.Data.Config {
	public class ConnectionConfiguration : IEntityTypeConfiguration<Connection> {
		public void Configure(EntityTypeBuilder<Connection> builder) {
			builder
				.HasMany(c => c.Messages)
				.WithOne(ci => ci.Connection)
				.HasForeignKey(c => c.ConnectionId);
		}
	}
}