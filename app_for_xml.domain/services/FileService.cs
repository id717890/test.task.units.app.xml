using app_for_xml.infrastructure.services;

namespace app_for_xml.domain.services
{
    using System;
    using System.Collections.Generic;
    using dal.services;
    using entities;

    public class FileService : IFileService
    {
        private ILogger _logger;
        private IRepository<File> _fileRepository;
        private IRepository<FileVersion> _fileVersionRepository;
        public FileService(IUnitOfWork unitOfWork, ILogger logger)
        {
            _fileRepository = unitOfWork.Repository<File>();
            _fileVersionRepository = unitOfWork.Repository<FileVersion>();
            _logger = logger;
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
            _logger.Info("FileService - start create File " + fileName);
            if (fileName == null) return null;
            var file = new File
            {
                FileName = fileName
            };
            _fileRepository.Create(file);
            _logger.Info("FileService - File " + fileName + " is created");

            _logger.Info("FileService - start create FileVersion for file " + fileName);
            var fileVersion = new FileVersion
            {
                File = file,
                Data = content,
                Updated = DateTime.Now,
                Version = Guid.NewGuid().ToString()
            };
            _fileVersionRepository.Create(fileVersion);
            _logger.Info("FileService - FileVersion for file " + fileName + " is created");
            return file;
        }

        public FileVersion CreateVersion(long fileId, string content)
        {
            _logger.Info("FileService - Create version for file_id " + fileId);

            var file = GetFileById(fileId);
            if (file == null) return null;
            var newVersion = new FileVersion()
            {
                File = file,
                Updated = DateTime.Now,
                Version = Guid.NewGuid().ToString(),
                Data = content
            };
            _fileVersionRepository.Create(newVersion);
            _logger.Info("FileService - Creating version for file_id " + fileId + " is completed");
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
