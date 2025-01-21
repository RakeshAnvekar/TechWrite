
using System.ComponentModel.DataAnnotations;

namespace TechWriteServer.Models.Blog;

public class BlogLike
{
    [Key]    
    public int BlogLikeId { get; set; }
    public Guid UserId { get; set; }
    public int BlogId { get; set; }
}
