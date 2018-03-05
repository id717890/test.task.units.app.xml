using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.dal.mapping;
using app_for_xml.domain.entities;

namespace app_for_xml.dal
{
    public class XmlContext: DbContext
    {

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public DbSet<File> Files { get; set; }
        public DbSet<FileVersion> FileVersions { get; set; }
        public XmlContext() : base("DefaultConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new FIleMap());
            modelBuilder.Configurations.Add(new FileVersionMap());
        }
    }
}
