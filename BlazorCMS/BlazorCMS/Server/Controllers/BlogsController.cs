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
            List<Blog> results = _blogService.GetBlogsAsync();
            return Ok(results.Select(BlogViewModel.From));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var result = _blogService.GetBlogAsync(id);
            return Ok(BlogViewModel.From(result));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(CreateBlogViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model"); 
            }

            var blog = _blogService.CreateAsync(vm.ToModel());
            return Ok(BlogViewModel.From(blog));
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(UpdateBlogViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model"); 
            }

            var blog = _blogService.UpdateAsync(vm.ToModel());
            return Ok(BlogViewModel.From(blog));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id is required"); 
            }

            _blogService.DeleteAsync(id);
            return Ok(); 
        }
    }
}
