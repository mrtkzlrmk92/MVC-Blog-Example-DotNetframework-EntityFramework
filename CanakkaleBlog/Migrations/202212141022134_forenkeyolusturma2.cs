namespace CanakkaleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forenkeyolusturma2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Blogs", "UserId");
            AddForeignKey("dbo.Blogs", "UserId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserId" });
        }
    }
}
