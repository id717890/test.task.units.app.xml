namespace app_for_xml.domain.entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class File : Entity
    {
        public string FileName { get; set; }
        public virtual ICollection<FileVersion> Versions { get; set; }

        public File()
        {
            Versions = new List<FileVersion>();
        }

        public FileVersion GetLatestVersion()
        {
            return Versions.SingleOrDefault(x => x.Id == Versions.Max(y => y.Id));
        }

        public FileVersion GetVersionById(long id)
        {
            return Versions.SingleOrDefault(x => x.Id == id);
        }
    }
}
