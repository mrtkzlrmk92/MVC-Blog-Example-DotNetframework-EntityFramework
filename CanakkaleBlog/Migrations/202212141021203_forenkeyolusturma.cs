namespace CanakkaleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forenkeyolusturma : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Blogs", "CategoryId");
            CreateIndex("dbo.BlogComments", "UserId");
            CreateIndex("dbo.BlogComments", "BlogId");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BlogComments", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.BlogComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.BlogComments", new[] { "UserId" });
            DropIndex("dbo.Blogs", new[] { "CategoryId" });
        }
    }
}
