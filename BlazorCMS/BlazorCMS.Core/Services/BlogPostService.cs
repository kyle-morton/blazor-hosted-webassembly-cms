using BlazorCMS.Core.Data;
using BlazorCMS.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorCMS.Core.Services
{

    public interface IBlogPostService
    {
        List<BlogPost> GetBlogPosts(int blogId);
    }

    public class BlogPostService : IBlogPostService
    {
        public List<BlogPost> GetBlogPosts(int blogId)
        {
            var blog = MockDataContext.Blogs.SingleOrDefault(b => b.Id == blogId);
            return blog?.Posts;
        }
    }
}
