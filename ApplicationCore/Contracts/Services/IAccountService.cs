namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        bool Login(string email, string password);
        void Logout();
    }
}