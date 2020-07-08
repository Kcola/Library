using System.Threading.Tasks;

namespace Library.Client.Services
{
    public interface IAuth
    {
        Task Login(string username, string password);
        public bool LoggedIn { get; set; }
    }
}