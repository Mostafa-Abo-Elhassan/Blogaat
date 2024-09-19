using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogaat.Models.ViewModels
{
    public class AddBlogPostVM
    {
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
 
        public string ShortDescription { get; set; }
        public string FeateredImageUrl { get; set; }  //images
        public string UrlHandle { get; set; }         //path
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        public IEnumerable<SelectListItem> Tags { get; set; }
        public string[] SelectedTags { get; set; } = Array.Empty<string>();

    }
}
