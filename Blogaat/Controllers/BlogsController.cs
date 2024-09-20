using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogaat.Controllers
{
    [Authorize]
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogsController(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }
        public async Task < IActionResult> Index(Guid id)
        {
            var blog = await blogPostRepository.GetAsync(id);

            return View(blog);
        }
    }
}
