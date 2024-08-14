
using Newtonsoft.Json.Linq;


public class AccessToken(string Token, long DueDate)
{

    public string Token { get; } = Token;
    public long DueDate { get; } = DueDate;    
    public override string ToString()
    {
        return $"{nameof(Token)}: {Token}, {nameof(DueDate)}: {DueDate}";
    }

    public static AccessToken FromJson(string result)
    {
        var jsonResult = JObject.Parse(result);
        var accessToken = (string)jsonResult["access_token"]!;

        var expiresInMilliSeconds = (long)jsonResult["expires_in"]! * 1_000L;
        var dueDate = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + expiresInMilliSeconds;
        var token = new AccessToken(accessToken, dueDate);
        return token;
    }

    public bool IsExpired()
    {
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        return currentTime >= DueDate;
    }
}
