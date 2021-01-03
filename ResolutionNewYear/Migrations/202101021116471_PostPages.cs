namespace ResolutionNewYear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostPages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostPages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "PostPage_Id", c => c.Int());
            CreateIndex("dbo.Posts", "PostPage_Id");
            AddForeignKey("dbo.Posts", "PostPage_Id", "dbo.PostPages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostPage_Id", "dbo.PostPages");
            DropIndex("dbo.Posts", new[] { "PostPage_Id" });
            DropColumn("dbo.Posts", "PostPage_Id");
            DropTable("dbo.PostPages");
        }
    }
}
