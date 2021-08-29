using System.Threading.Tasks;

namespace Services
{
    public class BalanceService : IBalanceService
    {

        private readonly INotificationService _notificationService;
        private readonly IExternalService _externalService;

        public BalanceService(INotificationService notificationService, IExternalService externalService)
        {
            _notificationService = notificationService;
            _externalService = externalService;
        }

        /// <summary>
        /// Processes the amount against the last name and sends appropriate notification
        /// </summary>
        /// <param name="amount">Amount to be processed</param>
        /// <param name="lastName">Last name to be processed</param>
        /// <param name="notify">indicates whether to send notification</param>
        /// <returns></returns>
        public async Task<bool> Process(decimal amount, string lastName, bool notify)
        {
            if (amount < 10000)
            {
                if (notify) await _notificationService.SendEmail();
            }

            if (amount <= 10000) return true;
            
            if (notify) await _notificationService.SendMessage();
            return _externalService.CheckAccountBalance(amount, lastName);

        }

    }

}
