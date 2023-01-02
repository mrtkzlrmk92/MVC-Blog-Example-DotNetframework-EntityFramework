using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanakkaleBlog.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public DateTime CommentTime { get; set; }
        public string Comment { get; set; }
        public string CommentTitle { get; set; }
        public bool IsDelete { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }
        public Blog Blog { get; set; }
    }
}