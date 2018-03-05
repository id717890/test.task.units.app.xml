namespace app_for_xml.dal.services
{
    using domain.entities;

    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : Entity;
    }
}
