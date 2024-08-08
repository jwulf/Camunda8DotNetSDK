using Microsoft.Extensions.Configuration;

public class Camunda8
{
    public OperateApi Operate { get; }

    public Camunda8(Camunda8Configuration? explicitConfiguration = null)
    {
        var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables();
        var environmentConfiguration = builder.Build();
        var configuration = new ConfigurationService(environmentConfiguration, explicitConfiguration);
        Operate = new OperateApi(
            new ApiClient(configuration.Configuration.CAMUNDA_OPERATE_BASE_URL),
            configuration.Configuration
        );
    }
}
