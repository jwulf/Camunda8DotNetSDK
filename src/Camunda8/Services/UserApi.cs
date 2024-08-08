using System.Threading.Tasks;

public class UserApi
{
    private readonly ApiClient _apiClient;

    public UserApi(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<User> GetUserAsync(int userId)
    {
        return await _apiClient.GetAsync<User>($"/users/{userId}");
    }

    public async Task<User> CreateUserAsync(User user)
    {
        return await _apiClient.PostAsync<User>("/users", user);
    }

    // Add more methods for other operations
}
