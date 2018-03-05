namespace app_for_xml.dal.services
{
    using System;
    using System.Collections.Generic;
    using domain.entities;

    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Int64 id);
        void Delete(TEntity entity);
    }
}
