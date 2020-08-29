using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Components
{
    public class PostListBase : ComponentBase
    {
        [Parameter]
        public int BlogId { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        protected List<BlogPostViewModel> Posts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Posts = BlogId > 0
                ? await Http.GetFromJsonAsync<List<BlogPostViewModel>>($"BlogPosts/ByBlog/{BlogId}")
                : await Http.GetFromJsonAsync<List<BlogPostViewModel>>($"BlogPosts/Recent");
        }
    }
}
