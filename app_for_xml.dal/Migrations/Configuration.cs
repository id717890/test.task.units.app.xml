using app_for_xml.domain.@interface.entities;

namespace app_for_xml.dal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<app_for_xml.dal.XmlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(app_for_xml.dal.XmlContext context)
        {
            context.Database.ExecuteSqlCommand("delete from FileVersions");
            context.Database.ExecuteSqlCommand("delete from Files");

            context.Files.AddOrUpdate(
                new File{ Id = 1, FileName = "Test1" },
                new File{ Id = 2, FileName = "Test2" }
                );
            context.SaveChanges();

            context.FileVersions.AddOrUpdate(
                new FileVersion() { File = context.Files.FirstOrDefault(), Updated = DateTime.Now, Version = "1", Id = 1}, 
                new FileVersion() { File = context.Files.FirstOrDefault(), Data = "", Updated = DateTime.Now.AddMinutes(-10), Version = "2", Id = 2}
                );
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
