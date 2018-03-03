using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.domain.@interface.entities;
using app_for_xml.domain.@interface.services;

namespace app_for_xml.domain.services
{
    public class FileService: IFileService
    {
        public IEnumerable<File> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public File GetTypeById(long id)
        {
            throw new NotImplementedException();
        }

        public long Create(string caption)
        {
            throw new NotImplementedException();
        }

        public void Update(File actionType)
        {
            throw new NotImplementedException();
        }

        public void Delete(long typeId)
        {
            throw new NotImplementedException();
        }
    }
}
