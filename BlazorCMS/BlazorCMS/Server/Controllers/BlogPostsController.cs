using BlazorCMS.Core.Services;
using BlazorCMS.SharedModels.ViewModels.BlogPosts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BlazorCMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly ILogger<BlogPostsController> _logger;
        private readonly IBlogPostService _blogPostService;

        public BlogPostsController(ILogger<BlogPostsController> logger, IBlogPostService blogPostService)
        {
            _logger = logger;
            _blogPostService = blogPostService;

        }

        [HttpGet]
        [Route("Recent")]
        public IActionResult Recent()
        {
            var recents = _blogPostService.GetPosts().OrderByDescending(c => c.CreateDate).Take(5);
            return Ok(recents.Select(bp => BlogPostViewModel.From(bp)));
        }

        [HttpGet]
        [Route("ByBlog/{blogId}")]
        public IActionResult GetAll(int blogId)
        {
            var results = _blogPostService.GetBlogPosts(blogId);

            return Ok(results.Select(BlogPostViewModel.From));
        }

        [HttpGet]
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var result = _blogPostService.GetPost(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(BlogPostViewModel.From(result));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CreateBlogPostViewModel vm)
        {
            return Ok();
        }
    }
}
