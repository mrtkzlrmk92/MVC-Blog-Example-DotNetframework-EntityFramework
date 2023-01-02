using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanakkaleBlog.Models
{
    public class Blog:BaseClass
    {
        public int CategoryId { get; set; }
        public string Link   { get; set; }
        public int UserId { get; set; }
        public DateTime WriteTime { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public List<BlogComment> BlogComments { get; set; }
    }
}