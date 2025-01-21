using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechWriteServer.Models.Blog;

[Index(nameof(TagId),IsUnique =false,Name = "Idx_Blog_TagId")]
public class Blog
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BlogId { get; set; }
    public  string? Title { get; set; }
    public  string? Description { get; set; }
    public bool IsActive { get; set; }
    public Guid? UserId { get; set; }
    public DateTime PublishedDate { get; set; }= DateTime.UtcNow;    
    public int TagId { get; set; }
    [NotMapped]
    public string? TagName { get; set; }

    public TechWriteServer.Models.Tag.Tag? Tag;
    public virtual List<BlogComment>? BlogComments { get; set; }
    public bool? IsApproved { get; set; } = false;
    public bool? IsTranding { get; set; } = false;
    public string RejectComment { get; set; } = string.Empty;
    // Navigation properties
    public required TechWriteServer.Models.User.User User { get; set; }
    public required IList<BlogLike> BlogLikes { get; set; }
}
