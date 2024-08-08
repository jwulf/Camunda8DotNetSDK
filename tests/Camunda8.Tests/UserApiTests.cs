using Moq;
using System.Threading.Tasks;
using Xunit;

public class UserApiTests
{
    private readonly Mock<ApiClient> _mockApiClient;
    private readonly UserApi _userApi;

    public UserApiTests()
    {
        _mockApiClient = new Mock<ApiClient>("http://localhost");
        _userApi = new UserApi(_mockApiClient.Object);
    }

    [Fact]
    public async Task GetUserAsync_ReturnsUser()
    {
        // Arrange
        var userId = 1;
        var expectedUser = new User { Id = userId, Name = "John Doe", Email = "john.doe@example.com" };
        _mockApiClient.Setup(x => x.GetAsync<User>($"/users/{userId}"))
            .ReturnsAsync(expectedUser);

        // Act
        var result = await _userApi.GetUserAsync(userId);

        // Assert
        Assert.Equal(expectedUser, result);
    }

    // Add more tests
}
