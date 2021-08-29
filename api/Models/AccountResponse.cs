namespace Models
{
    public class AccountResponse: AccountModel
    {

        public AccountType AccountType { get; }
        public string Address { get; }

        /// <summary>
        /// Creates new instance of <see cref="AccountModel"/>
        /// </summary>
        /// <remarks>
        /// This could be refactored, so that address is resolved in constructor, not passed to constructor
        /// </remarks>
        /// <param name="account"></param>
        /// <param name="address"></param>
        /// <param name="type"></param>
        public AccountResponse(AccountModel account, string address, AccountType type)
        {
            FirstName = account.FirstName;
            LastName = account.LastName;
            Balance = account.Balance;
            AccountType = type;
            Address = address;
        }
    }
}