using BlazorCMS.Core.Data;
using BlazorCMS.Shared.Domain;
using System.Collections.Generic;

namespace BlazorCMS.Core.Services
{
    public interface IBlogService
    {
        List<Blog> GetBlogs();
    }
    public class BlogService : IBlogService
    {
        public List<Blog> GetBlogs()
        {
            return MockDataContext.Blogs;
        }

    }
}
