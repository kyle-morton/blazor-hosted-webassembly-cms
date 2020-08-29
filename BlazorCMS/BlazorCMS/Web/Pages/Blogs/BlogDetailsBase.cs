using BlazorCMS.SharedModels.ViewModels.Blogs;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Blogs
{
    public class BlogDetailsBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public int Id { get; set; }

        public BlogViewModel Blog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id == 0)
            {
                NavigationManager.NavigateTo("/Blogs");
            }
            else
            {
                Blog = await Http.GetFromJsonAsync<BlogViewModel>($"Blogs/{Id}");
            }
        }

        protected async Task Delete()
        {
            var result = await Http.PostAsync($"Blogs/Delete/{Id}", null);
            if (result.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/Blogs");
            }
        }
    }
}
