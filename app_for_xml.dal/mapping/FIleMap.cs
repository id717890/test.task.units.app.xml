namespace app_for_xml.dal.mapping
{
    using System.Data.Entity.ModelConfiguration;
    using domain.entities;

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
