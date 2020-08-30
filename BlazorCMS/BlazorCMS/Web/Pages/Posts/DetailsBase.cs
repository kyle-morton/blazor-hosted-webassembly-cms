using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Posts
{
    public class DetailsBase : PageBase
    {

        [Parameter]
        public int BlogId { get; set; }
        [Parameter]
        public int Id { get; set; }

        public BlogPostViewModel BlogPost { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id == 0)
            {
                NavigationManager.NavigateTo("/blogs");
            }
            else
            {
                BlogPost = await Http.GetFromJsonAsync<BlogPostViewModel>("/BlogPosts");
            }
        }

    }
}
