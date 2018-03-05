using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.domain.entities;

namespace app_for_xml.dal.mapping
{
    public class FIleMap: EntityTypeConfiguration<File>
    {
        public FIleMap()
        {
            ToTable("Files");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");
            Property(x => x.FileName).HasColumnName("file_name");
            HasMany(x => x.Versions).WithRequired(x => x.File);
        }
    }
}
