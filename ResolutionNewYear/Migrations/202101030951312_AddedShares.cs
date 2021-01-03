namespace ResolutionNewYear.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedShares : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SharedTo = c.String(),
                        Message = c.String(),
                        SharedBy = c.String(),
                        PageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shares");
        }
    }
}
