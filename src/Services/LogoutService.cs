using System.Threading.Tasks;
using BaseAsyncServices.ServiceBase;
using Microsoft.Extensions.Logging;
using Types.gAuth;

namespace CBMscGAuth.Services
{
    [BaseAsyncServices.Attribute.Service("logout", "Usługa zamykająca sesję użytkownika")]
    public class LogoutService : BaseAsyncService<LogoutCommand>
    {
        private readonly ILogger<LogoutService> _logger;

        public LogoutService(ILogger<LogoutService> logger) : base(logger)
        {
            _logger = logger;
        }

        protected override Task ConsumerHandleAsync(LogoutCommand request)
        {
            _logger.LogInformation("Poprawne wylogowanie użytkownika");
            return Task.CompletedTask;
        }
    }
}