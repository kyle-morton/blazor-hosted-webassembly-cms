using BlazorCMS.SharedModels.ViewModels.Blogs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Services.Api
{
    public interface IBlogService
    {
        Task<BlogViewModel> CreateAsync(CreateBlogViewModel vm);
        Task<BlogViewModel> GetAsync(int id);
        Task<List<BlogViewModel>> GetAsync();
        Task<BlogViewModel> UpdateAsync(BlogViewModel vm);
        Task<bool> DeleteAsync(int id);
    }
    public class BlogService : ApiServiceBase, IBlogService
    {
        private readonly string _urlBase = "Blogs";

        public BlogService(HttpClient client) : base(client)
        {
        }

        public async Task<BlogViewModel> CreateAsync(CreateBlogViewModel vm)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_urlBase}/Create", vm);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<BlogViewModel>();
        }

        public async Task<BlogViewModel> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BlogViewModel>($"{_urlBase}/{id}");
        }

        public async Task<BlogViewModel> UpdateAsync(BlogViewModel vm)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_urlBase}/Update", vm);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<BlogViewModel>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"{_urlBase}/Delete/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<List<BlogViewModel>> GetAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<BlogViewModel>>(_urlBase);
        }
    }
}
