using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Admin.Posts
{
    public class BlogPostsBase : PageBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int BlogId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (BlogId == 0)
            {
                NavigationManager.NavigateTo("/admin/blogs");
            }
        }
    }
}
