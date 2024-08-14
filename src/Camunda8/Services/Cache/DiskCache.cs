using Newtonsoft.Json;
public class DiskCache(Camunda8Configuration configuration, IAccessTokenProvider fallthrough) : IAccessTokenProvider
{

    private readonly Camunda8Configuration configuration = configuration;
    private readonly IAccessTokenProvider fallthrough = fallthrough;
    private readonly string cachePath = configuration.CAMUNDA_TOKEN_CACHE_DIR;
    private readonly bool diskCacheEnabled = !configuration.CAMUNDA_TOKEN_DISK_CACHE_DISABLE;
    public async Task<AccessToken> GetToken(string audience)
{
        string tokenFilePath = Path.Combine(cachePath, $"{configuration.ZEEBE_CLIENT_ID}-{audience}.token");

        if (diskCacheEnabled)
        {

            if (File.Exists(tokenFilePath))
            {
                string json = await File.ReadAllTextAsync(tokenFilePath);
                AccessToken token = JsonConvert.DeserializeObject<AccessToken>(json)!;

                if (token != null && !token.IsExpired())
                {
                    return token;
                }
                else
                {
                    File.Delete(tokenFilePath);
                }
            }
        }

        AccessToken newToken = await fallthrough.GetToken(audience);

        if (diskCacheEnabled) {
            string newTokenJson = JsonConvert.SerializeObject(newToken);
            Directory.CreateDirectory(cachePath);
            await File.WriteAllTextAsync(tokenFilePath, newTokenJson);
        }

        return newToken;
    }
}