namespace TechWriteServer.Models.Blog;

public class BlogLikeRequest
{
    public int BlogId { get; set; }
    public Guid UserId { get; set; }
}
