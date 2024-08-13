public class MemoryCache(IAccessTokenProvider fallthrough) : ITokenProvider
{
     private readonly Dictionary<string, AccessToken> _cachedTokens = new();

     private readonly IAccessTokenProvider fallthrough = fallthrough;

     public async Task<string> GetToken(String audience)
     {
          // Check if the cached token for the audience is valid
          if (_cachedTokens.TryGetValue(audience, out var cachedToken) && !cachedToken.IsExpired())
          {
               return cachedToken.Token;
          }

          // If the token is expired or not found, get it from the fallthrough provider
          var newToken = await fallthrough.GetToken(audience);

          // Update the cache with the new token
          _cachedTokens[audience] = newToken;

          // Return the token
          return newToken.Token;
     }
}