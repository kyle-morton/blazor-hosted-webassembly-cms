using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using BlazorCMS.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Posts
{
    public class CreateBase : PageBase
    {

        [Parameter]
        public string BlogId { get; set; }
        public CreateBlogPostViewModel BlogPost { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BlogPost = await Http.GetFromJsonAsync<CreateBlogPostViewModel>($"BlogPosts/Create/{BlogId}");
        }

        protected async Task Submit()
        {
            BlogPost.BlogId = int.Parse(BlogId);
            var result = await Http.PostAsJsonAsync("BlogPosts/Create", BlogPost);
            if (result.IsSuccessStatusCode)
            {
                await NotificationService.SendMessageAsync("Post Created");
                NavigationManager.NavigateTo($"/blogs/details/{BlogPost.BlogId}");
            }
            else
            {
                await NotificationService.SendMessageAsync("Post Create Failed!", UIMessageType.Error);
            }
        }


    }
}
