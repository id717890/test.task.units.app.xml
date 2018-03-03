using System;
using System.Collections.Generic;
using app_for_xml.domain.entities;

namespace app_for_xml.dal.service
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        //void Create(TEntity entity);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(Int64 id);
        void Delete(TEntity entity);
    }
}
