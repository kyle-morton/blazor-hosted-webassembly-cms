using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using BlazorCMS.Web.Services.Api;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Components.Admin
{
    public class PostListBase : ComponentBase
    {
        [Parameter]
        public int BlogId { get; set; }

        [Inject]
        protected IBlogPostService _blogPostService { get; set; }

        protected List<BlogPostViewModel> Posts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Posts = BlogId > 0
                ? await _blogPostService.GetByBlogAsync(BlogId)
                : await _blogPostService.GetRecentAsync();
        }
    }
}
