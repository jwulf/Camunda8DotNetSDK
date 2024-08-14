public class MockTokenProvider (TimeSpan validPeriod) : IAccessTokenProvider
{
    private readonly TimeSpan validPeriod = validPeriod;
    private int count = 0;
    public Task<AccessToken> GetToken(string audience)
    {
        count++;
        var then = DateTimeOffset.UtcNow.Add(validPeriod).ToUnixTimeMilliseconds();
       
        return Task.FromResult(new AccessToken(count.ToString(), then));
    }
}