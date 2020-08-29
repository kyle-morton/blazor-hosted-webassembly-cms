using BlazorCMS.Core.Services;
using BlazorCMS.Shared.Domain;
using BlazorCMS.SharedModels.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly IBlogService _blogService;

        public BlogsController(ILogger<BlogsController> logger, IBlogService blogService)
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model"); //todo: add a GetErrors() extension method to ModelState
            }

            var blog = _blogService.Create(vm.ToModel());
            return Ok(BlogViewModel.From(blog));
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(UpdateBlogViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model"); //todo: add a GetErrors() extension method to ModelState
            }

            var blog = _blogService.Update(vm.ToModel());
            return Ok(BlogViewModel.From(blog));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is required"); //todo: add a GetErrors() extension method to ModelState
            }

            _blogService.Delete(id);
            return Ok(); 
        }
    }
}
