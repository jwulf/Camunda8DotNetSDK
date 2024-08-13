public class OAuthTokenProvider : IAccessTokenProvider
{
    private Camunda8Configuration configuration;

    private HttpClient httpClient;

    private string clientId;
    private string clientSecret;
    private string authServer;

    public OAuthTokenProvider(Camunda8Configuration configuration)
    {
        this.configuration = configuration;
        httpClient = new HttpClient(new HttpClientHandler(), disposeHandler: false);
        clientId = configuration.ZEEBE_CLIENT_ID;
        clientSecret = configuration.ZEEBE_CLIENT_SECRET;        
        authServer = configuration.CAMUNDA_OAUTH_URL;
    }

    private FormUrlEncodedContent BuildRequestAccessTokenContent(String audience)
    {
        var formContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("audience", audience),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });
        return formContent;
    }

    private async Task<AccessToken> FetchAccessToken(String audience)
    {
        // Requesting the token is similar to this:
        // curl -X POST https://login.cloud.ultrawombat.com/oauth/token \
        //   -H "Content-Type: application/x-www-form-urlencoded"  \
        //   -d "client_id=213131&client_secret=12-23~oU.321&audience=zeebe.ultrawombat.com&grant_type=client_credentials"
        //
        // alternative is json
        //        curl --request POST \
        //        --url https://login.cloud.[ultrawombat.com | camunda.io]/oauth/token \
        //        --header 'content-type: application/json' \
        //        --data '{"client_id":"${clientId}","client_secret":"${clientSecret}","audience":"${audience}","grant_type":"client_credentials"}'

        var formContent = BuildRequestAccessTokenContent(audience);
        var httpResponseMessage = await httpClient.PostAsync(authServer, formContent);

        // Code expects the following result:
        //
        //        {
        //            "access_token":"MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3",
        //            "token_type":"bearer",
        //            "expires_in":3600,
        //            "refresh_token":"IwOGYzYTlmM2YxOTQ5MGE3YmNmMDFkNTVk",
        //            "scope":"create"
        //        }
        //
        // Defined here https://www.oauth.com/oauth2-servers/access-tokens/access-token-response/
        var result = await httpResponseMessage.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        var token = AccessToken.FromJson(result);
        // logger?.LogDebug("Received access token for {Audience}", audience);
        return token;
    }

    public Task<AccessToken> GetToken(String audience)
    {
        return this.FetchAccessToken(audience).ContinueWith(task => task.Result);
    }
}