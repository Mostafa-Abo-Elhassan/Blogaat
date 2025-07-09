using Blogaat.Models;
using Blogaat.Models.ViewModels;
using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blogaat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ITagRepository tagRepository;

        public HomeController(ILogger<HomeController> logger, IBlogPostRepository blogPostRepository
            , ITagRepository tagRepository)
        {
            _logger = logger;
            this.blogPostRepository = blogPostRepository;
            this.tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;

            var allBlogs = await blogPostRepository.GetALLAsync();
            var tags = await tagRepository.GetALLAsync();

            var paginatedBlogs = allBlogs
                                 .OrderByDescending(b => b.PublishedDate)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToList();

            var totalBlogs = allBlogs.Count();
            ViewBag.TotalPages = (int)Math.Ceiling(totalBlogs / (double)pageSize);
            ViewBag.CurrentPage = page;

            var model = new HomeTagsVM
            {
                blog = paginatedBlogs,
                tag = tags
            };

            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> LoadMorePosts(int page = 1)
        //{
        //    int pageSize = 2;

        //    var allBlogs = await blogPostRepository.GetALLAsync();
        //    var paginatedBlogs = allBlogs
        //        .OrderByDescending(b => b.PublishedDate)
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToList();

        //    // نرجّع Partial View أو Json
        //    return PartialView("_BlogPostCard", paginatedBlogs);
        //}




        //[Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }






    }


}
