using Microsoft.AspNetCore.Mvc.Rendering;
using TechWriteServer.Models.Blog;
using TechWriteServer.Models.Tag;
using TechWriteServer.Models.User;

namespace TechWriteServer.ViewModels;

    public class BlogViewModel
    {
        public List<Blog>? Blogs { get; set; } = new List<Blog>();
        public List<BlogComment>? BlogComments { get; set; } = new List<BlogComment>();
        public User? UserDetails { get; set; }
        public Blog? blog { get; set; }
        public List<Tag>? Tags { get;set; }
    }
