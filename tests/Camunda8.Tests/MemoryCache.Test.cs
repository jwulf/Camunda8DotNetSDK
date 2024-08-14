public class MemoryCacheTest {
    [Fact]
    public async void TestMemoryCacheEviction() {
        var tokenProvider = new MockTokenProvider(TimeSpan.FromSeconds(3));
        var memoryCache = new MemoryCache(tokenProvider);
        var first = await memoryCache.GetToken("camunda.zeebe.io");
        Assert.Equal("1", first);
        var second = await memoryCache.GetToken("camunda.zeebe.io");
        Assert.Equal("1", second);
        // Wait for 3 seconds
        await Task.Delay(TimeSpan.FromSeconds(4));
        var third = await memoryCache.GetToken("camunda.zeebe.io");
        Assert.Equal("2", third);
    }
}