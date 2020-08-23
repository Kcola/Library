using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Library.Client.Generated;
using Library.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Library.Client
{
    public class Program
    {
        private const string BackendUrl = "https://localhost:6060";
        private const string GoogleApiKey = "AIzaSyBtAnGsK3npIDrpwpiD27el55QDdAYtjXc";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(BackendUrl) });
            builder.Services.AddHttpClient("LibraryClient", (services, client) =>
            {
                client.BaseAddress = new Uri($"{BackendUrl}/graphql");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", services.GetRequiredService<ITokenStore>().GetToken());
            });
            builder.Services.AddHttpClient("GoogleBooks", (services, client) =>
            {
                var queryParams = new Dictionary<string, string>() { { "key", GoogleApiKey }, };
                var url = QueryHelpers.AddQueryString($"https://www.googleapis.com/books/v1/volumes", queryParams);
                services.GetRequiredService<ILogger>().LogInformation($"Google Books: :{url}");
                client.BaseAddress = new Uri(url);
            });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddLibraryClient();
            builder.Services.AddSingleton<ITokenStore, TokenStore>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<JwtAuthenticationProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationProvider>(
                provider => provider.GetRequiredService<JwtAuthenticationProvider>());
            builder.Services.AddScoped<ILoginService, JwtAuthenticationProvider>(
                provider => provider.GetRequiredService<JwtAuthenticationProvider>());
            await builder.Build().RunAsync();
        }
    }
}
