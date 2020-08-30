using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using BlazorCMS.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Posts
{
    public class DetailsBase : PageBase
    {

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
                BlogPost = await Http.GetFromJsonAsync<BlogPostViewModel>($"BlogPosts/Details/{Id}");
            }
        }

        protected async Task Submit()
        {
            var result = await Http.PostAsJsonAsync("BlogPosts/Update", BlogPost);
            if (result.IsSuccessStatusCode)
            {
                BlogPost = await result.Content.ReadFromJsonAsync<BlogPostViewModel>();
                await NotificationService.SendMessageAsync("Post Updated");
            }
            else
            {
                await NotificationService.SendMessageAsync("Post Update Failed!", UIMessageType.Error);
            }
        }
        protected async Task Delete()
        {
            var result = await Http.DeleteAsync($"BlogPosts/Delete/{Id}");
            if (result.IsSuccessStatusCode)
            {
                await NotificationService.SendMessageAsync("Posts Deleted");
                NavigationManager.NavigateTo($"/blogs/details/{BlogPost.BlogId}");
            }
        }

    }
}
