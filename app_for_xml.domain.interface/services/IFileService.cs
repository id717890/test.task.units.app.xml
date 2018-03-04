namespace app_for_xml.domain.services
{
    using System;
    using System.Collections.Generic;
    using entities;

    public interface IFileService
    {
        IEnumerable<File> GetAllFiles();
        File GetFileById(Int64 id);
        File Create(string fileName, string content);
        void Update(File actionType);
        void Delete(Int64 typeId);
    }
}
