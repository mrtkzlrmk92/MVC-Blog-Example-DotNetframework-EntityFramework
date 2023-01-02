using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanakkaleBlog.Models
{
    public class Category:BaseClass
    {
        public List<Blog> Blogs { get; set; }
    }
}