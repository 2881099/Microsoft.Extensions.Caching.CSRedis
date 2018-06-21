由于 StackExchange.Redis 不可靠，导致 Microsoft.Extensions.Caching.Redis 不能放心使用。故使用 CSRedisCore 作为分布式缓存。

# 使用方法

> Install-Package Caching.CSRedis -Version 2.3.0

```csharp
public void ConfigureServices(IServiceCollection services) {
	var csredis = new azb.BLL.CSRedisClient(ip: "127.0.0.1", port: 6379,  pass: "", poolsize: 50, database: 13, name: "prefix前辍");
	services.AddSingleton<IDistributedCache>(new Microsoft.Extensions.Caching.Redis.CSRedisCache(csredis));
}
```