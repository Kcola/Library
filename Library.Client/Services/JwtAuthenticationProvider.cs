using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Library.Shared;

namespace Library.Client.Services
{
    public class JwtAuthenticationProvider : AuthenticationStateProvider, ILoginService
    {
        private ILocalStorageService _loclStorageService;
        private HttpClient _httpClient;
        private ITokenStore _tokenStore;

        public JwtAuthenticationProvider(ILocalStorageService localStorageService, HttpClient httpClient, ITokenStore tokenStore)
        {
            _tokenStore = tokenStore;
            _httpClient = httpClient;
            _loclStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await _loclStorageService.ClearAsync();
            var loggedin = await _loclStorageService.ContainKeyAsync("jwt");
            if (!loggedin)
                return new AuthenticationState(new ClaimsPrincipal());
            return await BuildAuthenticationState();
        }

        private async Task<AuthenticationState> BuildAuthenticationState()
        {
            var token = await _loclStorageService.GetItemAsync<string>("jwt");
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("/login");

            if (response.StatusCode != HttpStatusCode.OK)
                return new AuthenticationState(new ClaimsPrincipal());

            var reader = await response.Content.ReadFromJsonAsync<Reader>();

            var claims = new[]
            {
                            new Claim("Id", reader.Readerid.ToString()),
                            new Claim("Email", reader.Email),
                            new Claim(ClaimTypes.Name, reader.Firstname),
                            new Claim("LastName", reader.Lastname),
                            new Claim("Address", reader.Address),
                            new Claim("Zipcode", reader.Zipcode),
            };
            var identity = new ClaimsIdentity(claims, "jwt");

            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        public async Task Login(string username, string password)
        {
            var credentials = new Login
            {
                Username = username,
                Password = password
            };
            var response = await _httpClient.PostAsJsonAsync("/login", credentials);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = await response.Content.ReadFromJsonAsync<Token>();
                await _loclStorageService.SetItemAsync("jwt", token.Jwt);
                NotifyAuthenticationStateChanged(BuildAuthenticationState());
            }
        }

        public async Task Logout()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await _loclStorageService.ClearAsync();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }

}
