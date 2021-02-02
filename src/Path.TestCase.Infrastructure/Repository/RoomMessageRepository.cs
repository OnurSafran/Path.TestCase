using Microsoft.EntityFrameworkCore;
using Path.TestCase.Core.Interfaces.Repository;
using Path.TestCase.Core.Models.Entities;
using Path.TestCase.Infrastructure.Repository.Base;

namespace Path.TestCase.Infrastructure.Repository {
	public class RoomMessageRepository : BaseRepository<RoomMessage>, IRoomMessageRepository {
		public RoomMessageRepository(DbContext context) : base(context) {
		}
	}
}