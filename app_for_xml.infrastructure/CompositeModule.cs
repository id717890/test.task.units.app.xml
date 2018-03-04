using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.infrastructure.services;
using Ninject.Modules;

namespace app_for_xml.infrastructure
{
    public class CompositeModule: NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IStringService>().To<StringService>().InSingletonScope();
        }
    }
}
