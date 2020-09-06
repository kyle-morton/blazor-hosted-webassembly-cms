using BlazorCMS.Web.Services.UI;
using Microsoft.AspNetCore.Components;

namespace BlazorCMS.Web.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected INotificationService NotificationService { get; set; }
    }
}
