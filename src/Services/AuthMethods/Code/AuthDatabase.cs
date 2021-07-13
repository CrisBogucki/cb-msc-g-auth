using System.Threading.Tasks;
using CBMscGAuth.Services.AuthMethods.Models;
using Messages.gAuth;
using Microsoft.Extensions.Logging;

namespace CBMscGAuth.Services.AuthMethods.Code
{
    public class AuthDatabase : IAuthService
    {
        private const LoginMethod LoginMethod = Models.LoginMethod.DB;
        private readonly ILogger<AuthDatabase> _logger;

        public AuthDatabase(ILogger<AuthDatabase> logger)
        {
            _logger = logger;
        }

        public async Task<UserModel> Login(LoginQuery query, LoginMethod method)
        {
            if (method != LoginMethod) return null;
            
            var user = new UserModel() {Id = 1, Name = "Ana", Last = "Morning"};
            
            _logger.LogInformation("Found user Ana Morning");
            return await Task.FromResult<UserModel>(user);
        }
    }
}