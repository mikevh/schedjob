namespace MckScheduledTasks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Occurrences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TodoId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NextOccurrence = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Todoes");
            DropTable("dbo.Occurrences");
        }
    }
}
