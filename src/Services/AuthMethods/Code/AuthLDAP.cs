using System;
using System.Threading.Tasks;
using BaseAsyncServices;
using CBMscGAuth.Services.AuthMethods.Models;
using Messages.gAuth;
using Microsoft.Extensions.Logging;
using Novell.Directory.Ldap;

namespace CBMscGAuth.Services.AuthMethods.Code
{
    public class AuthLdap : IAuthService
    {
        private const LoginMethod LoginMethod = Models.LoginMethod.LDAP;
        private readonly string _ldapServer;
        private readonly ILogger<AuthLdap> _logger;

        public AuthLdap(ILogger<AuthLdap> logger)
        {
            _ldapServer = Tools.GetAppSettingsValueString("auth", "server");
            _logger = logger;
        }

        public async Task<UserModel> Login(LoginQuery query, LoginMethod method)
        {
            if (method != LoginMethod) return null;
            _logger.LogInformation($"Ustawienia Auth -> LDAP-SERVER [{_ldapServer}]");

            try
            {
                var userPn = $"{query.Login}@{_ldapServer}";
                using var connection = new LdapConnection {SecureSocketLayer = false};
                connection.Connect(_ldapServer, LdapConnection.DefaultPort);
                connection.Bind(userPn, query.Password);

                if (connection.Bound)
                {
                    _logger.LogInformation($"Autoryzacja użytkownika [{query.Login.ToUpper()}]");

                    connection.Disconnect();
                    connection.Dispose();

                    return await Task.FromResult<UserModel>(new UserModel(){ });
                }

                connection.Disconnect();
                connection.Dispose();

                _logger.LogInformation($"User [{query.Login.ToUpper()}] not found");
                return await Task.FromResult<UserModel>(null);
            }
            catch (LdapException lexc)
            {
                _logger.LogInformation($"Error for user [{query.Login.ToUpper()}] - {lexc.Message.ToUpper()}");
                return await Task.FromResult<UserModel>(null);
            }
            catch (Exception exc)
            {
                _logger.LogError($"Error for user [{query.Login.ToUpper()}] - {exc.Message}", exc);
                return await Task.FromResult<UserModel>(null);
            }
        }
    }
}