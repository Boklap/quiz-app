using StackExchange.Redis;

namespace QuizService.Shared.Utilities;

public static class RedisHelper
{
    public static async Task<string?> GetOrSetStringAsync(
        IDatabase redis,
        string key,
        Func<Task<string?>> fetchFromDbFunc,
        TimeSpan? expiry = null
    )
    {
        var cached = await redis.StringGetAsync(key);

        if (cached.HasValue)
        {
            return cached!;
        }

        var value = await fetchFromDbFunc();

        if (!string.IsNullOrEmpty(value))
        {
            await SetAsync(redis, key, value, expiry);
        }

        return value;
    }
    
    public static async Task SetAsync(
        IDatabase redis,
        string key,
        string value,
        TimeSpan? expiry = null)
    {
        await redis.StringSetAsync(key, value,  expiry ?? TimeSpan.FromHours(24));
    }
}