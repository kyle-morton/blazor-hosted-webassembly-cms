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
        }
        protected async Task Delete()
        {
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
        }
    }
}
