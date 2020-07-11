using System.Threading.Tasks;

namespace Library.Client.Services
{
    public interface ILoginService
    {
        Task Login(string username, string password);
        Task Logout();
    }
}
