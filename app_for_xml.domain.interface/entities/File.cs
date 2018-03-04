
using System.Collections;
using System.Collections.Generic;

namespace app_for_xml.domain.entities
{
    public class File : Entity
    {
        public string FileName { get; set; }
        public ICollection<FileVersion> Versions { get; set; }

        public File()
        {
            Versions=new List<FileVersion>();
        }
    }
}
