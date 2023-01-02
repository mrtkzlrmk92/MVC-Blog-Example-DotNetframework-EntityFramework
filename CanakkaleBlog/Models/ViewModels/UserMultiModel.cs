using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CanakkaleBlog.Models.ViewModels
{
    public class UserMultiModel
    {
        public List<Role> Roles { get; set; }
        public List<User> Users { get; set; }
        public User User{ get; set; }

    }
}