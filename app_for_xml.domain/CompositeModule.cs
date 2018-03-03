using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.domain.services;
using Ninject.Modules;

namespace app_for_xml.domain
{
    public class CompositeModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IFileService>().To<FileService>().InSingletonScope();
        }
    }
}
