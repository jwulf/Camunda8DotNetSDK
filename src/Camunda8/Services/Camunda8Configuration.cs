using System.ComponentModel;

public enum Camunda8AuthStrategy {     
    [Description("BASIC")]
    Basic,
    
    [Description("OAUTH")]
    OAuth,
    
    [Description("NONE")]
    None };
public class Camunda8Configuration
{
    public string CAMUNDA_CUSTOM_USER_AGENT_STRING { get; set; } = String.Empty;
    public bool CAMUNDA_OAUTH_DISABLED { get; set; } = false;
    public string CAMUNDA_OAUTH_URL { get; set; } = String.Empty;
    public string ZEEBE_REST_ADDRESS { get; set; } = "http://localhost:8080";
    public string ZEEBE_CLIENT_ID { get; set; } = String.Empty;
    public string ZEEBE_CLIENT_SECRET { get; set; } = String.Empty;
    public string CAMUNDA_TOKEN_SCOPE { get; set; } = String.Empty;
    public string CAMUNDA_TENANT_ID { get; set; } = String.Empty;
    public string CAMUNDA_ZEEBE_OAUTH_AUDIENCE { get; set; } = "zeebe.camunda.io";
    public string CAMUNDA_OPERATE_OAUTH_AUDIENCE { get; set; } = "operate.camunda.io";
    public string CAMUNDA_TASKLIST_OAUTH_AUDIENCE { get; set; } = "tasklist.camunda.io";
    public string CAMUNDA_OPTIMIZE_OAUTH_AUDIENCE { get; set; } = "optimize.camunda.io";
    public string CAMUNDA_CONSOLE_OAUTH_AUDIENCE { get; set; } = "api.cloud.camunda.io";
    public string CAMUNDA_TOKEN_CACHE_DIR { get; set; } = String.Empty;
    public bool CAMUNDA_TOKEN_DISK_CACHE_DISABLE { get; set; } = false;
    public string CAMUNDA_CUSTOM_ROOT_CERT_PATH { get; set; } = String.Empty;
    public string CAMUNDA_CUSTOM_ROOT_CERT_STRING { get; set; } = String.Empty;
    public string CAMUNDA_CUSTOM_CERT_CHAIN_PATH { get; set; } = String.Empty;
    public string CAMUNDA_CUSTOM_PRIVATE_KEY_PATH { get; set; } = String.Empty;
    public string CAMUNDA_OPERATE_BASE_URL { get; set; } = String.Empty;
    public string CAMUNDA_OPTIMIZE_BASE_URL { get; set; } = String.Empty;
    public string CAMUNDA_TASKLIST_BASE_URL { get; set; } = String.Empty;
    public string CAMUNDA_CONSOLE_BASE_URL { get; set; } = String.Empty;
    public string CAMUNDA_MODELER_BASE_URL { get; set; } = "https://modeler.cloud.camunda.io/api";
    public string CAMUNDA_CONSOLE_CLIENT_ID { get; set; } = String.Empty; 
    public string CAMUNDA_CONSOLE_CLIENT_SECRET { get; set; } = String.Empty; 
    public string CAMUNDA_BASIC_AUTH_USERNAME { get; set; } = String.Empty; 
    public string CAMUNDA_BASIC_AUTH_PASSWORD { get; set; } = String.Empty;  
    public Camunda8AuthStrategy CAMUNDA_AUTH_STRATEGY { get; set; } = Camunda8AuthStrategy.OAuth;
}