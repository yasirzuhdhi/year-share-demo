namespace ResolutionNewYear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatepst1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PageId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PageId");
        }
    }
}
