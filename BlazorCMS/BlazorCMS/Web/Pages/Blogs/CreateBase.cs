using BlazorCMS.SharedModels.ViewModels.Blogs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Blogs
{
    public class CreateBase : PageBase
    {
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
            var result = await Http.PostAsJsonAsync("Blogs/Create", Blog);
            if (result.IsSuccessStatusCode)
            {
                var createdBlog = await result.Content.ReadFromJsonAsync<BlogViewModel>();
                await NotificationService.SendMessageAsync("Blog Created");
                NavigationManager.NavigateTo($"/Blogs/Details/{createdBlog.Id}");
            }
            else
            {
                // error message
            }
        }

    }
}
