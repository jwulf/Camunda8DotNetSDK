public class OperateApi
{
    private readonly ApiClient _httpClient;
    private readonly Camunda8Configuration _configuration;
    public OperateApi(ApiClient httpClient, Camunda8Configuration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
}