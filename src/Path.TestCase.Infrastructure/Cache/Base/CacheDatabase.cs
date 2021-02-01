using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Path.TestCase.Infrastructure.Interfaces;

namespace Path.TestCase.Infrastructure.Cache.Base {
	public class CacheDatabase : ICacheDatabase {
		private readonly IDistributedCache _distributedCache;

		public CacheDatabase(IDistributedCache distributedCache) {
			_distributedCache = distributedCache;
		}

		public async Task AddAsync(string key, object value,
			CancellationToken cancellationToken = default(CancellationToken)) {
			var cache = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(value), cancellationToken);

			await _distributedCache.SetAsync(key, Encoding.UTF8.GetBytes(cache), cancellationToken);
		}

		public async Task AddAsync(string key, object value, DistributedCacheEntryOptions distributedCacheEntryOptions,
			CancellationToken cancellationToken = default(CancellationToken)) {
			var cache = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(value), cancellationToken);

			await _distributedCache.SetAsync(key, Encoding.UTF8.GetBytes(cache), cancellationToken);
		}

		public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default(CancellationToken)) {
			var value = await _distributedCache.GetAsync(key, cancellationToken);

			if (value == null)
				return await Task.FromResult(default(T));

			var str = Encoding.UTF8.GetString(value);

			return await Task.Factory.StartNew(
				() => JsonConvert.DeserializeObject<T>(str),
				cancellationToken);
		}

		public async Task<bool> ExistsAsync(string key,
			CancellationToken cancellationToken = default(CancellationToken)) {
			var value = await _distributedCache.GetAsync(key, cancellationToken);

			return await Task.FromResult(value != null);
		}

		public async Task RemoveAsync(string key, CancellationToken cancellationToken = default(CancellationToken)) {
			await _distributedCache.RemoveAsync(key, cancellationToken);
		}

		public void Add(string key, object value) {
			var cache = JsonConvert.SerializeObject(value);

			_distributedCache.Set(key, Encoding.UTF8.GetBytes(cache));
		}

		public void Add(string key, object value, DistributedCacheEntryOptions distributedCacheEntryOptions) {
			throw new System.NotImplementedException();
		}

		public T Get<T>(string key) {
			var value = _distributedCache.Get(key);

			if (value == null)
				return default(T);

			var str = Encoding.UTF8.GetString(value);

			return JsonConvert.DeserializeObject<T>(str);
		}

		public bool Exists(string key) {
			var value = _distributedCache.GetAsync(key);

			return value != null;
		}

		public void Remove(string key) {
			_distributedCache.RemoveAsync(key);
		}
	}
}