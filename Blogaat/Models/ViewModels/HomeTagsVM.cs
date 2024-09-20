using Blogaat.Models.Domains;

namespace Blogaat.Models.ViewModels
{
    public class HomeTagsVM
    {
        public IEnumerable<BlogPost> blog { get; set; }
        public IEnumerable<Tag> tag { get; set; }
    }
}
