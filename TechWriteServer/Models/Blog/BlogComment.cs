using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechWriteServer.Models.Blog;

public class BlogComment
{
    [Key]
    public Guid BlogCommentId { get; set; } = new Guid();
    public required string Comment { get; set; }=string.Empty;
    public required int BlogId { get; set; }
    public required DateTime CommentDate { get; set; }=DateTime.Now;
    public required Guid UserId { get; set; }
}
