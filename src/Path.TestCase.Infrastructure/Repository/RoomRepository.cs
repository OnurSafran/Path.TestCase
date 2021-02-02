using Microsoft.EntityFrameworkCore;
using Path.TestCase.Core.Interfaces.Repository;
using Path.TestCase.Core.Models.Entities;
using Path.TestCase.Infrastructure.Repository.Base;

namespace Path.TestCase.Infrastructure.Repository {
	public class RoomRepository : BaseRepository<Room>, IRoomRepository {
		public RoomRepository(DbContext context) : base(context) {
		}
	}
}