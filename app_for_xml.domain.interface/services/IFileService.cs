namespace app_for_xml.domain.services
{
    using System;
    using System.Collections.Generic;
    using entities;

    public interface IFileService
    {
        IEnumerable<File> GetAllTypes();
        File GetTypeById(Int64 id);
        Int64 Create(string caption);
        void Update(File actionType);
        void Delete(Int64 typeId);
    }
}
