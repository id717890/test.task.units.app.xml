using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//using app_for_xml.dal.services;
using app_for_xml.domain.entities;

namespace app_for_xml.dal.service
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : Entity;
        //void Commit();
        //void Rollback();
    }
}
