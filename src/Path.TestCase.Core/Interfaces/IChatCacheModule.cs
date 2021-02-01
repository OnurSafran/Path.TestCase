using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Path.TestCase.Core.Models.Cache;

namespace Path.TestCase.Core.Interfaces {
	public interface IChatCacheModule {
		CacheUser GetUser(string connectionId);
		void SetUser(CacheUser cacheUser);
		void RemoveUser(string connectionId);
		bool ExistsUser(string connectionId);

		CacheRoom GetRoom(string roomId);
		void SetRoom(CacheRoom cacheRoom);

		List<CacheRoom> GetActiveRooms();
		void SetActiveRooms(List<CacheRoom> cacheRooms);

		Task<CacheUser> GetUserAsync(string connectionId, CancellationToken cancellationToken);
		Task SetUserAsync(CacheUser cacheUser, CancellationToken cancellationToken);
		Task RemoveUserAsync(string connectionId, CancellationToken cancellationToken);
		Task<bool> ExistsUser(string connectionId, CancellationToken cancellationToken);

		Task<CacheRoom> GetRoomAsync(string roomId, CancellationToken cancellationToken);
		Task SetRoomAsync(CacheRoom cacheRoom, CancellationToken cancellationToken);

		Task<List<CacheRoom>> GetActiveRoomsAsync(CancellationToken cancellationToken);
		Task SetActiveRoomsAsync(List<CacheRoom> cacheRooms, CancellationToken cancellationToken);
	}
}