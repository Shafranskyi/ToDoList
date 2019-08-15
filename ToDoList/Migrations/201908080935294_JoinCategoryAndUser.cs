namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JoinCategoryAndUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "ApplicationUserId");
            AddForeignKey("dbo.Categories", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "ApplicationUserId" });
            DropColumn("dbo.Categories", "ApplicationUserId");
        }
    }
}
