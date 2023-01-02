using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanakkaleBlog.Models
{
    public class Role:BaseClass
    {
        public List<User> Users { get; set; }
    }
}