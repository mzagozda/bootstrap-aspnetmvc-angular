using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Services;

namespace Tests
{
    [TestClass]
    public class BalanceServiceTest
    {
        private BalanceService _balanceService;
        private NotificationService _notificationService;
        private ExternalService _externalService;


        [TestInitialize]
        public void Setup()
        {
            _notificationService = new NotificationService();
            _externalService = new ExternalService();
            _balanceService = new BalanceService(_notificationService, _externalService);
        }

        [TestMethod]
        public void BalanceServiceProcessSuccess()
        {
            AccountModel search = new AccountModel { FirstName = "Gibson", LastName = "Kirk", Balance = 7100 };
            bool result = _balanceService.Process(search.Balance, search.LastName, false).Result;

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BalanceServiceProcessFailure()
        {
            AccountModel search = new AccountModel { FirstName = "Gibson", LastName = "Kirk", Balance = 10001 };
            bool result = _balanceService.Process(search.Balance, search.LastName, false).Result;

            Assert.IsFalse(result);
        }

    }
}
