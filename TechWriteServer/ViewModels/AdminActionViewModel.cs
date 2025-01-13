using TechWriteServer.Models.Blog;

namespace TechWriteServer.ViewModels;

 sealed class AdminActionViewModel
{
    public IList<Blog>? Blogs { get; set; }

}
