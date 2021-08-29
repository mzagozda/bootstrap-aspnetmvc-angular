using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repositories;
using Services;

namespace Tests
{
    [TestClass]
    public class AccountServiceTest
    {
        private AccountRepository _accountRepository;
        private AccountService _accountService;
        private BalanceService _balanceService;
        private NotificationService _notificationService;
        private ExternalService _externalService;

        [TestInitialize]
        public void Setup()
        {
            _accountRepository = new AccountRepository();

            _notificationService = new NotificationService();
            _externalService = new ExternalService();
            _balanceService = new BalanceService(_notificationService, _externalService);
            _accountService = new AccountService(_accountRepository, _balanceService);
        }

        [TestMethod]
        public void GetAllAccounts()
        {
            AccountModel search = new() { FirstName = "Kirk", LastName = "Gibson", Balance = 7100 };
            IEnumerable<AccountModel> result = _accountService.GetAccountsAsync().Result.ToList();

            int count = (from item in result
                         where item.FirstName == search.FirstName && item.LastName == search.LastName && item.Balance == search.Balance
                         select item).Count();

            Assert.AreEqual(1, count);

        }

        [TestMethod]
        public void SaveAccountSuccess()
        {
            AccountModel search = new() { FirstName = "Kirk", LastName = "Gibson", Balance = 10001 };
            bool result = _accountService.SaveAccountAsync(search).Result;

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void SaveAccountFailure()
        {
            AccountModel search = new() { FirstName = "Gibson", LastName = "Kirk", Balance = 10001 };
            bool result = _accountService.SaveAccountAsync(search).Result;

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckAccountTypeBronze()
        {
            AccountModel search = new () { FirstName = "Kirk", LastName = "Gibson", Balance = 100 };
            var result = _accountService.GetAccountType(search);

            Assert.AreEqual(AccountType.Bronze, result);
        }

        [TestMethod]
        public void CheckAccountTypeSilver()
        {
            AccountModel search = new() { FirstName = "Kirk", LastName = "Gibson", Balance = 5002 };
            var result = _accountService.GetAccountType(search);

            Assert.AreEqual(AccountType.Silver, result);
        }

        [TestMethod]
        public void CheckAccountTypeGold()
        {
            AccountModel search = new() { FirstName = "Kirk", LastName = "Gibson", Balance = 10002 };
            var result = _accountService.GetAccountType(search);

            Assert.AreEqual(AccountType.Gold, result);
        }

        [TestMethod]
        public void CheckAccountTypeUnknown()
        {
            AccountModel search = new() { FirstName = "Kirk", LastName = "Gibson", Balance = 5001 };
            var result = _accountService.GetAccountType(search);

            Assert.AreEqual(AccountType.Other, result);
        }
    }
}
