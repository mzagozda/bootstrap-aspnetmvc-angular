using System.Threading.Tasks;

namespace Services
{
    public interface INotificationService
    {
        Task<bool> SendEmail();
        Task<bool> SendMessage();
    }
}