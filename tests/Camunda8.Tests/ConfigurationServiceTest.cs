namespace Camunda8.Tests;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

public class ConfigurationServiceTest
{
    [Fact]
    public void TestExplicitConfigurationOverridesEnvironmentVariableConfiguration()
    {
        var environmentSettings =
            new Dictionary<string, string?> {
                {"ZEEBE_CLIENT_ID", "test-client-id"},
                {"ZEEBE_CLIENT_SECRET", "test-client-secret"},
                {"CAMUNDA_AUTH_STRATEGY", "OAUTH"}
            };

        IConfiguration environmentConfiguration = new ConfigurationBuilder()
            .AddInMemoryCollection(environmentSettings)
            .Build();

        var explicitConfiguration = new Camunda8Configuration();
        explicitConfiguration.CAMUNDA_AUTH_STRATEGY = Camunda8AuthStrategy.None;

        var configuration = new ConfigurationService(environmentConfiguration, explicitConfiguration);
        Assert.Equal(Camunda8AuthStrategy.None, configuration.Configuration.CAMUNDA_AUTH_STRATEGY);
        Assert.Equal("test-client-id", configuration.Configuration.ZEEBE_CLIENT_ID);
        Assert.Equal("test-client-secret", configuration.Configuration.ZEEBE_CLIENT_SECRET);
    }
}