using BlazorCMS.Web.Services;
using BlazorCMS.Web.Services.Api;
using BlazorCMS.Web.Services.UI;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCMS.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // http client
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/") });

            // UI services
            builder.Services.AddTransient<INotificationService, NotificationService>();
            builder.Services.AddTransient<IBlogPostService, BlogPostService>();
            builder.Services.AddTransient<IBlogService, BlogService>();

            await builder.Build().RunAsync();
        }
    }
}
