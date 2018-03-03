using System;
using System.Collections.Generic;
using System.Data.Entity;
using app_for_xml.dal.service;
using app_for_xml.domain.entities;

namespace app_for_xml.dal.services
{
    //public class Repository2<TEntity> : IRepository<TEntity> where TEntity : Entity
    //{
    //    //private DbContext _unitOfWorkProvider;
    //    ////[Inject]
    //    ////public IIdentifierService IdService { get; set; }

    //    //public Repository2(XmlContext unitOfWorkProvider)
    //    //{
    //    //    _unitOfWorkProvider = unitOfWorkProvider;
    //    //}

    //    ////protected ISession Session { get { return ((Db)_unitOfWorkProvider.GetUnitOfWork()).Session; } }

    //    //public virtual IEnumerable<TEntity> GetAll()
    //    //{

    //    //    return _unitOfWorkProvider.   Session.Query<TEntity>().Where(x => !x.IsDeleted).ToList<TEntity>();
    //    //}

    //    //public TEntity GetById(Int64 id)
    //    //{
    //    //    return Session.Get<TEntity>(id);
    //    //}

    //    //public void Create(TEntity entity)
    //    //{
    //    //    entity.Id = IdService.GetId();
    //    //    entity.IsDeleted = false;
    //    //    Session.Save(entity);
    //    //}

    //    //public void Update(TEntity entity)
    //    //{
    //    //    Session.Update(entity);
    //    //}

    //    //public virtual void Delete(Int64 id)
    //    //{
    //    //    var entity = Session.Load<TEntity>(id);
    //    //    entity.IsDeleted = true;
    //    //    Session.Update(entity);
    //    //}

    //    //public virtual void Delete(TEntity entity)
    //    //{
    //    //    entity.IsDeleted = true;
    //    //    Session.Update(entity);
    //    //}
    //    //public IEnumerable<TEntity> GetAll()
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public TEntity GetById(long id)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public void Create(TEntity entity)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public void Update(TEntity entity)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public void Delete(long id)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    //public void Delete(TEntity entity)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}
    //}
}
