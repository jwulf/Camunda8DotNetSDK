using Microsoft.Extensions.Configuration;

public class ConfigurationService
{
    // private readonly IConfiguration _configuration;
    public Camunda8Configuration Configuration { get; set; }
    public ConfigurationService(IConfiguration environment,Camunda8Configuration? explicitConfiguration = null)
    {

        var baseConfiguration = environment.Get<Camunda8Configuration>()!;

        // Merge explicitConfiguration with baseConfiguration using reflection
        Configuration = MergeConfigurations(baseConfiguration, explicitConfiguration);
    }

    private static Camunda8Configuration MergeConfigurations(Camunda8Configuration baseConfig, Camunda8Configuration? explicitConfig)
    {
        if (explicitConfig == null) return baseConfig;

        var mergedConfig = new Camunda8Configuration();
        var properties = typeof(Camunda8Configuration).GetProperties();

        foreach (var property in properties)
        {
            var explicitValue = property.GetValue(explicitConfig);
            var baseValue = property.GetValue(baseConfig);

            property.SetValue(mergedConfig, 
                explicitValue is string s && string.IsNullOrEmpty(s) ? baseValue : explicitValue ?? baseValue);
        }

        return mergedConfig;
    }
}