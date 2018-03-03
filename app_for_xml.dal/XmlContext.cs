using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.domain.@interface.entities;

namespace app_for_xml.dal
{
    public class XmlContext: DbContext
    {

        public DbSet<File> Files { get; set; }
        public DbSet<FileVersion> FileVersions { get; set; }
        public XmlContext() : base("DefaultConnection")
        { }
    }
}
