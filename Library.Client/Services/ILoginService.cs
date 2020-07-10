using System.Threading.Tasks;

public interface ILoginService
{
    Task Login(string username, string password);
    Task Logout();
}
