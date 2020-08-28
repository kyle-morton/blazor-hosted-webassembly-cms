using BlazorCMS.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages
{
    public class BlogPostsBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; } 

        [Parameter]
        public int BlogId { get; set; }

        protected List<BlogPost> Posts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (BlogId == 0)
            {
                NavigationManager.NavigateTo("/blogs");
            }
            else
            {
                Posts = await Http.GetFromJsonAsync<List<BlogPost>>($"BlogPost");
            }
        }
    }
}
