using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Path.TestCase.Infrastructure.Interfaces {
	public interface ICacheDatabase {
		Task AddAsync(string key, object value, CancellationToken cancellationToken);

		Task AddAsync(string key, object value, DistributedCacheEntryOptions distributedCacheEntryOptions,
			CancellationToken cancellationToken);

		Task<T> GetAsync<T>(string key, CancellationToken cancellationToken);

		Task<bool> ExistsAsync(string key, CancellationToken cancellationToken);

		Task RemoveAsync(string key, CancellationToken cancellationToken);

		void Add(string key, object value);
		void Add(string key, object value, DistributedCacheEntryOptions distributedCacheEntryOptions);

		T Get<T>(string key);

		bool Exists(string key);

		void Remove(string key);
	}
}