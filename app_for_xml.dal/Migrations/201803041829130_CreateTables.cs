namespace app_for_xml.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        file_name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FileVersions",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        version = c.String(),
                        data = c.String(),
                        updated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        file_id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Files", t => t.file_id, cascadeDelete: true)
                .Index(t => t.file_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileVersions", "file_id", "dbo.Files");
            DropIndex("dbo.FileVersions", new[] { "file_id" });
            DropTable("dbo.FileVersions");
            DropTable("dbo.Files");
        }
    }
}
