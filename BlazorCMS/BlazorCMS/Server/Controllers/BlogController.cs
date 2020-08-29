using BlazorCMS.Core.Services;
using BlazorCMS.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorCMS.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogService _blogService;

        public BlogController(ILogger<BlogController> logger, IBlogService blogService)
        {
            _logger = logger;
            _blogService = blogService;

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _blogService.GetBlogs();
            return Ok(results);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var result = _blogService.GetBlog(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Blog blog)
        {
            blog = _blogService.Create(blog);
            return Ok(blog);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Blog blog)
        {
            blog = _blogService.Update(blog);
            return Ok(blog);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            _blogService.Delete(id);
            return Ok(); 
        }
    }
}
