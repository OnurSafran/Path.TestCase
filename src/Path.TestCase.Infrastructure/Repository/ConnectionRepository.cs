using Microsoft.EntityFrameworkCore;
using Path.TestCase.Core.Interfaces.Repository;
using Path.TestCase.Core.Models.Entities;
using Path.TestCase.Infrastructure.Repository.Base;

namespace Path.TestCase.Infrastructure.Repository {
	public class ConnectionRepository : BaseRepository<Connection>, IConnectionRepository {
		public ConnectionRepository(DbContext context) : base(context) {
		}
	}
}