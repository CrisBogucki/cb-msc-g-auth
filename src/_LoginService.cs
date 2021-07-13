using System;
using System.Threading.Tasks;
using BaseAsyncServices;
using BaseAsyncServices.ServiceBase;
using CBMscGAuth.Services.AuthMethods;
using CBMscGAuth.Services.AuthMethods.Models;
using Messages;
using Messages.gAuth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CBMscGAuth
{
    [BaseAsyncServices.Attribute.Service("login", "Usługa do autentykacji użytkownika")]
    public class LoginService : BaseAsyncService<LoginQuery, TokenDto>
    {
        private readonly ILogger<BaseAsyncService<LoginQuery, TokenDto>> _logger;
        private readonly ServiceProvider _services;

        public LoginService(ILogger<LoginService> logger, IServiceCollection services) : base(logger)
        {
            _logger = logger;
            _services = services.BuildServiceProvider();
        }

        protected override async Task<TResponse> ConsumerHandleAsync(LoginQuery request)
        {
            var method = (LoginMethod) Enum.Parse(typeof(LoginMethod), Tools.GetAppSettingsValueString("auth", "type"));
            
            _logger.LogInformation($"Logging by method [{method.ToString().ToUpper()}]");

            var authServices = _services.GetServices<IAuthService>();
            foreach (var authService in authServices)
            {
                var userModel = await authService.Login(request, method);
                if (userModel == null) continue;
                _logger.LogInformation("jest user " + userModel.Last);
                var payload = new TokenDto {Token = "moj_tajny_token", RefreshToken = "moj_tajny_refresh_token"};
                return await Task.FromResult(payload);
            }
            
            return await Task.FromResult<TokenDto>(null);
        }

    }
}