using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Library.Client.Schema.Generated;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Library.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddHttpClient("LibraryClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:6060/graphql");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJMaWJyYXJ5VG9rZW4iLCJqdGkiOiJmYjMxOTQ0My04NDM5LTQxMTgtODUwMy05OGM4MTI1ZmJkNWYiLCJpYXQiOiIwNy8wNS8yMDIwIDAyOjM0OjA1IiwiSWQiOiIxIiwiRW1haWwiOiJrb2xhd29sZS5jYW1wYmVsbEBnbWFpbC5jb20iLCJGaXJzdE5hbWUiOiJLb2xhd29sZSIsIkxhc3ROYW1lIjoiQ2FtcGJlbGwiLCJBZGRyZXNzIjoiMjUwIENlbnRyYWwgQXZlLCBOZXdhcmssIE5KMDcxMDMiLCJaaXBjb2RlIjoiMDcxMDMiLCJSdHlwZSI6ImFkbWluIiwiZXhwIjoxNTkzOTI3MjQ1LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo1MDAxLyIsImF1ZCI6IkxpYnJhcnkifQ.WUChP6STuWNsebAMVmyJwu051LIy2mTYHXdZLfgQ_kI");
            });
            
            builder.Services.AddLibraryClient();
            
            await builder.Build().RunAsync();
        }
    }
}
