namespace app_for_xml.dal
{
    using services;
    using Ninject.Modules;

    public class CompositeModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(typeof(IFileRepository)).To(typeof(FileRepository));
            Kernel.Bind(typeof(IFileVersionRepository)).To(typeof(FileVersionRepository));
        }
    }
}
