class NoTokenProvider : ITokenProvider
{
    private Camunda8Configuration configuration;

    public NoTokenProvider(Camunda8Configuration configuration)
    {
        this.configuration = configuration;
    }

    Task<string> ITokenProvider.GetToken(String audience)
    {
        return Task.FromResult("");
    }
}
