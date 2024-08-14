public class DiskCacheTest
{
    [Fact]
    public async void TestDiskCacheEviction() {
        var tokenProvider = new MockTokenProvider(TimeSpan.FromSeconds(3));
        var configuration = new Camunda8Configuration();
        var cacheDir = Path.Join(Environment.CurrentDirectory, ".camunda");
        configuration.CAMUNDA_TOKEN_CACHE_DIR = cacheDir;
        var diskCache = new DiskCache(configuration, tokenProvider);

         var first = await diskCache.GetToken("camunda.zeebe.io");
        Assert.Equal("1", first.Token);
        var second = await diskCache.GetToken("camunda.zeebe.io");
        Assert.Equal("1", second.Token);
        // Wait for 3 seconds
        await Task.Delay(TimeSpan.FromSeconds(4));
        var third = await diskCache.GetToken("camunda.zeebe.io");
        Assert.Equal("2", third.Token);
        Directory.Delete(cacheDir, true);
    }

    [Fact]
    public async void TestDiskCacheDisable() {
        var tokenProvider = new MockTokenProvider(TimeSpan.FromSeconds(3));
        var configuration = new Camunda8Configuration();
        var cacheDir = Path.Join(Environment.CurrentDirectory, ".camunda");
        configuration.CAMUNDA_TOKEN_CACHE_DIR = cacheDir;
        configuration.CAMUNDA_TOKEN_DISK_CACHE_DISABLE = true;
        var diskCache = new DiskCache(configuration, tokenProvider);

         var first = await diskCache.GetToken("camunda.zeebe.io");
        Assert.Equal("1", first.Token);
        var second = await diskCache.GetToken("camunda.zeebe.io");
        Assert.Equal("2", second.Token);
        var third = await diskCache.GetToken("camunda.zeebe.io");
        Assert.Equal("3", third.Token);
    }
}