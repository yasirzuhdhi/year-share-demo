namespace ResolutionNewYear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShares1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shares", "PostPage_Id", "dbo.PostPages");
            DropIndex("dbo.Shares", new[] { "PostPage_Id" });
            DropColumn("dbo.Shares", "PostPage_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shares", "PostPage_Id", c => c.Int());
            CreateIndex("dbo.Shares", "PostPage_Id");
            AddForeignKey("dbo.Shares", "PostPage_Id", "dbo.PostPages", "Id");
        }
    }
}
