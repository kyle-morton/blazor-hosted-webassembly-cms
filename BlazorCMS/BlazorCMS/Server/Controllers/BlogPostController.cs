using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCMS.Core.Services;
using BlazorCMS.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorCMS.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly ILogger<BlogPostController> _logger;
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(ILogger<BlogPostController> logger, IBlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;

        }

        [HttpGet]
        public List<BlogPost> GetAll()
        {
            return new List<BlogPost>();
        }

        [HttpGet]
        [Route("ByBlog/{blogId}")]
        public List<BlogPost> GetAll(int blogId)
        {
            var results = _blogPostService.GetBlogPosts(blogId);
            return results;
        }
    }
}
