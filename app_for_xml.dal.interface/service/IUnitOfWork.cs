using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using app_for_xml.dal.services;
using app_for_xml.domain.entities;

namespace app_for_xml.dal.service
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : Entity;
        //void BeginTransaction();
        //void Commit();
        //void Rollback();
    }
}
