using Blogaat.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blogaat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IuploadImage iuploadImage;

        public ImageUploadController(IuploadImage iuploadImage)
        {
            this.iuploadImage = iuploadImage;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImag(IFormFile file)
        {
            //if (file == null || file.Length == 0)
            //{
            //    return BadRequest("No file uploaded.");
            //}

            //var imageUrl = await iuploadImage.uploadimage(file);

            //if (imageUrl == null)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image.");
            //}

            //return Ok(new { link = imageUrl });
            var imageUrl = await iuploadImage.uploadimage(file);

            if (imageUrl == null)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image.");
                return Problem("", null, (int)HttpStatusCode.InternalServerError);
            }
            //return Ok(new { link = imageUrl });
            return new JsonResult(new { link = imageUrl });
        }



    }
}
