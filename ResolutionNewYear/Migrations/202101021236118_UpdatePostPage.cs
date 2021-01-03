namespace ResolutionNewYear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostPages", "CreatedBy", c => c.String());
            AddColumn("dbo.PostPages", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostPages", "CreatedAt");
            DropColumn("dbo.PostPages", "CreatedBy");
        }
    }
}
