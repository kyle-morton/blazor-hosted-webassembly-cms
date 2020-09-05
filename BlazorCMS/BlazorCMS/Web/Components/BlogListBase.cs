using BlazorCMS.SharedModels.ViewModels.Blogs;
using BlazorCMS.Web.Services.Api;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
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
        protected IBlogService _blogService { get; set; }

        protected List<BlogViewModel> Blogs;

        protected override async Task OnInitializedAsync()
        {
            Blogs = await _blogService.GetAsync();
        }
    }
}
