using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Entities;
using Path.TestCase.Infrastructure.Data.Config;

namespace Path.TestCase.Infrastructure.Data {
	public class ChatContext : DbContext {
		public ChatContext(DbContextOptions<ChatContext> options) : base(options) {
		}

		public DbSet<Connection> Connections { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<RoomMessage> RoomMessages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.ApplyConfiguration(new RoomMessageConfiguration());
			modelBuilder.ApplyConfiguration(new ConnectionConfiguration());
			modelBuilder.ApplyConfiguration(new RoomConfiguration());

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken)) {
			SetDefaultValues();
			return base.SaveChangesAsync(cancellationToken);
		}

		public override int SaveChanges() {
			SetDefaultValues();
			return base.SaveChanges();
		}

		private void SetDefaultValues() {
			var modifiedEntries = ChangeTracker.Entries()
				.Where(x => x.State == EntityState.Added);

			foreach (var entry in modifiedEntries) {
				if (entry.Entity is IEntity entity) {
					entity.CreatedAt = DateTime.Now;
					entity.Deleted = false;
				}
			}
		}
	}
}