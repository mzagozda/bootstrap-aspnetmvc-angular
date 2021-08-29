using System.Collections.Generic;

namespace Services
{
    public class ExternalService : IExternalService
    {
        /// <summary>
        /// List of blacklisted last names.
        /// </summary>
        private readonly List<string> _names = new List<string> { "Rene", "Kirk", "Escarole" };

        /// <summary>
        /// Returns true if balance is valid.
        /// If the person is in the list and balance is greater than 10,000 return false.
        /// </summary>
        /// <param name="amount">amount to be validated</param>
        /// <param name="lastName">last name to be validated</param>
        /// <returns></returns>
        
        public bool CheckAccountBalance(decimal amount, string lastName)
        {
            return !_names.Contains(lastName) || amount <= 10000;
        }
    }
}
