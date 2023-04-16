using Microsoft.Extensions.Options;
using Url.Api.Data;
using Url.Api.Models;

namespace Url.Api.Services;

public class AuthService : IAuthService
{
    public AuthService(IOptions<ConfigOptions> authOptions)
    {
        
    }
    public Task<bool> Allow(string authToken)
    {
        throw new NotImplementedException();
    }
}