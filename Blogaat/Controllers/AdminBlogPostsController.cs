using Blogaat.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blogaat.Models.Domains;
using Microsoft.AspNetCore.Components.Web;
using Azure;
using Blogaat.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.AspNetCore.Authorization;
using Blogaat.Repository.Repository;
namespace Blogaat.Controllers
{
    [Authorize(Roles = "Admin,Super_Admin")]
    public class AdminBlogPostsController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IuploadImage iupload;

        public AdminBlogPostsController(ITagRepository tagRepository,
            IBlogPostRepository blogPostRepository, IuploadImage iupload)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
            this.iupload = iupload;
        }



        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags = await tagRepository.GetALLAsync();
            var model = new AddBlogPostVM
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> SaveAdd(AddBlogPostVM addBlogPostVM )
        {

           
            
                

                var blogpost = new BlogPost
                {
                    Heading = addBlogPostVM.Heading,
                    PageTitle = addBlogPostVM.PageTitle,
                    Content = addBlogPostVM.Content,
                    ShortDescription = addBlogPostVM.ShortDescription,
                    FeateredImageUrl = addBlogPostVM.FeateredImageUrl,// path image in db
                    UrlHandle = addBlogPostVM.UrlHandle,
                    PublishedDate = addBlogPostVM.PublishedDate,
                    Author = addBlogPostVM.Author,
                    Visible = addBlogPostVM.Visible,

                };
               
                

                var selectedtags = new List<Tag>();
                foreach (var selectedtagID in addBlogPostVM.SelectedTags)
                {
                    var selectedtagIDguid = Guid.Parse(selectedtagID);
                    var exist = await tagRepository.GetAsync(selectedtagIDguid);

                    if (exist != null)
                    {
                        selectedtags.Add(exist);

                    }

                }
               
                if (blogpost != null)
                {
                    blogpost.tags = selectedtags;
                   

                    
                    await blogPostRepository.AddAsync(blogpost);
                    return RedirectToAction("GetALL");

                }

            


            return RedirectToAction("Add");
        }


        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var BLOgpost = await blogPostRepository.GetALLAsync();

            return View(BLOgpost);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var edittags = await blogPostRepository.GetAsync(id);
            var tags = await tagRepository.GetALLAsync();
            if (edittags != null)
            {
                var blogpost = new EditBlogPostVM
                {
                    Heading = edittags.Heading,
                    PageTitle = edittags.PageTitle,
                    Content = edittags.Content,
                    ShortDescription = edittags.ShortDescription,
                    FeateredImageUrl = edittags.FeateredImageUrl,
                    UrlHandle = edittags.UrlHandle,
                    PublishedDate = edittags.PublishedDate,
                    Author = edittags.Author,
                    Visible = edittags.Visible,
                    Tags = tags.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),
                    SelectedTags = tags.Select(x => x.Id.ToString()).ToArray()
                };
                return View(blogpost);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEditblog(EditBlogPostVM editBlogPostVM)
        {

            var blogpost = new BlogPost
            {
                Id = editBlogPostVM.Id,
                Heading = editBlogPostVM.Heading,
                PageTitle = editBlogPostVM.PageTitle,
                Content = editBlogPostVM.Content,
                ShortDescription = editBlogPostVM.ShortDescription,
                FeateredImageUrl = editBlogPostVM.FeateredImageUrl,
                UrlHandle = editBlogPostVM.UrlHandle,
                PublishedDate = editBlogPostVM.PublishedDate,
                Author = editBlogPostVM.Author,
                Visible = editBlogPostVM.Visible
            };

            var selectedtags = new List<Tag>();
            foreach (var selectedtagID in editBlogPostVM.SelectedTags)
            {
                var selectedtagIDguid = Guid.Parse(selectedtagID);
                var exist = await tagRepository.GetAsync(selectedtagIDguid);

                if (exist != null)
                {
                    selectedtags.Add(exist);

                }

            }
            blogpost.tags = selectedtags;
            var bb = await blogPostRepository.UpdateAsync(blogpost);

            if (bb != null)
            {

                return RedirectToAction("Edit", new { id = editBlogPostVM.Id });
            }

            return RedirectToAction("Edit", new { id = editBlogPostVM.Id });

        }


        //foreach (var seLECTTAG in editBlogPostVM.SelectedTags)
        //{
        //    if (Guid.TryParse(seLECTTAG,out var tag))
        //    {
        //        var selectedTag = await tagRepository.GetAsync(tag);

        //        if (selectedTag != null)
        //        {
        //            tagss.Add(selectedTag);
        //        }
        //    }


        //}

        //editBlog.tags = tagss;

        //var exsiting = await blogPostRepository.UpdateAsync(editBlog);
        //if (exsiting != null)
        //{
        //    return RedirectToAction("Edit", new { id = editBlog.Id });

        //}
        //return RedirectToAction("Edit", new { id = editBlog.Id });
        //if (blogupdated!=null)
        //{
        //    return RedirectToAction("Edit"/*, new {id=editBlog.Id}*/);
        //}
        //return RedirectToAction("Edit");



        public async Task<IActionResult> Delete(EditBlogPostVM editBlogPostVM)
        {
            var blogdeleted = await blogPostRepository.DeleteAsync(editBlogPostVM.Id);
            if (blogdeleted != null)
            {
                return RedirectToAction("GetALL");
            }
            return RedirectToAction("Edit", new { id = editBlogPostVM.Id });
        }
    }
}

