using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Library.Client.Schema.Generated;
using Library.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri("https://localhost:6060/") });
            builder.Services.AddHttpClient("LibraryClient", (services, client) =>
            {
                client.BaseAddress = new Uri("https://localhost:6060/graphql");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", services.GetRequiredService<ITokenStore>().GetToken());
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
