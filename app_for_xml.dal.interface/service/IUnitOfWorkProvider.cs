using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_for_xml.dal.service
{
    interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork();
    }
}
