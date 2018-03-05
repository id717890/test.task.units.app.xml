namespace app_for_xml.infrastructure
{
    using services;
    using Ninject.Modules;

    public class CompositeModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IStringService>().To<StringService>().InSingletonScope();
            Kernel.Bind<IXmlService>().To<XmlService>().InSingletonScope();
        }
    }
}
