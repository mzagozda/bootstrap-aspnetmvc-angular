using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountModel>> GetAccountsAsync();

        Task<bool> SaveAccountAsync(AccountModel model);

        AccountType GetAccountType(AccountModel model);
    }
}