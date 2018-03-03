using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.domain.entities;

namespace app_for_xml.dal.mapping
{
    public class FileVersionMap: EntityTypeConfiguration<FileVersion>
    {
        public FileVersionMap()
        {
            ToTable("FileVersions");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");
            Property(x => x.Data).HasColumnName("data");
            Property(x => x.Updated).HasColumnName("updated");
            Property(x => x.Version).HasColumnName("version");
            HasRequired(x => x.File)
                .WithMany()
                .Map(x => x.MapKey("file_id"));
        }
    }
}
