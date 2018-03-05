namespace app_for_xml.domain.services
{
    using System.Collections.Generic;
    using entities;

    public interface IFileService
    {
        IEnumerable<File> GetAllFiles();
        File GetFileById(long id);
        FileVersion GetFileVersionById(long id);
        File Create(string fileName, string content);
        FileVersion CreateVersion(long fileId, string content);
        void Update(File file);
        void Delete(long id);
    }
}
