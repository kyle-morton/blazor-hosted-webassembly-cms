using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages
{
    public class BlogPostsBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; } 

        [Parameter]
        public int BlogId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (BlogId == 0)
            {
                NavigationManager.NavigateTo("/blogs");
            }
        }
    }
}
