namespace Camunda8.Tests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Web;
using Xunit;
public class OAuthTokenProviderTest
{
    private IWebHost CreateTestServer()
    {
        return new WebHostBuilder()
         .UseKestrel(options =>
            {
                options.ListenLocalhost(3010); // Bind to localhost:3010
            })
            .ConfigureServices(services => { })
            .Configure(app =>
            {
                app.Run(async context =>
                {
                    if (context.Request.Method == HttpMethods.Post)
                    {
                        // Read the request body
                        using var reader = new StreamReader(context.Request.Body);
                        var requestBody = await reader.ReadToEndAsync();

                        // Parse the URL-encoded request body
                        var parsedBody = HttpUtility.ParseQueryString(requestBody);
                        Assert.Equal("clientId", parsedBody["client_id"]);
                        Assert.Equal("clientSecret", parsedBody["client_secret"]);
                        Assert.Equal("client_credentials", parsedBody["grant_type"]);
                        Assert.Equal("zeebe.camunda.io", parsedBody["audience"]);
                        foreach (var key in parsedBody.AllKeys) ;

                        var response = new { access_token = "dummy_token", scope = "5c34c0a7", expires_in = 61539, token_type = "Bearer" };
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            })
            .Build();
    }

    [Fact]
    public async void TestGetToken()
    {
        using var server = CreateTestServer(); // Start the test server
        await server.StartAsync();
        var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();
        var environmentConfiguration = builder.Build();
        var configuration = environmentConfiguration.Get<Camunda8Configuration>()!;
        // Set the CAMUNDA_OAUTH_URL to the dummy server URL
        configuration.CAMUNDA_OAUTH_URL = "http://localhost:3010";
        configuration.ZEEBE_CLIENT_ID = "clientId";
        configuration.ZEEBE_CLIENT_SECRET = "clientSecret";

        var tokenProvider = new OAuthTokenProvider(configuration);
        var token = await tokenProvider.GetToken(configuration.CAMUNDA_ZEEBE_OAUTH_AUDIENCE);
        Assert.StartsWith("Token: dummy_token, DueDate:", token.ToString());
    }
}
