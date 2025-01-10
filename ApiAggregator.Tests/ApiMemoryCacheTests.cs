using ApiAggregator.Service.Internal.Caching;

namespace ApiAggregator.Tests
{
    public class ApiMemoryCacheTests
    {
        [Fact]
        public void DefaultZeroInit()
        {
            var key = "key1";
            var value = "value1";
            var expiration = TimeSpan.FromSeconds(0);

            var cache = new ApiMemoryCache(expiration);
            cache.Set(key, value);

            cache.Check(key, out string? valueFromMemory);
            Assert.Equal(value, valueFromMemory);
        }

        [Fact]
        public void Expiration()
        {
            var key = "key1";
            var value = "value1";
            var expiration = TimeSpan.FromSeconds(3);

            var cache = new ApiMemoryCache(expiration);
            cache.Set(key, value);

            cache.Check(key, out string? valueFromMemory);
            Assert.Equal(value, valueFromMemory);

            Thread.Sleep(expiration);
            cache.Check(key, out valueFromMemory);
            Assert.True(string.IsNullOrEmpty(valueFromMemory));
        }
    }
}