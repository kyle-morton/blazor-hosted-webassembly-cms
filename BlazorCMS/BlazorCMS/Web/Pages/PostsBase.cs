using BlazorCMS.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages
{
    public class PostsBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Parameter]
        public string BlogId { get; set; }

        protected List<BlogPost> Posts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (string.IsNullOrEmpty(BlogId))
            {
                NavigationManager.NavigateTo("/blogs");
                return null;
            }

            Posts = await Http.GetFromJsonAsync<List<BlogPost>>($"Post/{BlogId}");
        }
    }
}
