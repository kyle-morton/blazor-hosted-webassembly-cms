using BlazorCMS.SharedModels.ViewModels.Blogs;
using BlazorCMS.Web.Services.Api;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Admin.Blogs
{
    public class CreateBase : PageBase
    {
        [Inject]
        protected IBlogService _blogService { get; set; }

        public CreateBlogViewModel Blog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Blog = new CreateBlogViewModel
            {
                Name = "",
                Description = ""
            };
        }

        protected async Task Submit()
        {
            IsProcessing = true;
            var result = await _blogService.CreateAsync(Blog);
            if (result != null)
            {
                await NotificationService.SendMessageAsync("Blog Created");
                NavigationManager.NavigateTo($"/admin/blogs/details/{result.Id}");
            }
            else
            {
                // error message
            }
            IsProcessing = false;
        }

    }
}
