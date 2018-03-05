using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.dal.service;
using app_for_xml.dal.services;
using app_for_xml.domain.services;
using Ninject.Modules;

namespace app_for_xml.dal
{
    public class CompositeModule: NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            Kernel.Bind(typeof(IFileRepository)).To(typeof(FileRepository));
            Kernel.Bind(typeof(IFileVersionRepository)).To(typeof(FileVersionRepository));
        }
    }
}
