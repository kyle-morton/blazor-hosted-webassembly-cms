using BlazorCMS.Core.Services;
using BlazorCMS.Shared.Domain;
using BlazorCMS.SharedModels.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

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
            List<Blog> results = _blogService.GetBlogs();
            return Ok(results.Select(BlogViewModel.From));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var result = _blogService.GetBlog(id);
            return Ok(BlogViewModel.From(result));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CreateBlogViewModel vm)
        {
            var blog = _blogService.Create(vm.ToModel());
            return Ok(BlogViewModel.From(blog));
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(UpdateBlogViewModel vm)
        {
            var blog = _blogService.Update(vm.ToModel());
            return Ok(BlogViewModel.From(blog));
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
