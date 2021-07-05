using System.Threading.Tasks;
using BaseAsyncServices.ServiceBase;
using Microsoft.Extensions.Logging;
using Types;
using Types.gAuth;

namespace CBMscGAuth.Services
{
    [BaseAsyncServices.Attribute.Service("login", "Usługa do autentykacji użytkownika")]
    public class LoginService : BaseAsyncService<LoginQuery, TokenDto>
    {
        private readonly ILogger<BaseAsyncService<LoginQuery, TokenDto>> _logger;

        public LoginService(ILogger<LoginService> logger) : base(logger)
        {
            _logger = logger;
        }

        protected override async Task<TResponse> ConsumerHandleAsync(LoginQuery request)
        {
            var payload = new TokenDto {Token = "moj_tajny_token", RefreshToken = "moj_tajny_refresh_token"};
            return await Task.FromResult(payload);
        }
    }
}