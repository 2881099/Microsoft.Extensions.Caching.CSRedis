由于 StackExchange.Redis 不可靠，导致 Microsoft.Extensions.Caching.Redis 不能放心使用。故使用 CSRedisCore 作为分布式缓存。

# 使用方法

> Install-Package Caching.CSRedis -Version 2.3.3

## 普通模式

```csharp
var csredis = new CSRedis.CSRedisClient("127.0.0.1:6379,pass=123,defaultDatabase=13,poolsize=50,prefix=key前辍");
services.AddSingleton<IDistributedCache>(new Microsoft.Extensions.Caching.Redis.CSRedisCache(csredis));
```

# 集群模式

```csharp
var csredis = new CSRedis.CSRedisClient(null,
  "127.0.0.1:6371,pass=123,defaultDatabase=11,poolsize=10,prefix=key前辍", 
  "127.0.0.1:6372,pass=123,defaultDatabase=12,poolsize=11,prefix=key前辍",
  "127.0.0.1:6373,pass=123,defaultDatabase=13,poolsize=12,prefix=key前辍",
  "127.0.0.1:6374,pass=123,defaultDatabase=14,poolsize=13,prefix=key前辍");
services.AddSingleton<IDistributedCache>(new Microsoft.Extensions.Caching.Redis.CSRedisCache(csredis));
```

# 批量删除

```csharp
IDistributedCache cache = xxxx;
cache.Remove("key1|key2");
```