namespace app_for_xml.domain.services
{
    using System;
    using System.Collections.Generic;
    using dal.services;
    using entities;

    public class FileService: IFileService
    {
        private IRepository<File> _fileRepository;
        private IRepository<FileVersion> _fileVersionRepository;
        public FileService(IUnitOfWork unitOfWork)
        {
            _fileRepository = unitOfWork.Repository<File>();
            _fileVersionRepository= unitOfWork.Repository<FileVersion>();
        }

        public IEnumerable<File> GetAllFiles()
        {
            return _fileRepository.GetAll();
        }

        public File GetFileById(long id)
        {
            return _fileRepository.GetById(id);
        }

        public FileVersion GetFileVersionById(long id)
        {
            return _fileVersionRepository.GetById(id);
        }

        public File Create(string fileName, string content)
        {
            if (fileName == null) return null;
            var file= new File
            {
                FileName = fileName
            };
            _fileRepository.Create(file);

            var fileVersion = new FileVersion
            {
                File = file,
                Data = content,
                Updated = DateTime.Now,
                Version = Guid.NewGuid().ToString()
            };

            _fileVersionRepository.Create(fileVersion);
            return file;
        }

        public FileVersion CreateVersion(long fileId, string content)
        {
            var file = GetFileById(fileId);
            if (file == null) return null;
            var newVersion=new FileVersion()
            {
                File = file,
                Updated = DateTime.Now,
                Version = Guid.NewGuid().ToString(),
                Data = content
            };
            _fileVersionRepository.Create(newVersion);
            return newVersion;
        }

        public void Update(File file)
        {
            _fileRepository.Update(file);
        }

        public void Delete(long id)
        {
            var file = GetFileById(id);
            if (file == null) return;
            _fileRepository.Delete(file);
        }
    }
}
