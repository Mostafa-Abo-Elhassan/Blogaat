using Blogaat.Data;
using Blogaat.Models.Domains;
using Blogaat.Models.ViewModels;
using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogaat.Controllers
{
    [Authorize(Roles = "Admin,Super_Admin")]
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository1)
        {
            tagRepository = tagRepository1;
        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SaveAdd(AddTagVM addTagVM)
        {
            Tag tag = new Tag
            {
                Name = addTagVM.Name,
                DisplayName = addTagVM.DisplayName
            };
            await tagRepository.AddAsync(tag);
            return RedirectToAction("GetALL");
        }




        [HttpGet]
        public async Task<IActionResult> GetALL()
        {
            var tags = await tagRepository.GetALLAsync();

            return View(tags);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var edittags = await tagRepository.GetAsync(id);
            if (edittags != null)
            {
                var Evm = new EditTagVM
                {
                    Id = edittags.Id,
                    Name = edittags.Name,
                    DisplayName = edittags.DisplayName
                };
                return View(Evm);
            }
            return View(null);
        }



        [HttpPost]
        public async Task<IActionResult> SaveEdit(EditTagVM editTagVM)
        {
            var tag = new Tag
            {
                Id = editTagVM.Id,
                Name = editTagVM.Name,
                DisplayName = editTagVM.DisplayName
            };

            var exsiting = await tagRepository.UpdateAsync(tag); //save in database by tagRepository.UpdateAsync();

            if (exsiting != null)
            {
                return RedirectToAction("Edit", new { id = editTagVM.Id });

            }

            return RedirectToAction("Edit", new { id = editTagVM.Id });
        }





        [HttpPost]
        public async Task<IActionResult> Deletee(EditTagVM editTagVM)
        {

            var deletetag = await tagRepository.DeleteAsync(editTagVM.Id);
            if (deletetag != null)
            {

                return RedirectToAction("GetALL");
            }

            return RedirectToAction("Edit", new { id = editTagVM.Id });
        }



    }
}
