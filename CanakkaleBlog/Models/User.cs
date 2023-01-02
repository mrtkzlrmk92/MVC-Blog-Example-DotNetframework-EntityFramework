﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanakkaleBlog.Models
{
    public class User : BaseClass
    {
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<BlogComment> BlogComments { get; set; }


    }
}