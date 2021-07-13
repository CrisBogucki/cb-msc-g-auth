using System.Threading.Tasks;
using BaseAsyncServices.ServiceBase;
using Messages.gAuth;
using Microsoft.Extensions.Logging;

namespace CBMscGAuth
{
    public class RefreshService : BaseAsyncService<LogoutCommand>
    {
        private readonly ILogger<RefreshService> _logger;

        public RefreshService(ILogger<RefreshService> logger) : base(logger)
        {
            _logger = logger;
        }
        
        protected override Task ConsumerHandleAsync(LogoutCommand request)
        {
            throw new System.NotImplementedException();
        }

        
    }
}