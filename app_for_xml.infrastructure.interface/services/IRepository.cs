using System.Linq;
using app_for_xml.domain.@interface.entities;

namespace app_for_xml.infrastructure.@interface.services {
    public interface IRepository<TEntity> where TEntity : Entity {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
