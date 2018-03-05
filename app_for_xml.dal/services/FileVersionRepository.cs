namespace app_for_xml.dal.services
{
    using service;
    using domain.entities;

    public class FileVersionRepository : Repository<FileVersion>, IFileVersionRepository
    {
        public FileVersionRepository(XmlContext context) : base(context)
        {
        }
    }
}
