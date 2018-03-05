﻿namespace app_for_xml.dal.services
{
    using domain.entities;

    public class FileRepository : Repository<File>, IFileRepository
    {
        public FileRepository(XmlContext context) : base(context)
        {
        }
    }
}
