using BlazorCMS.SharedModels.ViewModels.Blogs;
using BlazorCMS.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Pages.Blogs
{
    public class DetailsBase : PageBase
    {

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

        protected async Task HandleValidSubmit()
        {
            var result = await Http.PostAsJsonAsync("Blogs/Update", Blog);
            if (result.IsSuccessStatusCode)
            {
                Blog = await result.Content.ReadFromJsonAsync<BlogViewModel>();
                await NotificationService.SendMessage("Blog Updated");
            } 
            else
            {
                await NotificationService.SendMessage("Blog Update Failed!", UIMessageType.Error);
            }
        }
        protected async Task Delete()
        {
            var result = await Http.DeleteAsync($"Blogs/Delete/{Id}");
            if (result.IsSuccessStatusCode)
            {
                await NotificationService.SendMessage("Blog Deleted");
                NavigationManager.NavigateTo("/Blogs");
            }
        }
    }
}
