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
        //[Inject]
        //public IUnitOfWork UnitOfWork { get; set; }

        private IRepository<File> _fileRepository;
        private IRepository<FileVersion> _fileVersionRepository;


        //private UnitOfWork _unitOfWork;

        public FileService(IUnitOfWork unitOfWork)
        {
            //if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));
            //var u = new UnitOfWork(new XmlContext());
            _fileRepository = unitOfWork.Repository<File>();
            _fileVersionRepository = unitOfWork.Repository<FileVersion>();
        }

        //[Inject]
        //public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }




        public IEnumerable<File> GetAllFiles()
        {
            return _fileRepository.GetAll();
        }

        public File GetFileById(long id)
        {
            return _fileRepository.GetById(id);
        }

        public File Create(string fileName, string content)
        {
            if (fileName == null) return null;
            var file= new File
            {
                FileName = fileName
            };
            _fileRepository.Create(file);

            _fileVersionRepository.Create(new FileVersion
            {
                File = file,
                Data = content,
                Updated = DateTime.Now,
                Version = Guid.NewGuid().ToString()
            });
            return file;
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
