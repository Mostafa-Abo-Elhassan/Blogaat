using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blogaat.Models.ViewModels
{
    public class EditTagVM
    {
        public Guid Id { get; set; }
        
        //[Required]
        //[StringLength(10)]
        public string Name { get; set; }
        //[StringLength(60)]
        //[Required]
        public string DisplayName { get; set; }
    }
}
