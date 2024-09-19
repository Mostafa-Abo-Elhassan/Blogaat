namespace Blogaat.Repository.IRepository
{
    public interface IuploadImage
    {
        Task<string> uploadimage(IFormFile file);
    }
}
