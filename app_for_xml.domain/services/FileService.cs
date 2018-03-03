using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app_for_xml.dal;
using app_for_xml.dal.service;
using app_for_xml.dal.services;
using app_for_xml.domain.entities;
using app_for_xml.domain.services;
using Ninject;

namespace app_for_xml.domain.services
{
    public class FileService: IFileService
    {
        private Repository<File> _repository;
        private UnitOfWork _unitOfWork;

        public FileService()
        {
            _unitOfWork=new UnitOfWork(new XmlContext());
            _repository = _unitOfWork.Repository<File>();
        }

        //[Inject]
        //public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }




        public IEnumerable<File> GetAllTypes()
        {
            return _repository.GetAll();
            throw new NotImplementedException();
        }

        public File GetTypeById(long id)
        {
            throw new NotImplementedException();
        }

        public long Create(string caption)
        {
            throw new NotImplementedException();
        }

        public void Update(File actionType)
        {
            throw new NotImplementedException();
        }

        public void Delete(long typeId)
        {
            throw new NotImplementedException();
        }
    }
}
