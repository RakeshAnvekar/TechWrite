using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechWriteServer.Models.Blog;

namespace TechWriteServer.Models.Tag;

public sealed class Tag
{
    [Key]    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TagId {  get; set; }
    public string TagName { get; set; }= string.Empty;
    public bool IsActive { get; set; } = true;
    public string? TagDescription { get; set; }
    public TechWriteServer.Models.Blog.Blog? Blog { get; set; }
}
