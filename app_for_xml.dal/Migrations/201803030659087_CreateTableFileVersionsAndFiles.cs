namespace app_for_xml.dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableFileVersionsAndFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FileVersions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Version = c.String(),
                        Data = c.String(),
                        Updated = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        File_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.File_Id)
                .Index(t => t.File_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileVersions", "File_Id", "dbo.Files");
            DropIndex("dbo.FileVersions", new[] { "File_Id" });
            DropTable("dbo.FileVersions");
            DropTable("dbo.Files");
        }
    }
}
