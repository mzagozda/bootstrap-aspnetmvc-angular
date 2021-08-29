using System.Collections.Generic;
using Models;

namespace Repositories
{
    public interface IAccountRepository
    {
        List<AccountModel> GetAllAccounts();
        bool Add(AccountModel accountModel);
    }
}