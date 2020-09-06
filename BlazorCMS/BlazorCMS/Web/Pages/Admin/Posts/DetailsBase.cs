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
        public bool IsDeleteProcessing { get; set; }

        public string BackHref => BlogPost != null ? $"/admin/blogs/details/{BlogPost.BlogId}" : "/admin/blogs";

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
            IsProcessing = true;
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
            IsProcessing = false;
        }
        protected async Task Delete()
        {
            IsDeleteProcessing = true;
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
            IsDeleteProcessing = false;
        }

    }
}
