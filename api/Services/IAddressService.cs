using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IAddressService
    {
        /// <summary>
        /// Returns address
        /// </summary>
        /// <param name="account">Instance of <see cref="AccountModel"/></param>
        /// <remarks>Currently it is not based on account data</remarks>
        /// <returns>Address</returns>
        Task<string> GetAddress(AccountModel account);
    }
}