using BlazorCMS.SharedModels.ViewModels.Blogs;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Components
{
    public class BlogListBase : ComponentBase
    {
        [Parameter]
        public bool ShowMoreLink { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        protected List<BlogViewModel> Blogs;

        protected override async Task OnInitializedAsync()
        {
            Blogs = await Http.GetFromJsonAsync<List<BlogViewModel>>("Blog");
        }
    }
}
