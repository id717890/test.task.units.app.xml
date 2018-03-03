using System.Collections.Generic;
using System.Linq;
using app_for_xml.dal.service;
using app_for_xml.domain.entities;

namespace app_for_xml.dal.services
{
    public class FileRepository : Repository<File>
    {
        public FileRepository(XmlContext context) : base(context)
        {
        }
    }
}
