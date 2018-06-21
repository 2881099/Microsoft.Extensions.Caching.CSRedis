//using Microsoft.Extensions.Caching.Distributed;
//using Newtonsoft.Json;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Microsoft.Extensions.Caching {
//	public class CSRedisCache : IDistributedCache {

//		private CSRedis.CSRedisClient _redisClient;
//		public CSRedisCache(string ip, int port = 6379, string pass = "", int poolsize = 50, int database = 0, string name = "") {
//			_redisClient = new CSRedis.CSRedisClient(ip, port, pass, poolsize, database, name);
//		}

//		private DateTime dt1970 = new DateTime(1970, 1, 1);
//		public byte[] Get(string key) {
//			if (key == null) throw new ArgumentNullException(nameof(key));

//			return _redisClient.GetBytes(key);
//		}
//		async public Task<byte[]> GetAsync(string key, CancellationToken token) {
//			if (key == null) throw new ArgumentNullException(nameof(key));

//			return await _redisClient.GetBytesAsync(key);
//		}

//		public void Set(string key, byte[] value, DistributedCacheEntryOptions options) {
//			if (key == null) throw new ArgumentNullException(nameof(key));
//			if (value == null) throw new ArgumentNullException(nameof(value));
//			if (options == null) throw new ArgumentNullException(nameof(options));

//			var expire = options.AbsoluteExpiration.HasValue ? options.AbsoluteExpirationRelativeToNow.Value : options.SlidingExpiration ?? TimeSpan.FromMinutes(20);
//			_redisClient.SetBytes(key, value, (int) expire.TotalSeconds);
//			_redisClient.HashSet("CSRedisCacheExpire", key, expire.TotalSeconds);
//		}
//		async public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token) {
//			if (key == null) throw new ArgumentNullException(nameof(key));
//			if (value == null) throw new ArgumentNullException(nameof(value));
//			if (options == null) throw new ArgumentNullException(nameof(options));

//			var expire = options.AbsoluteExpiration.HasValue ? options.AbsoluteExpirationRelativeToNow.Value : options.SlidingExpiration ?? TimeSpan.FromMinutes(20);
//			await _redisClient.SetBytesAsync(key, value, (int) expire.TotalSeconds);
//			await _redisClient.HashSetAsync("CSRedisCacheExpire", key, expire.TotalSeconds);
//		}

//		public void Refresh(string key) {
//			if (key == null) throw new ArgumentNullException(nameof(key));
//			//_redisClient.Pool.GetConnection().Client.Eval(;
//			if (long.TryParse(_redisClient.HashGet("CSRedisCacheExpire", key), out long expire) && expire > 0) _redisClient.Expire(key, TimeSpan.FromSeconds(expire));
//		}

//		async public Task RefreshAsync(string key, CancellationToken token) {
//			if (key == null) throw new ArgumentNullException(nameof(key));

//			if (long.TryParse(await _redisClient.HashGetAsync("CSRedisCacheExpire", key), out long expire) && expire > 0) await _redisClient.ExpireAsync(key, TimeSpan.FromSeconds(expire));
//		}
//		public void Remove(string key) {
//			if (key == null) throw new ArgumentNullException(nameof(key));

//			_redisClient.Remove(key.Split('|'));
//		}

//		async public Task RemoveAsync(string key, CancellationToken token) {
//			if (key == null) throw new ArgumentNullException(nameof(key));

//			await _redisClient.RemoveAsync(key.Split('|'));
//		}
//	}
//}
