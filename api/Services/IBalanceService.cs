using System.Threading.Tasks;

namespace Services
{
    public interface IBalanceService
    {
        Task<bool> Process(decimal amount, string lastName, bool notify);
    }
}