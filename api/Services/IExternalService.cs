namespace Services
{
    public interface IExternalService
    {
        bool CheckAccountBalance(decimal amount, string lastName);
    }
}