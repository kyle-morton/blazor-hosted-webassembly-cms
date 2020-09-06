using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using BlazorCMS.Web.Services.Api;
using BlazorCMS.Web.Services.UI;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Admin.Posts
{
    public class DetailsBase : PageBase
    {

        [Inject]
        private IBlogPostService _blogPostService { get; set; }

        [Parameter]
        public int Id { get; set; }

        public BlogPostViewModel BlogPost { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id == 0)
            {
                NavigationManager.NavigateTo("/admin/blogs");
            }
            else
            {
                BlogPost = await _blogPostService.GetAsync(Id);
            }
        }

        protected async Task Submit()
        {
            var result = await _blogPostService.UpdateAsync(BlogPost);
            if (result != null)
            {
                BlogPost = result;
                await NotificationService.SendMessageAsync("Post Updated");
            }
            else
            {
                await NotificationService.SendMessageAsync("Post Update Failed!", UIMessageType.Error);
            }
        }
        protected async Task Delete()
        {
            var result = await _blogPostService.DeleteAsync(Id);
            if (result)
            {
                await NotificationService.SendMessageAsync("Posts Deleted");
                NavigationManager.NavigateTo($"/admin/blogs/details/{BlogPost.BlogId}");
            }
            else
            {
                await NotificationService.SendMessageAsync("Post Delete Failed!", UIMessageType.Error);
            }
        }

    }
}
