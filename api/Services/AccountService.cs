using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Repositories;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IBalanceService _balanceService;


        public AccountService(IAccountRepository accountRepository, IBalanceService balanceService)
        {
            _repository = accountRepository;
            _balanceService = balanceService;
        }

        public async Task<IEnumerable<AccountModel>> GetAccountsAsync()
        {
            return await Task.FromResult(_repository.GetAllAccounts());
        }

        /// <summary>
        /// Returns account type based on account model
        /// </summary>
        /// <remarks>
        /// Account type depends on the Balance value and should change based on the following rules:
        /// * Bronze< 5,000
        /// * Silver> 5,001 and< 10,000
        /// * Gold> 10, 001
        /// Balance 5000, 10000 does not seem to fall into any of the criteria specified.
        /// Those values will return Unknown, which needs fixing the specification
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>Instance of <see cref="AccountType"/></returns>
        public AccountType GetAccountType(AccountModel model)
        {
            const int bronze = 5000;
            const int silver = 10000;

            if (model.Balance > silver + 1)
            {
                return AccountType.Gold;
            }

            if (model.Balance > bronze + 1 && model.Balance < silver)
            {
                return AccountType.Silver;
            }

            if (model.Balance < bronze)
            {
                return AccountType.Bronze;
            }
          
            return AccountType.Other;

        }

        /// <summary>
        /// Persists model in the repository if business conditions are met
        /// </summary>
        /// <param name="model">Instance of <see cref="AccountModel"/></param>
        /// <returns>true on success</returns>

        public async Task<bool> SaveAccountAsync(AccountModel model)
        {
            if (await _balanceService.Process(model.Balance, model.LastName, false) == false) 
                return false;

            return await Task.FromResult(_repository.Add(model));
        }
        
        
    }
}
