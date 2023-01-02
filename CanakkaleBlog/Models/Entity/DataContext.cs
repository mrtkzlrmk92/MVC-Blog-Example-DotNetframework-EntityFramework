using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CanakkaleBlog.Models.Entity
{
    public class DataContext:DbContext

    {
        public DataContext():base("blogConnection") {}
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogComment> BlogComment { get; set; }
        

    }
}