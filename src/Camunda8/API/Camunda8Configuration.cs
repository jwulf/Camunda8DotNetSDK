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
    /** Custom user agent string for the Camunda client */
    public string CAMUNDA_CUSTOM_USER_AGENT_STRING { get; set; } = String.Empty;
    /** The OAuth token exchange endpoint url */
    public string CAMUNDA_OAUTH_URL { get; set; } = String.Empty;
    /** The address for the Zeebe REST API. Defaults to localhost:8080 */
    public string ZEEBE_REST_ADDRESS { get; set; } = "http://localhost:8080";
    /** This is the client ID for the client credentials */
    public string ZEEBE_CLIENT_ID { get; set; } = String.Empty;
    /** This is the client secret for the client credentials */
    public string ZEEBE_CLIENT_SECRET { get; set; } = String.Empty;		
    /** Optional scope parameter for OAuth (needed by some OIDC) */
    public string CAMUNDA_TOKEN_SCOPE { get; set; } = String.Empty;
    /** The tenant id when multi-tenancy is enabled */
    public string CAMUNDA_TENANT_ID { get; set; } = String.Empty;
    /** The audience parameter for a Zeebe OAuth token request. Defaults to zeebe.camunda.io */
    public string CAMUNDA_ZEEBE_OAUTH_AUDIENCE { get; set; } = "zeebe.camunda.io";
    /** The audience parameter for a Operate OAuth token request. Defaults to operate.camunda.io */
    public string CAMUNDA_OPERATE_OAUTH_AUDIENCE { get; set; } = "operate.camunda.io";
    /** The audience parameter for a Tasklist OAuth token request. Defaults to tasklist.camunda.io */
    public string CAMUNDA_TASKLIST_OAUTH_AUDIENCE { get; set; } = "tasklist.camunda.io";
    /** The audience parameter for a Optimize OAuth token request. Defaults to optimize.camunda.io */
    public string CAMUNDA_OPTIMIZE_OAUTH_AUDIENCE { get; set; } = "optimize.camunda.io";
    /** The audience parameter for a Console OAuth token request. Defaults to api.cloud.camunda.io */
    public string CAMUNDA_CONSOLE_OAUTH_AUDIENCE { get; set; } = "api.cloud.camunda.io";
    /** The directory where the token cache is stored. Defaults to $HOME/.camunda */
    public string CAMUNDA_TOKEN_CACHE_DIR { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".camunda");
    /** Disable the token cache */
    public bool CAMUNDA_TOKEN_DISK_CACHE_DISABLE { get; set; } = false;
    /** The path to a custom root certificate */
    public string CAMUNDA_CUSTOM_ROOT_CERT_PATH { get; set; } = String.Empty;
    /** The PEM encoded root certificate */
    public string CAMUNDA_CUSTOM_ROOT_CERT_STRING { get; set; } = String.Empty;
    /** The path to a custom certificate chain */
    public string CAMUNDA_CUSTOM_CERT_CHAIN_PATH { get; set; } = String.Empty;
    /** The path to a custom private key */
    public string CAMUNDA_CUSTOM_PRIVATE_KEY_PATH { get; set; } = String.Empty;
    /** The base URL for the Operate API */
    public string CAMUNDA_OPERATE_BASE_URL { get; set; } = String.Empty;
    /** The base URL for the Optimize API */
    public string CAMUNDA_OPTIMIZE_BASE_URL { get; set; } = String.Empty;
    /** The base URL for the Tasklist API */
    public string CAMUNDA_TASKLIST_BASE_URL { get; set; } = String.Empty;
    /** The base URL for the Console API */
    public string CAMUNDA_CONSOLE_BASE_URL { get; set; } = String.Empty;
    /** The base URL for the Modeler API. Defaults to https://modeler.cloud.camunda.io/api */
    public string CAMUNDA_MODELER_BASE_URL { get; set; } = "https://modeler.cloud.camunda.io/api";
    /** The client ID for the Console API */
    public string CAMUNDA_CONSOLE_CLIENT_ID { get; set; } = String.Empty; 
    /** The client secret for the Console API */
    public string CAMUNDA_CONSOLE_CLIENT_SECRET { get; set; } = String.Empty; 
    /** The username for basic authentication */
    public string CAMUNDA_BASIC_AUTH_USERNAME { get; set; } = String.Empty; 
    /** The password for basic authentication */
    public string CAMUNDA_BASIC_AUTH_PASSWORD { get; set; } = String.Empty;  
    /** The authentication strategy to use. Defaults to OAuth */
    public Camunda8AuthStrategy CAMUNDA_AUTH_STRATEGY { get; set; } = Camunda8AuthStrategy.OAuth;
}