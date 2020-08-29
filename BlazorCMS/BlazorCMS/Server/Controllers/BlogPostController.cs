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
        [Route("Recent")]
        public IActionResult Recent()
        {
            var recents = _blogPostService.GetPosts().OrderByDescending(c => c.CreateDate).Take(5);
            return Ok(recents);
        }

        [HttpGet]
        [Route("ByBlog/{blogId}")]
        public IActionResult GetAll(int blogId)
        {
            var results = _blogPostService.GetBlogPosts(blogId);
            return Ok(results);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var result = _blogPostService.GetPost(id);
            return Ok(result);
        }
    }
}
