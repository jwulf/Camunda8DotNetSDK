

public class TokenProviderService
{
    private readonly Camunda8Configuration _configuration;
    private readonly ITokenProvider _tokenProvider;

    public TokenProviderService(Camunda8Configuration configuration)
    {
        _configuration = configuration;
        _tokenProvider = configuration.CAMUNDA_AUTH_STRATEGY switch
        {
            // Camunda8AuthStrategy.Basic => new BasicTokenProvider(configuration),
            Camunda8AuthStrategy.OAuth => new MemoryCache(new DiskCache(configuration, new OAuthTokenProvider(configuration))),
            Camunda8AuthStrategy.None => new NoTokenProvider(configuration),
            _ => throw new ArgumentOutOfRangeException($"CAMUNDA_AUTH_STRATEGY {configuration.CAMUNDA_AUTH_STRATEGY} is not set to a valid value")
        };
    }

    public async Task<string> GetToken(String audience)
    {
        return await _tokenProvider.GetToken(audience);
    }
}
