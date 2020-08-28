using BlazorCMS.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Components
{
    public class BlogListBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        protected List<Blog> Blogs;

        protected override async Task OnInitializedAsync()
        {
            Blogs = await Http.GetFromJsonAsync<List<Blog>>("Blog");
        }
    }
}
