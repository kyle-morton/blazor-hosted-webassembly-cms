using BlazorCMS.SharedModels.ViewModels.Blogs;
using BlazorCMS.Web.Services;
using BlazorCMS.Web.Services.Api;
using BlazorCMS.Web.Services.UI;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Admin.Blogs
{
    public class DetailsBase : PageBase
    {

        [Parameter]
        public int Id { get; set; }

        [Inject]
        protected IBlogService _blogService { get; set; }

        public BlogViewModel Blog { get; set; }

        public bool IsDeleteProcessing { get; set; }

        public string Title => Blog != null ? $"Details for {Blog.Name}" : "";

        protected override async Task OnInitializedAsync()
        {
            if (Id == 0)
            {
                NavigationManager.NavigateTo("/admin/blogs");
            }
            else
            {
                Blog = await _blogService.GetAsync(Id);
            }
        }

        protected async Task Submit()
        {
            IsProcessing = true;
            var result = await _blogService.UpdateAsync(Blog);
            if (result != null)
            {
                Blog = result;
                await NotificationService.SendMessageAsync("Blog Updated");
            } 
            else
            {
                await NotificationService.SendMessageAsync("Blog Update Failed!", UIMessageType.Error);
            }
            IsProcessing = false;
        }
        protected async Task Delete()
        {
            IsDeleteProcessing = true;
            var result = await _blogService.DeleteAsync(Id);
            if (result)
            {
                await NotificationService.SendMessageAsync("Blog Deleted");
                NavigationManager.NavigateTo("/admin/blogs");
            }
            else
            {
                await NotificationService.SendMessageAsync("Unable to delete blog!", UIMessageType.Error);
            }
            IsDeleteProcessing = false;
        }
    }
}
