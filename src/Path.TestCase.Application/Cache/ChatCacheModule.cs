using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Path.TestCase.Core.Interfaces;
using Path.TestCase.Core.Models.Cache;
using Path.TestCase.Infrastructure.Interfaces;

namespace Path.TestCase.Application.Cache {
	public class ChatCacheModule : IChatCacheModule {
		private readonly ICacheDatabase _cacheDatabase;
		private const string USER_KEY = "USER_";
		private const string ROOM_KEY = "ROOM_";
		private const string ROOMS_KEY = "ROOMS";
		private const float USER_TIMEOUT_IN_MINUTES = 5;

		public ChatCacheModule(ICacheDatabase cacheDatabase) {
			_cacheDatabase = cacheDatabase;
		}

		public CacheUser GetUser(string connectionId) {
			return _cacheDatabase.Get<CacheUser>(USER_KEY + connectionId);
		}

		public void SetUser(CacheUser cacheUser) {
			_cacheDatabase.Add(USER_KEY + cacheUser.ConnectionId, cacheUser,
				new DistributedCacheEntryOptions() {SlidingExpiration = TimeSpan.FromMinutes(USER_TIMEOUT_IN_MINUTES)});
		}

		public void RemoveUser(string connectionId) {
			_cacheDatabase.Remove(USER_KEY + connectionId);
		}

		public bool ExistsUser(string connectionId) {
			return _cacheDatabase.Exists(USER_KEY + connectionId);
		}

		public CacheRoom GetRoom(string roomId) {
			return _cacheDatabase.Get<CacheRoom>(ROOM_KEY + roomId);
		}

		public void SetRoom(CacheRoom cacheRoom) {
			_cacheDatabase.Add(ROOM_KEY + cacheRoom.RoomId, cacheRoom);
		}

		public List<CacheRoom> GetActiveRooms() {
			return _cacheDatabase.Get<List<CacheRoom>>(ROOMS_KEY);
		}

		public void SetActiveRooms(List<CacheRoom> cacheRooms) {
			_cacheDatabase.Add(ROOMS_KEY, cacheRooms);
		}

		public async Task<CacheUser> GetUserAsync(string connectionId, CancellationToken cancellationToken) {
			return await _cacheDatabase.GetAsync<CacheUser>(USER_KEY + connectionId, cancellationToken);
		}

		public async Task SetUserAsync(CacheUser cacheUser, CancellationToken cancellationToken) {
			await _cacheDatabase.AddAsync(USER_KEY + cacheUser.ConnectionId, cacheUser,
				new DistributedCacheEntryOptions() {SlidingExpiration = TimeSpan.FromMinutes(USER_TIMEOUT_IN_MINUTES)},
				cancellationToken);
		}

		public async Task RemoveUserAsync(string connectionId, CancellationToken cancellationToken) {
			await _cacheDatabase.RemoveAsync(USER_KEY + connectionId, cancellationToken);
		}

		public async Task<bool> ExistsUser(string connectionId, CancellationToken cancellationToken) {
			return await _cacheDatabase.ExistsAsync(USER_KEY + connectionId, cancellationToken);
		}

		public async Task<CacheRoom> GetRoomAsync(string roomId, CancellationToken cancellationToken) {
			return await _cacheDatabase.GetAsync<CacheRoom>(ROOM_KEY + roomId, cancellationToken);
		}

		public async Task SetRoomAsync(CacheRoom cacheRoom, CancellationToken cancellationToken) {
			await _cacheDatabase.AddAsync(ROOM_KEY + cacheRoom.RoomId, cacheRoom, cancellationToken);
		}

		public async Task<List<CacheRoom>> GetActiveRoomsAsync(CancellationToken cancellationToken) {
			return await _cacheDatabase.GetAsync<List<CacheRoom>>(ROOMS_KEY, cancellationToken);
		}

		public async Task SetActiveRoomsAsync(List<CacheRoom> cacheRooms, CancellationToken cancellationToken) {
			await _cacheDatabase.AddAsync(ROOMS_KEY, cacheRooms, cancellationToken);
		}
	}
}