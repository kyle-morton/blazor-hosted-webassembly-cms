using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Components
{
    public class BlazeButtonBase : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string CssClasses { get; set; } = "btn btn-primary";

        [Parameter]
        public bool Active { get; set; } = false;

        [Parameter]
        public EventCallback OnClick { get; set; }

        public async Task Click()
        {
            // Disregard click if active
            if (Active)
            {
                return;
            }

            await OnClick.InvokeAsync(null);
        }

    }
}
