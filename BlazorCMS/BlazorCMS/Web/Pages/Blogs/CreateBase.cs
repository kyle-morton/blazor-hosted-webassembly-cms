using BlazorCMS.SharedModels.ViewModels.Blogs;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Blogs
{
    public class CreateBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        public CreateBlogViewModel Blog { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Blog = new CreateBlogViewModel
            {
                Name = "",
                Description = ""
            };
        }

        protected async Task HandleValidSubmit()
        {
            var result = await Http.PostAsJsonAsync("Blogs/Create", Blog);
            if (result.IsSuccessStatusCode)
            {
                var createdBlog = await result.Content.ReadFromJsonAsync<BlogViewModel>();
                NavigationManager.NavigateTo($"/Blogs/Details/{createdBlog.Id}");
            }
            else
            {
                // error message
            }
        }

    }
}
