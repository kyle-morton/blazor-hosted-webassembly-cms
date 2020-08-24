using BlazorCMS.Core.Services;
using BlazorCMS.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;

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
        public List<Blog> GetAll()
        {
            var results = _blogService.GetBlogs();
            return results;
        }
    }
}
