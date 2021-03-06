﻿using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using BlazorCMS.Web.Services.Api;
using BlazorCMS.Web.Services.UI;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Admin.Posts
{
    public class CreateBase : PageBase
    {
        [Inject]
        private IBlogPostService _blogPostService { get; set; }
        [Parameter]
        public string BlogId { get; set; }
        public CreateBlogPostViewModel BlogPost { get; set; }

        public string BackHref => BlogPost != null ? $"/admin/blogs/details/{BlogPost.BlogId}" : "/admin/blogs";

        protected override async Task OnInitializedAsync()
        {
            BlogPost = await _blogPostService.GetCreateAsync(int.Parse(BlogId));
        }

        protected async Task Submit()
        {
            IsProcessing = true;
            BlogPost.BlogId = int.Parse(BlogId);
            var result = await _blogPostService.CreateAsync(BlogPost);
            if (result != null)
            {
                await NotificationService.SendMessageAsync("Post Created");
                NavigationManager.NavigateTo($"/admin/blogs/details/{BlogPost.BlogId}");
            }
            else
            {
                await NotificationService.SendMessageAsync("Post Create Failed!", UIMessageType.Error);
            }
            IsProcessing = false;
        }


    }
}
