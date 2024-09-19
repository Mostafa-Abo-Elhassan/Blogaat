namespace Blogaat.Models.Domains
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
      
        public ICollection<BlogPost> blogPosts { get; set; }

    }
}
