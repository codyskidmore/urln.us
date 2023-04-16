namespace Url.Api.Services;

public interface IAuthService
{
    Task<bool> Allow(string authToken);
}