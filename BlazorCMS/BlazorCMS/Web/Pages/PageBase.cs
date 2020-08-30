using BlazorCMS.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;

namespace BlazorCMS.Web.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected IUINotificationService NotificationService { get; set; }
    }
}
