using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages
{
    public class BlogsBase : ComponentBase
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
        }

    }
}
