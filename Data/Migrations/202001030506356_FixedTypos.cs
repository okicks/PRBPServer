namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTypos : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Threads", name: "CatagoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.Threads", name: "IX_CatagoryId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Threads", name: "IX_CategoryId", newName: "IX_CatagoryId");
            RenameColumn(table: "dbo.Threads", name: "CategoryId", newName: "CatagoryId");
        }
    }
}
