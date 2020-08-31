using BlazorCMS.Core.Services;
using BlazorCMS.Server.Extensions;
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
        private readonly IBlogService _blogService;

        public BlogPostsController(ILogger<BlogPostsController> logger, IBlogPostService blogPostService, IBlogService blogService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
            _blogService = blogService;
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

        [Route("Create/{blogId}")]
        public IActionResult Create(int blogId)
        {
            var blogs = _blogService.GetBlogs();
            return Ok(CreateBlogPostViewModel.From(blogId, blogs));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CreateBlogPostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrors()); 
            }

            var blog = _blogPostService.Create(vm.ToModel());
            return Ok(BlogPostViewModel.From(blog));
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(UpdateBlogPostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model"); 
            }

            var blog = _blogPostService.Update(vm.ToModel());
            return Ok(BlogPostViewModel.From(blog));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is required"); 
            }

            _blogPostService.Delete(id);
            return Ok();
        }
    }
}
