namespace Camunda8.Tests;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class ConfigurationServiceTest
{
    [Fact]
    public void TestEnvironmentVariableConfiguration()
    {
        var mockEnvironment = new Mock<IConfiguration>();
        mockEnvironment.Setup(e => e.GetValue<string>("ZEEBE_CLIENT_ID"))
            .Returns("test-client-id");
        mockEnvironment.Setup(e => e.GetValue<string>("ZEEBE_CLIENT_SECRET"))
            .Returns("test-client-secret");
        mockEnvironment.Setup(e => e.GetValue<string>("CAMUNDA_AUTH_STRATEGY"))
            .Returns("OAUTH");

        var explicitConfiguration = new Camunda8Configuration();
        explicitConfiguration.CAMUNDA_AUTH_STRATEGY = Camunda8AuthStrategy.None;

        var configuration = new ConfigurationService(mockEnvironment.Object, explicitConfiguration);
        Assert.Equal(Camunda8AuthStrategy.OAuth, configuration.Configuration.CAMUNDA_AUTH_STRATEGY);
        Assert.Equal("test-client-id", configuration.Configuration.ZEEBE_CLIENT_ID);
        Assert.Equal("test-client-secret", configuration.Configuration.ZEEBE_CLIENT_SECRET);
    }
}