using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Library.Shared;

namespace Library.Client.Services
{
    public class Auth : IAuth
    {
        private ITokenStore _tokenStore;
        private HttpClient _httpClient;

        public Auth(HttpClient httpClient, ITokenStore tokenStore)
        {
            _httpClient = httpClient;
            _tokenStore = tokenStore;
        }
        public async Task Login(string username, string password)
        {
            var credentials = new Login
            {
                Username = username,
                Password = password
            };
            Token token;
            var response = await _httpClient.PostAsJsonAsync("/login", credentials);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                token = await response.Content.ReadFromJsonAsync<Token>();
                LoggedIn = true;
                _tokenStore.SetToken(token.Jwt);
            }
        }

        public bool LoggedIn { get; set; } = false;
    }
}