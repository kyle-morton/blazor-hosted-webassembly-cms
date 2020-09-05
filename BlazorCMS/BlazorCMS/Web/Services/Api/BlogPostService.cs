using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Services.Api
{
    public interface IBlogPostService
    {
        Task<CreateBlogPostViewModel> GetCreateAsync(int blogId);
        Task<BlogPostViewModel> CreateAsync(CreateBlogPostViewModel vm);
        Task<BlogPostViewModel> GetAsync(int id);
        Task<List<BlogPostViewModel>> GetRecentAsync();
        Task<List<BlogPostViewModel>> GetByBlogAsync(int id);
        Task<BlogPostViewModel> UpdateAsync(BlogPostViewModel vm);
        Task<bool> DeleteAsync(int id);
    }

    public class BlogPostService : ApiServiceBase, IBlogPostService
    {
        private readonly string _urlBase = "BlogPosts";

        public BlogPostService(HttpClient client) : base(client)
        {
        }

        public async Task<BlogPostViewModel> CreateAsync(CreateBlogPostViewModel vm)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_urlBase}/Create", vm);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<BlogPostViewModel>();
        }

        public async Task<BlogPostViewModel> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<BlogPostViewModel>($"{_urlBase}/Details/{id}");
        }

        public async Task<BlogPostViewModel> UpdateAsync(BlogPostViewModel vm)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_urlBase}/Update", vm);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<BlogPostViewModel>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _httpClient.DeleteAsync($"{_urlBase}/Delete/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<List<BlogPostViewModel>> GetRecentAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<BlogPostViewModel>>($"{_urlBase}/recent");
        }

        public async Task<List<BlogPostViewModel>> GetByBlogAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<BlogPostViewModel>>($"{_urlBase}/byBlog/{id}");
        }

        public async Task<CreateBlogPostViewModel> GetCreateAsync(int blogId)
        {
            return await _httpClient.GetFromJsonAsync<CreateBlogPostViewModel>($"{_urlBase}/Create/{blogId}");
        }
    }
}
