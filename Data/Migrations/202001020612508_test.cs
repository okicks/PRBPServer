namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ThreadId = c.Int(nullable: false),
                        Edited = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.ThreadId, cascadeDelete: true)
                .Index(t => t.ThreadId);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        CatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ThreadId", "dbo.Threads");
            DropForeignKey("dbo.Threads", "CatagoryId", "dbo.Categories");
            DropIndex("dbo.Threads", new[] { "CatagoryId" });
            DropIndex("dbo.Posts", new[] { "ThreadId" });
            DropTable("dbo.Threads");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
