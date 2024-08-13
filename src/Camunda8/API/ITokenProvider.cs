
public interface ITokenProvider
{
    Task<string> GetToken(String audience);
}

public interface IAccessTokenProvider
{
    Task<AccessToken> GetToken(String audience);
}