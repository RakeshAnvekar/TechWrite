using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechWriteServer.Models.Blog;

namespace TechWriteServer.Models.User;

public class User
{
    [Key]
    public required Guid  UserId { get; set; }=Guid.NewGuid();
    public string UserName { get; set; } = string.Empty;

   // [Remote("IsEmailUnique", "User", ErrorMessage = "This email address is already taken.")]
    public string UserEmailId { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [NotMapped]
    public string ConfirmPassword { get; set; } = string.Empty;

    [DataType(DataType.PhoneNumber)]
    public string UserPhoneNo { get; set; } = string.Empty;
    public int UserTypeId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public bool? isActive { get; set; } = true;
    public string? ProfilePicture { get; set; }
    public bool IsUserLoggedIn { get; set;} = false;
    public ICollection<TechWriteServer.Models.Blog.Blog> Blogs { get; set; }  // Blogs written by the user
    public ICollection<BlogLike> BlogLikes { get; set; }  // Blogs liked by the user
}

