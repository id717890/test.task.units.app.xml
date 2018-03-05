namespace app_for_xml.dal.mapping
{
    using System.Data.Entity.ModelConfiguration;
    using domain.entities;

    public class FileVersionMap : EntityTypeConfiguration<FileVersion>
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
