namespace ResolutionNewYear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShares : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shares", "PostPage_Id", c => c.Int());
            CreateIndex("dbo.Shares", "PostPage_Id");
            AddForeignKey("dbo.Shares", "PostPage_Id", "dbo.PostPages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shares", "PostPage_Id", "dbo.PostPages");
            DropIndex("dbo.Shares", new[] { "PostPage_Id" });
            DropColumn("dbo.Shares", "PostPage_Id");
        }
    }
}
